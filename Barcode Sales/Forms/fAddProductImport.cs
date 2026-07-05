using Barcode_Sales.DTOs;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fAddProductImport : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _currentTable;
        private DataSet _workbook;
        List<ProductInvoiceImportDto> _invoices = new List<ProductInvoiceImportDto>();

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
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
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

        public DataSet LoadWorkbook(string filePath)
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
            bShowProducts.Visible = false;
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
                    TaxName = row["Vergi dərəcəsi"]?.ToString(),
                    IsStatus = row["Məhsul statusu"].ToString(),
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
        private Dictionary<(string productName, string barcode), Products> productCache;
        private Dictionary<string, UnitType> unitTypeCache;
        private Dictionary<string, TaxType> taxTypeCache;

        private void InsertDbProducts()
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

                    warehouseCache = warehouses.ToDictionary(x => x.Name, x => x);
                    supplierCache = suppliers.ToDictionary(x => x.SupplierName, x => x);
                    categoryCache = categories.ToDictionary(x => x.CategoryName, x => x);
                    productCache = products.ToDictionary(x => (x.ProductName, x.Barcode), x => x);
                    unitTypeCache = unitTypes.ToDictionary(x => x.Name, x => x);
                    taxTypeCache = taxTypes.ToDictionary(x => x.Name, x => x);

                    List<Supplier> supplierList = new List<Supplier>();
                    List<Category> categoryList = new List<Category>();
                    List<Products> productList = new List<Products>();

                    foreach (var row in _invoices)
                    {
                        if (!warehouseCache.TryGetValue(row.WarehouseName, out var warehouse))
                        {
                            transaction.Rollback();
                            NotificationHelpers.Messages.ErrorMessage(this, $"Anbar tapılmadı\nAnbar adı:{row.WarehouseName}");
                            return;
                        }

                        if (!supplierCache.TryGetValue(row.SupplierName, out var supplier))
                        {
                            transaction.Rollback();
                            NotificationHelpers.Messages.ErrorMessage(this, $"Təchizatçı tapılmadı\nTəchizatçı adı: {row.SupplierName}");
                            return;
                        }

                        if (!categoryCache.TryGetValue(row.CategoryName, out var category))
                        {
                            transaction.Rollback();
                            NotificationHelpers.Messages.ErrorMessage(this, $"Kateqoriya tapılmadı\nKateqoriya adı: {row.CategoryName}");
                            return;
                        }

                        if (!unitTypeCache.TryGetValue(row.UnitName, out var unitType))
                        {
                            transaction.Rollback();
                            NotificationHelpers.Messages.ErrorMessage(this, $"Vahid növü tapılmadı\nVahidin adı: {row.UnitName}");
                            return;
                        }

                        if (!taxTypeCache.TryGetValue(row.TaxName, out var taxType))
                        {
                            transaction.Rollback();
                            NotificationHelpers.Messages.ErrorMessage(this, $"Vergi növü tapılmadı\nVergi növünün adı: {row.TaxName}");
                            return;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}