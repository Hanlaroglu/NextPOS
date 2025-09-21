using Barcode_Sales.Barcode.Sales.UI;
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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static Barcode_Sales.Helpers.Enums;

namespace Barcode_Sales.Forms
{
    public partial class fAddProduct : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        ISupplierOperation supplierOperation = new SupplierManager();
        IUnitTypeOperation unitTypeOperation = new UnitTypeManager();
        ITaxTypeOperation taxTypeOperation = new TaxTypeManager();
        ICategoryOperation categoryOperation = new CategoryManager();
        IProductOperation productOperation = new ProductManager();


        private Operation Operation { get; }
        private Products Product { get; set; }
        private BindingList<GridData> dataList = new BindingList<GridData>();

        public fAddProduct(Operation _operation, Products _product = null)
        {
            InitializeComponent();
            Operation = _operation;
            Product = _product;
        }

        private async void fAddProduct_Load(object sender, EventArgs e)
        {
            #region Mask

            //tPurchasePrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            //tPurchasePrice.Properties.Mask.EditMask = "f2";
            //tPurchasePrice.Properties.Mask.UseMaskAsDisplayFormat = true;

            //tSalesPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            //tSalesPrice.Properties.Mask.EditMask = "f2";
            //tSalesPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            #endregion Mask


            ClearProduct();
            await UnitDataLoad();
            await TaxDataLoad();
            await SupplierDataLoad();
            await CategoryDataLoad();
            gridControlProducts.DataSource = dataList;
        }

        private async Task UnitDataLoad()
        {
            var data = await unitTypeOperation.WhereAsync();
            FormHelpers.ControlLoad(data, lookUnit);
            lookUnit.EditValue = 0;
        }

        private async Task TaxDataLoad()
        {
            var data = await taxTypeOperation.WhereAsync(null);
            FormHelpers.ControlLoad(data, lookTax);
        }

        private async Task SupplierDataLoad()
        {
            var data = await supplierOperation.WhereAsync(x => x.IsDeleted == 0);
            FormHelpers.ControlLoad(data, lookSuppliers, "SupplierName");
        }

        private async Task CategoryDataLoad()
        {
            var data = await categoryOperation.WhereAsync(x => x.IsDeleted == 0 && x.Status == true);
            FormHelpers.ControlLoad(data, lookCategory, "CategoryName");
        }

        private async void bAddProduct_Click(object sender, EventArgs e)
        {
            if (Operation is Enums.Operation.Add)
            {
                await AddProduct();
            }
            else if (Operation is Enums.Operation.Edit)
            {
                //EditProduct();
            }
        }

        //private void EditProduct()
        //{
        //    Product.CategoryId = (int)lookCategory.EditValue;
        //    Product.ProductName = tProductName.Text;
        //    Product.Barcode = tBarcode.Text;
        //    Product.ProductCode = tProductCode.Text;
        //    Product.PurchasePrice = ParseHelpers.GetConvertStringToDouble(tPurchasePrice.EditValue.ToString());
        //    Product.SalePrice = ParseHelpers.GetConvertStringToDouble(tSalesPrice.EditValue.ToString());
        //    Product.UnitId = lookUnit.EditValue == null ? 0 : (int)lookUnit.EditValue;
        //    Product.TaxId = lookTax.EditValue == null ? 0 : (int)lookTax.EditValue;
        //    productOperation.Update(Product);
        //    DialogResult = DialogResult.OK;
        //}

        short rowNo = 1;
        private void ProductAddGrid()
        {
            GridData grid = new GridData();
            grid.No = rowNo;
            grid.SupplierName = lookSuppliers.Text;
            grid.Category = lookCategory.Text;
            grid.ProductName = tProductName.Text.Trim();
            grid.Barcode = tBarcode.Text.Trim();
            grid.UnitName = lookUnit.Text;
            grid.TaxName = lookTax.Text;
            grid.PurchasePrice = Double.Parse(tPurchasePrice.EditValue.ToString());
            grid.SalePrice = Double.Parse(tSalesPrice.EditValue.ToString());

            dataList.Add(grid);
            rowNo++;

        }

        private async Task AddProduct()
        {
            Product = new Products();
            Product.Type = (byte)ProductType.Product;
            Product.SupplierId = lookSuppliers.EditValue == null ? 0 : (int)lookSuppliers.EditValue;
            Product.ProductName = tProductName.Text.Trim();
            Product.CategoryId = lookCategory.EditValue == null ? 0 : (int)lookCategory.EditValue;
            Product.Barcode = tBarcode.Text.Trim();
            Product.Amount = 0;
            Product.PurchasePrice = Double.Parse(tPurchasePrice.EditValue.ToString());
            Product.SalePrice = Double.Parse(tSalesPrice.EditValue.ToString());
            Product.UnitId = lookUnit.EditValue == null ? 0 : (int)lookUnit.EditValue;
            Product.TaxId = lookTax.EditValue == null ? 0 : (int)lookTax.EditValue;
            Product.ProductCode = string.IsNullOrWhiteSpace(tProductCode.Text) ? null : tProductCode.Text.Trim();
            Product.Status = true;
            Product.IsDeleted = 0;
            Product.CreatedDate = DateTime.Now;
            Product.CreatedUserId = 3;

            var barcodeCheck = await productOperation.BarcodeCheckAsync(Product.Barcode, (int)Product.SupplierId);
            if (barcodeCheck)
            {
                NoticationHelpers.Messages.InfoMessage(this, "Daxil edilən barkod sistemdə mövcuddur");
                return;
            }

            var validator = ValidationHelpers.ValidateMessage(Product, new ProductValidation(), this);

            if (!validator.IsValid)
            {
                return;
            }

            productOperation.Add(Product);
            ProductAddGrid();
            ClearProduct();
        }

        private void ClearProduct()
        {
            tProductName.Text = null;
            tBarcode.Text = null;
            tProductCode.Text = null;
            tPurchasePrice.EditValue = CommonData.DEFAULT_INT_TOSTRING;
            tSalesPrice.Text = CommonData.DEFAULT_INT_TOSTRING;
            tProductName.Focus();
        }

        private void tBarcode_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            tBarcode.Text = FormHelpers.ConvertToEAN13(Guid.NewGuid());
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            ClearProduct();
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

        private void bAddSupplier_Click(object sender, EventArgs e)
        {
            NoticationHelpers.Dialogs.DialogResultYesNo("test");
        }

        private void bAddCategory_Click(object sender, EventArgs e)
        {
            fAddCategory f = new fAddCategory(Operation.Add, null);
            f.FormClosed += async (s, args) =>
            {
                await CategoryDataLoad();
            };
            f.ShowDialog();
        }

        private class GridData
        {
            public short No { get; set; }
            public string SupplierName { get; set; }
            public string ProductName { get; set; }
            public string Category { get; set; }
            public string Barcode { get; set; }
            public string UnitName { get; set; }
            public string TaxName { get; set; }
            public double PurchasePrice { get; set; }
            public double SalePrice { get; set; }
        }


    }
}