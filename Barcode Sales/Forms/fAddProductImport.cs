using Barcode_Sales.DTOs;
using DevExpress.XtraEditors;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Services.CacheServices;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Barcode_Sales.Forms
{
    public partial class fAddProductImport : DevExpress.XtraEditors.XtraForm
    {


        private DataTable _currentTable;
        private DataSet _workbook;
        List<ProductInvoiceImportDto> _invoices = new List<ProductInvoiceImportDto>();
        DataTableCollection tableCollection;
        public fAddProductImport()
        {
            InitializeComponent();
            this.AllowDrop = true;
        }

        private void fAddProductImport_Load(object sender, EventArgs e)
        {

        }

        private void bSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Excel seçimi",
                Filter = "Excell 97-2003 Workbook|.xls|Excell Workbook|*.xlsx",
                FilterIndex = 2,
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tFilePath.Text = openFileDialog.FileName;
                    _workbook = LoadWorkbook(openFileDialog.FileName);

                    if (_workbook != null)
                    {
                        var sheets = _workbook.Tables
                            .Cast<DataTable>()
                            .Select(t => t.TableName)
                            .ToList();

                        lookSheet.Enabled = true;
                        lookSheet.Properties.DataSource = sheets;
                        lookSheet.Properties.DropDownRows = sheets.Count > 7 ? 7 : sheets.Count;
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private DataSet LoadWorkbook(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
                return reader.AsDataSet(new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                });
        }

        private void tFilePath_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            tFilePath.Clear();
            lookSheet.Enabled = false;
            bSetting.Visible = false;
            tFilePath.Properties.Buttons[0].Visible = false;
            lookSheet.Properties.DataSource = null;
        }

        private void lookSheet_EditValueChanged(object sender, EventArgs e)
        {
            string selectedSheet = lookSheet.EditValue?.ToString();
            if (!string.IsNullOrEmpty(selectedSheet))
            {
                DataTable data = _workbook.Tables[selectedSheet];
                if (data != null)
                {
                    _invoices.Clear();
                    _invoices = MapDataTableToList(data);

                    gridControlImport.DataSource = _invoices;
                    gridImport.OptionsView.ShowColumnHeaders = true;
                    gridImport.BestFitColumns();
                }
            }
        }

        private List<ProductInvoiceImportDto> MapDataTableToList(DataTable dt)
        {
            var list = new List<ProductInvoiceImportDto>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ProductInvoiceImportDto
                {
                    Type = row["Məhsul tipi"]?.ToString(),
                    WarehouseName = row["Anbar adı"]?.ToString(),
                    SupplierName = row["Təchizatçı adı"]?.ToString(),
                    InvoiceDate = GetDate(row, "Faktura tarixi"),
                    InvoiceNo = row["Faktura nömrəsi"].ToString(),
                    CategoryName = row["Kateqoriya adı"]?.ToString(),
                    ProductName = row["Məhsul adı"]?.ToString(),
                    ProductCode = row["Məhsul kodu"].ToString(),
                    Barcode = row["Barkod"]?.ToString(),
                    Quantity = GetDecimal(row, "Miqdar"),
                    PurchasePrice = GetDecimal(row, "Alış qiyməti"),
                    SalePrice = GetDecimal(row, "Satış qiyməti"),
                    UnitName = row["Vahid"]?.ToString(),
                    TaxName = row["Vergi dərəcəsi"]?.ToString()
                });
            }

            return list;
        }

        private static decimal GetDecimal(DataRow row, string col, decimal def = 0)
        {
            return row.Table.Columns.Contains(col) && row[col] != DBNull.Value
                ? Convert.ToDecimal(row[col])
                : def;
        }

        private static DateTime? GetDate(DataRow row, string col, DateTime? def = null)
        {
            return row.Table.Columns.Contains(col) && row[col] != DBNull.Value
                ? Convert.ToDateTime(row[col])
                : def;
        }

        private void gridImport_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view.RowCount != 0) return;

            StringFormat drawFormat = new StringFormat();

            drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString("Məlumat tapılmadı", e.Appearance.Font, SystemBrushes.ControlDark,
                new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);
            gridImport.OptionsView.ShowColumnHeaders = false;
        }

        private void bImport_Click(object sender, EventArgs e)
        {
            InsertDbProducts();
        }

        private Dictionary<string, Warehouse> warehouseCache;
        private Dictionary<string, Supplier> supplierCache;
        private Dictionary<string, Category> categoryCache;
        private Dictionary<(string productName, string barcode), Product> productCache;
        private Dictionary<string, UnitType> unitTypeCache;
        private Dictionary<string, TaxType> taxTypeCache;

        private async void InsertDbProducts()
        {
            using (var db = new KhanposDbEntities())
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var warehouses = db.Warehouses.ToList();
                    var suppliers = db.Suppliers.ToList();
                    var categories = db.Categories.Where(x => x.IsDeleted == false).ToList();
                    var products = db.Products.ToList();
                    var unitTypes = db.UnitTypes.ToList();
                    var taxTypes = db.TaxTypes.ToList();
                    var existingInvoices = db.Invoices.ToList();

                    warehouseCache = warehouses.ToDictionary(x => x.Name.ToLower(), x => x);
                    supplierCache = suppliers.ToDictionary(x => x.SupplierName.ToLower(), x => x);
                    categoryCache = categories.ToDictionary(x => x.CategoryName.ToLower(), x => x);
                    productCache = products.ToDictionary(x => (x.ProductName.ToLower(), x.Barcode), x => x);
                    unitTypeCache = unitTypes.ToDictionary(x => x.Name.ToLower(), x => x);
                    taxTypeCache = taxTypes.ToDictionary(x => x.Name.ToLower(), x => x);

                    var invoiceCache = existingInvoices
                        .Where(x => !string.IsNullOrEmpty(x.InvoiceNo))
                        .GroupBy(x => x.InvoiceNo.ToLower())
                        .ToDictionary(g => g.Key, g => g.First());

                    List<Invoice> invoiceList = new List<Invoice>();
                    List<InvoiceDetail> invoiceDetailList = new List<InvoiceDetail>();

                    string invoiceNo = null;
                    foreach (var row in _invoices)
                    {
                        if (!warehouseCache.TryGetValue(row.WarehouseName.ToLower(), out var warehouse))
                        {
                            warehouse = await AddWarehouse(row.WarehouseName);

                            //var dialog = NotificationHelpers.Dialogs.DialogResultYesNo($"{row.WarehouseName} Anbarı yoxdur. Yenisi yaradılsınmı ?");

                            //var result = XtraMessageBox.Show(dialog);

                            //if (result is DialogResult.Yes)
                            //    warehouse = await AddWarehouse(row.WarehouseName);
                            //else
                            //{
                            //    transaction.Rollback();
                            //    NotificationHelpers.Messages.ErrorMessage(this, $"Anbar tapılmadı\nAnbar adı:{row.WarehouseName}");
                            //    return;
                            //}
                        }

                        if (!supplierCache.TryGetValue(row.SupplierName.ToLower(), out var supplier))
                        {
                            supplier = await AddSupplier(row.SupplierName);
                            //transaction.Rollback();
                            //NotificationHelpers.Messages.ErrorMessage(this, $"Təchizatçı tapılmadı\nTəchizatçı adı: {row.SupplierName}");

                            //return;
                        }

                        if (!categoryCache.TryGetValue(row.CategoryName.ToLower(), out var category))
                        {
                            category = await AddCategory(row.CategoryName);

                            //transaction.Rollback();
                            //NotificationHelpers.Messages.ErrorMessage(this, $"Kateqoriya tapılmadı\nKateqoriya adı: {row.CategoryName}");
                            //return;
                        }

                        if (!unitTypeCache.TryGetValue(row.UnitName.ToLower(), out var unitType))
                        {
                            transaction.Rollback();
                            NotificationHelpers.Messages.ErrorMessage(this, $"Vahid növü tapılmadı\nVahidin adı: {row.UnitName}");
                            return;
                        }

                        if (!taxTypeCache.TryGetValue(row.TaxName.ToLower(), out var taxType))
                        {
                            transaction.Rollback();
                            NotificationHelpers.Messages.ErrorMessage(this, $"Vergi növü tapılmadı\nVergi növünün adı: {row.TaxName}");
                            return;
                        }

                        if (!productCache.TryGetValue((row.ProductName.ToLower(), row.Barcode), out var product))
                        {
                            product = await AddProduct(category.Id, row.ProductName, row.ProductCode, row.Barcode, row.PurchasePrice,
                                 row.SalePrice, unitType.Id, taxType.Id);
                        }

                        if (!invoiceCache.TryGetValue(row.InvoiceNo.ToLower(), out var invoice))
                        {
                            invoice = new Invoice
                            {
                                InvoiceNo = row.InvoiceNo,
                                InvoiceDate = row.InvoiceDate.Value,
                                SupplierId = supplier.Id,
                                WarehouseId = warehouse.Id,
                                TotalPurchasePrice = 0,
                                UserId = UserCacheService.User.Id,
                                CreatedDate = DatetimeService.CurrentDateTime,
                                IsDeleted = false,
                            };

                            db.Invoices.Add(invoice);
                            db.SaveChanges(); // invoice.Id-ni almaq üçün lazımdır (əgər Identity-dirsə)

                            invoiceCache[row.InvoiceNo.ToLower()] = invoice;
                            invoiceList.Add(invoice);
                        }

                        var invoiceDetail = new InvoiceDetail
                        {
                            InvoiceId = invoice.Id,
                            ProductId = product.Id,
                            Amount = row.Quantity,
                            PurchasePrice = row.PurchasePrice,
                            Discount = 0,
                            TotalPurchasePrice = row.Quantity * row.PurchasePrice,
                            SalePrice = row.SalePrice,
                        };

                        invoice.TotalPurchasePrice += row.PurchasePrice * row.Quantity;

                        invoiceDetailList.Add(invoiceDetail);
                    }

                    db.InvoiceDetails.AddRange(invoiceDetailList);
                    if (await db.SaveChangesAsync() > 0)
                        await UpdateProducts(db, invoiceDetailList);

                    NotificationHelpers.Messages.SuccessMessage(this,"Məhsullar uğurla əlavə edildi");
                    gridControlImport.DataSource = null;
                    lookSheet.SelectedText = null;
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        private async Task<Warehouse> AddWarehouse(string name)
        {
            IWarehouseOperation warehouseOperation = new WarehouseManager();
            var warehouse = new Warehouse
            {
                Name = name,
                IsDeleted = false,
                Status = true
            };

            var result = await warehouseOperation.Add(warehouse);
            if (result > 0)
            {
                warehouseCache[name.ToLower()] = warehouse; // cache-i yenilə!
                return warehouse;
            }

            return null;
        }

        private async Task<Supplier> AddSupplier(string name)
        {
            ISupplierOperation supplierOperation = new SupplierManager();

            var supplier = new Supplier
            {
                SupplierName = name,
                Debt = 0,
                Status = true,
                IsDeleted = false
            };

            var result = await supplierOperation.Add(supplier);
            if (result > 0)
            {
                supplierCache[name.ToLower()] = supplier;
                return supplier;
            }

            return null;
        }

        private async Task<Category> AddCategory(string name)
        {
            ICategoryOperation categoryOperation = new CategoryManager();
            var category = new Category
            {
                CategoryName = name,
                Status = true,
                IsDeleted = false
            };

            var result = await categoryOperation.Add(category);
            if (result > 0)
            {
                categoryCache[name.ToLower()] = category;
                return category;
            }
            return null;
        }

        private async Task UpdateProducts(KhanposDbEntities context, List<InvoiceDetail> details)
        {
            IProductOperation productOperation = new ProductManager(context);

            List<Product> products = new List<Product>();

            foreach (var item in details)
            {
                if (item.Product is null)
                    item.Product = await productOperation.Get(x => x.Id == item.ProductId);

                item.Product.Quantity += item.Amount;
                item.Product.PurchasePrice = item.PurchasePrice;
                item.Product.SalePrice = item.SalePrice;
                products.Add(item.Product);
            }

            await productOperation.Update(products,
                 x => x.Quantity,
                 x => x.PurchasePrice,
                 x => x.SalePrice);
        }

        private async Task<Product> AddProduct(int categoryId, string productName, string productCode, string barcode, decimal purchasePrice, decimal salePrice,
            int unitId, int taxId)
        {
            IProductOperation productOperation = new ProductManager();
            var product = new Product
            {
                Type = 1,
                CategoryId = categoryId,
                ProductName = productName,
                ProductCode = productCode,
                Barcode = barcode,
                Quantity = 0,
                PurchasePrice = purchasePrice,
                SalePrice = salePrice,
                UnitId = unitId,
                TaxId = taxId,
                IsActive = true,
                CreatedUserId = UserCacheService.User.Id,
                CreatedDate = DatetimeService.CurrentDateTime,
                IsDeleted = false,
                CanEditSalePrice = true,
                CanSellWithoutStock = true,
                CanApplyDiscount = true,
                CanHotSaleProduct = true
            };

            var result = await productOperation.Add(product);
            if (result > 0)
            {
                productCache[(productName, barcode)] = product;
                return product;
            }

            return null;
        }

        private void bDownloadTemplate_Click(object sender, EventArgs e)
        {
            string sourcePath = Path.Combine(Application.StartupPath, "Documents", "Invoices_Demo.xlsx");
            if (!File.Exists(sourcePath))
            {
                NotificationHelpers.Messages.ErrorMessage(this, "Excel faylı tapılmadı");
                return;
            }

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.FileName = $"Invoices_{DatetimeService.CurrentDateString}.xlsx";
                saveFile.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFile.Title = "Sənədi yüklə";
                if (saveFile.ShowDialog() is DialogResult.OK)
                {
                    try
                    {
                        File.Copy(sourcePath, saveFile.FileName, true);
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = saveFile.FileName,
                            UseShellExecute = true
                        });
                    }
                    catch (IOException)
                    {
                        NotificationHelpers.Messages.WarningMessage(this, "Seçilmiş Excel faylı hazırda açıqdır. Zəhmət olmasa faylı bağlayıb yenidən cəhd edin.");
                    }
                    catch (Exception ex)
                    {
                        NotificationHelpers.Messages.ErrorMessage(this, $"Xəta.\n {ex.Message}");
                    }
                }
            }
        }
    }
}