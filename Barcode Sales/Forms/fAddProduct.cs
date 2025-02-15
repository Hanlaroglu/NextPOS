using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using NextPOS.UserControls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fAddProduct : FormBase
    {
        NextposDBEntities db = new NextposDBEntities();

        IProductOperation productOperation = new ProductManager();
        private Enums.Operation Operation { get; }
        private Products Product { get; set; }
        private BindingList<GridData> dataList;
        short rowNo = 1;
        private byte[] imageBytes;

        public fAddProduct(Enums.Operation _operation, Products _product = null)
        {
            InitializeComponent();
            Operation = _operation;
            Product = _product;
        }

        private void chType_CheckedChanged(object sender, EventArgs e)
        {
            if (chType.Checked)
            {
                chType.Text = "Məhsul";
                groupProduct.Text = "Məhsul məlumatları";
            }
            else
            {
                chType.Text = "Xidmət";
                groupProduct.Text = "Xidmət məlumatları";
            }
        }

        void UnitDataLoad()
        {
            var unitTypes = Enum.GetValues(typeof(Enums.UnitTypes))
                                .Cast<Enums.UnitTypes>()
                                .ToDictionary(e => e, e => Enums.GetEnumDescription(e));

            FormHelpers.ControlLoad(new BindingSource(unitTypes, null), lookUnit, "Value", "Key");
        }

        void TaxDataLoad()
        {
            var taxTypes = Enum.GetValues(typeof(Enums.TaxTypes))
                               .Cast<Enums.TaxTypes>()
                               .ToDictionary(e => e, e => Enums.GetEnumDescription(e));

            FormHelpers.ControlLoad(new BindingSource(taxTypes, null), lookTax, "Value", "Key");
        }

        void ColorDataLoad()
        {
            var data = db.Colors.AsNoTracking()
                                .Where(x => x.IsDeleted == CommonData.DEFAULT_INT)
                                .Select(x => new
                                {
                                    x.ColorName
                                }).ToList();

            FormHelpers.ControlLoad(data, lookColors, "ColorName", null);
        }

        void WarehouseDataLoad()
        {
            if (db.Warehouses.AsNoTracking().Any())
            {

                var data = db.Warehouses.AsNoTracking()
                                        .Where(x => x.IsDeleted == CommonData.DEFAULT_INT)
                                        .Select(x => new
                                        {
                                            x.Name
                                        })
                                        .ToList();

                FormHelpers.ControlLoad(data, lookWarehouse, "Name", null);
                lookWarehouse.ShowPopup();
                lookWarehouse.ItemIndex = 0;
            }
        }

        void SizeDataLoad()
        {
            var data = db.Sizes.AsNoTracking()
                                .Where(x => x.IsDeleted == CommonData.DEFAULT_INT)
                                .Select(x => new
                                {
                                    x.SizeName
                                }).ToList();

            FormHelpers.ControlLoad(data, lookSizes, "SizeName", null);
        }

        private void bAddProduct_Click(object sender, EventArgs e)
        {
            if (Operation is Enums.Operation.Add)
            {
                ProductAddGrid();
            }
            else if (Operation is Enums.Operation.Edit)
            {
                EditProduct();
            }
        }

        void EditProduct()
        {
            Product.Type = chType.Text;
            Product.CategoryID = GetCategoryId(tCategory.Text);
            Product.ProductName = tProductName.Text;
            Product.Barcode = tBarcode.Text;
            Product.ProductCode = tProductCode.Text;
            Product.PurchasePrice = ParseHelpers.GetConvertStringToDouble(tPurchasePrice.EditValue.ToString());
            Product.SalePrice = ParseHelpers.GetConvertStringToDouble(tSalesPrice.EditValue.ToString());
            Product.Unit = lookUnit.Text;
            Product.Tax = lookTax.Text;
            Product.ColorID = GetColorId(lookColors.Text);
            Product.SizeID = GetSizeId(lookSizes.Text);
            Product.CreateDate = ParseHelpers.StringConvertDatetime(tCreatedDate.EditValue.ToString());
            Product.FinisDate = ParseHelpers.StringConvertDatetime(tEndDate.EditValue.ToString());
            Product.Comment = tComment.Text;
            Product.ShowPosScreen = chPOSShowSales.Checked;
            Product.AmountNotification = chAmountNotification.Checked;
            Product.EndDateNotification = chProductEndDateNotification.Checked;
            Product.Image = imageBytes;

            productOperation.Update(Product);
            DialogResult = DialogResult.OK;
        }

        void ProductAddGrid()
        {
            try
            {
                if (GetExistsBarcode(tBarcode.Text.Trim()))
                {
                    Message("Daxil edilən barkod sistemdə mövcuddur",fMessage.enmType.Warning);
                    return;
                }


                DateTime? ProductCreatedDate = ParseHelpers.StringConvertDatetime(tCreatedDate.EditValue.ToString());
                DateTime? ProductEndDate = ParseHelpers.StringConvertDatetime(tEndDate.EditValue.ToString());

                if (ProductCreatedDate == DateTime.MinValue)
                {
                    ProductCreatedDate = null;
                }
                if (ProductEndDate == DateTime.MinValue)
                {
                    ProductEndDate = null;
                }

                double amount = default;
                if (chType.Checked)
                    amount = 0;
                else
                    amount = 100000;


                GridData grid = new GridData();
                grid.No = rowNo;
                grid.Category = tCategory.Text;
                grid.ProductName = tProductName.Text;
                grid.ProductCode = tProductCode.Text;
                grid.Barcode = tBarcode.Text;
                grid.UnitName = lookUnit.Text;
                grid.TaxName = lookTax.Text;
                grid.ColorName = lookColors.Text;
                grid.SizeName = lookSizes.Text;
                grid.ProductCreatedDate = ProductCreatedDate;
                grid.ProductEndDate = ProductEndDate;
                grid.Comment = tComment.Text;
                grid.Type = chType.Text;
                grid.Amount = amount;
                grid.PurchasePrice = Double.Parse(tPurchasePrice.Text);
                grid.SalePrice = Double.Parse(tSalesPrice.Text);
                grid.ShowPosScreen = chPOSShowSales.Checked;
                grid.AmountNotification = chAmountNotification.Checked;
                grid.EndDateNotification = chProductEndDateNotification.Checked;
                grid.Imagebyte = imageBytes;



                Products validateProduct = GridDataToProductsMapper(grid);

                var validator = ValidationHelpers.ValidateMessage(validateProduct, new ProductValidation(), this);

                if (!validator.IsValid)
                {
                    return;
                }

                dataList.Add(grid);
                rowNo++;
                ClearProduct();
            }
            catch (Exception e)
            {
                CommonMessageBox.ErrorMessageBox(e.Message);
            }
        }

        bool GetExistsBarcode(string barcode)
        {
            return db.Products.AsNoTracking()
                              .Where(x => x.IsDeleted == CommonData.DEFAULT_INT)
                              .Any(x=> x.Barcode == barcode);
        }

        private class GridData
        {
            public short No { get; set; }
            public string Warehouses { get; set; } = "MƏRKƏZİ ANBAR";
            public string Category { get; set; }
            public string ProductName { get; set; }
            public string ProductCode { get; set; }
            public string Barcode { get; set; }
            public string UnitName { get; set; }
            public string TaxName { get; set; }
            public string ColorName { get; set; }
            public string SizeName { get; set; }
            public DateTime? ProductCreatedDate { get; set; }
            public DateTime? ProductEndDate { get; set; }
            public string Comment { get; set; }
            public string Type { get; set; }
            public double Amount { get; set; }
            public double PurchasePrice { get; set; }
            public double SalePrice { get; set; }
            public bool ShowPosScreen { get; set; }
            public bool AmountNotification { get; set; }
            public bool EndDateNotification { get; set; }
            public byte[] Imagebyte { get; set; }

        }

        void AddProduct()
        {
            for (int i = 0; i < gridProducts.RowCount; i++)
            {
                if (gridProducts.IsValidRowHandle(i))
                {
                    byte[] image = (byte[])gridProducts.GetRowCellValue(i, colImage);
                    int categoryID = GetCategoryId(gridProducts.GetRowCellValue(i, colCategory).ToString());
                    int? colorID = GetColorId(gridProducts.GetRowCellValue(i, colColor).ToString());
                    int? sizeID = GetSizeId(gridProducts.GetRowCellValue(i, colSize).ToString());

                    Product = new Products();

                    Product.Type = gridProducts.GetRowCellValue(i, colType).ToString();
                    Product.WarehousesID = 1;
                    Product.StoreID = 1;
                    Product.CategoryID = categoryID;
                    Product.ProductName = gridProducts.GetRowCellValue(i, colProductName).ToString();
                    Product.ProductCode = gridProducts.GetRowCellValue(i, colCode).ToString();
                    Product.Barcode = gridProducts.GetRowCellValue(i, colBarcode).ToString();
                    Product.Amount = Convert.ToDouble(gridProducts.GetRowCellValue(i, colAmount).ToString());
                    Product.PurchasePrice = Convert.ToDouble(gridProducts.GetRowCellValue(i, colPurchasePrice).ToString());
                    Product.SalePrice = Convert.ToDouble(gridProducts.GetRowCellValue(i, colSalesPrice).ToString());
                    Product.Unit = gridProducts.GetRowCellValue(i, colUnit).ToString();
                    Product.Tax = gridProducts.GetRowCellValue(i, colTax).ToString();
                    Product.ColorID = colorID;
                    Product.SizeID = sizeID;
                    Product.Comment = gridProducts.GetRowCellValue(i, colComment).ToString();
                    Product.CreateDate = Convert.ToDateTime(gridProducts.GetRowCellValue(i, colCreatedDate));
                    Product.FinisDate = Convert.ToDateTime(gridProducts.GetRowCellValue(i, colEndDate));
                    Product.Image = image;
                    Product.ShowPosScreen = Convert.ToBoolean(gridProducts.GetRowCellValue(i, colShowPosScreen));
                    Product.AmountNotification = Convert.ToBoolean(gridProducts.GetRowCellValue(i, colAmountEndNotification));
                    Product.EndDateNotification = Convert.ToBoolean(gridProducts.GetRowCellValue(i, colEndDateNotification));
                    Product.Status = true;
                    Product.IsDeleted = 0;

                    productOperation.Add(Product);
                }
            }
            dataList.Clear();
            gridProducts.RefreshData();
        }

        void ClearProduct()
        {
            tProductName.Text = null;
            tBarcode.Text = null;
            tProductCode.Text = null;
            tPurchasePrice.EditValue = CommonData.DEFAULT_INT_TOSTRING;
            tSalesPrice.Text = CommonData.DEFAULT_INT_TOSTRING;
            lookUnit.EditValue = null;
            lookTax.EditValue = null;
            chPOSShowSales.Checked = false;
            lookColors.EditValue = null;
            lookSizes.EditValue = null;
            tCreatedDate.EditValue = DateTime.Now;
            tEndDate.EditValue = DateTime.Now;
            tComment.Text = null;
            chAmountNotification.Checked = false;
            chProductEndDateNotification.Checked = false;
            chPOSShowSales.Checked = false;
        }

        private void tBarcode_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            tBarcode.Text = FormHelpers.ConvertToEAN13(Guid.NewGuid());
        }
        

        private void fAddProduct_Load(object sender, EventArgs e)
        {
            #region Mask
            tCreatedDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            tCreatedDate.Properties.Mask.EditMask = "dd.MM.yyyy";
            tCreatedDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            tCreatedDate.EditValue = DateTime.Now;

            tEndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            tEndDate.Properties.Mask.EditMask = "dd.MM.yyyy";
            tEndDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            tEndDate.EditValue = DateTime.Now;

            tPurchasePrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            tPurchasePrice.Properties.Mask.EditMask = "n2";
            tPurchasePrice.Properties.Mask.UseMaskAsDisplayFormat = true;

            tSalesPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            tSalesPrice.Properties.Mask.EditMask = "n2";
            tSalesPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            #endregion Mask


            gridProducts.BestFitColumns();

            ClearProduct();
            UnitDataLoad();
            TaxDataLoad();
            ColorDataLoad();
            SizeDataLoad();
            WarehouseDataLoad();
            switch (Operation)
            {
                case Enums.Operation.Add:
                    dataList = new BindingList<GridData>();
                    gridControlProducts.DataSource = dataList;
                    break;
                case Enums.Operation.Edit:
                    GetProductDataLoad();
                    gridControlProducts.Visible = false;
                    bSendWarehouses.Visible = false;
                    bClear.Visible = false;
                    break;
                case Enums.Operation.Show:
                    GetProductDataLoad();
                    gridControlProducts.Visible = false;
                    bAddProduct.Visible = false;
                    bSendWarehouses.Visible = false;
                    bClear.Visible = false;
                    lookTax.Enabled = false;
                    lookUnit.Enabled = false;
                    lookColors.Enabled = false;
                    lookSizes.Enabled = false;
                    lookWarehouse.Enabled = false;
                    break;
            }
            this.Text = $"{tProductName.Text} / {Enums.GetEnumDescription(Operation)}";
            bAddProduct.Text = Enums.GetEnumDescription(Operation);
        }

        void GetProductDataLoad()
        {
            chType.Checked = GetProductTypeConvertStringToBool(Product.Type);
            tCategory.Text = Product.Categories.CategoryName;
            tProductName.Text = Product.ProductName;
            tBarcode.Text = Product.Barcode;
            tProductCode.Text = Product.ProductCode;
            tPurchasePrice.EditValue = Product.PurchasePrice;
            tSalesPrice.EditValue = Product.SalePrice;
            lookUnit.Text = Product.Unit;
            lookTax.Text = Product.Tax;
            chPOSShowSales.Checked = (bool)Product.ShowPosScreen;
            lookColors.Text = Product?.Colors?.ColorName;
            lookSizes.Text = Product?.Sizes?.SizeName;
            tCreatedDate.EditValue = Product?.CreateDate;
            tEndDate.EditValue = Product?.FinisDate;
            tComment.Text = Product.Comment;
            //byte[] imageByte = Product?.Image;
            //picProductImage.Image = imageByte != null ? Image.FromStream(new MemoryStream(imageByte)) : null;

        }

        bool GetProductTypeConvertStringToBool(string typeName)
        {
            if (typeName == "Məhsul")
                return true;
            else
                return false;
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            ClearProduct();
        }

        private void bSendWarehouses_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void bProductDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridProducts.GetFocusedRow() == null)
            {
                CommonMessageBox.WarningMessageBox(CommonMessages.NOT_SELECTİON);
                return;
            }
            if (CommonMessageBox.QuestionDialogResult("Seçili olan məhsulu silmək istədiyinizə əminsiniz ?"))
            {
                gridProducts.DeleteSelectedRows();
            }
        }

        private Products GridDataToProductsMapper(GridData data)
        {
            int categoryID = GetCategoryId(data.Category);
            int? colorID = GetColorId(data.ColorName);
            int? sizeID = GetSizeId(data.SizeName);
            Products product = new Products
            {
                Type = data.Type,
                WarehousesID = 1,
                StoreID = 1,
                CategoryID = categoryID,
                ProductName = data.ProductName,
                ProductCode = data.ProductCode,
                Barcode = data.Barcode,
                Amount = data.Amount,
                PurchasePrice = data.PurchasePrice,
                SalePrice = data.SalePrice,
                Unit = data.UnitName,
                Tax = data.TaxName,
                ColorID = colorID,
                SizeID = sizeID,
                Comment = data.Comment,
                CreateDate = data.ProductCreatedDate,
                FinisDate = data.ProductEndDate,
                Image = data.Imagebyte,
                ShowPosScreen = data.ShowPosScreen,
                AmountNotification = data.AmountNotification,
                EndDateNotification = data.EndDateNotification,
            };
            return product;
        }

        private int GetCategoryId(string name)
        {
            if (db.Categories.Any(x => x.CategoryName == name))
            {
                return db.Categories.AsNoTracking().FirstOrDefault(x => x.CategoryName == name).Id;
            }
            else
            {
                throw new NullReferenceException(ValidationHelpers.CategoryNotSelected);
            }
        }

        private int? GetColorId(string name)
        {
            if (db.Colors.Any(x => x.ColorName == name))
            {
                return db.Colors.AsNoTracking().FirstOrDefault(x => x.ColorName == name).Id;
            }
            else
            {
                return null;
            }
        }

        private int? GetSizeId(string name)
        {
            if (db.Sizes.Any(x => x.SizeName == name))
            {
                return db.Sizes.AsNoTracking().FirstOrDefault(x => x.SizeName == name).Id;
            }
            else
            {
                return null;
            }
        }

        private void tCategory_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            fSelected selected = new fSelected();
            if (selected.ShowDialog() is DialogResult.OK)
            {
                tCategory.Text = selected.CategoryName;

            }
        }

        private void bAddImage_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFile = new OpenFileDialog();
            //if (openFile.ShowDialog() is DialogResult.OK)
            //{
            //    picProductImage.Image = Image.FromFile(openFile.FileName);
            //    using (Stream stream = File.OpenRead(openFile.FileName))
            //    {
            //        imageBytes = new byte[stream.Length];
            //        stream.Read(imageBytes, 0, imageBytes.Length);
            //    }
            //}
            //else
            //{
            //    imageBytes = null;
            //}
        }
    }
}