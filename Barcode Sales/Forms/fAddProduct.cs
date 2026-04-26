using Barcode_Sales.DTOs;
using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Services.CacheServices;
using Barcode_Sales.Validations;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fAddProduct : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        IUnitTypeOperation unitTypeOperation = new UnitTypeManager();
        ITaxTypeOperation taxTypeOperation = new TaxTypeManager();
        ICategoryOperation categoryOperation = new CategoryManager();
        IProductOperation productOperation = new ProductManager();


        private Enums.Operation _operation { get; }
        private Products _product { get; set; }
        private string _barcode { get; set; }

        private BindingList<ProductInvoiceDto> dataList = new BindingList<ProductInvoiceDto>();

        public fAddProduct(Enums.Operation operation, Products product = null)
        {
            InitializeComponent();
            _operation = operation;
            _product = product;
            _barcode = product?.Barcode;
        }

        private void fAddProduct_Load(object sender, EventArgs e)
        {
            #region Mask

            //tPurchasePrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            //tPurchasePrice.Properties.Mask.EditMask = "f2";
            //tPurchasePrice.Properties.Mask.UseMaskAsDisplayFormat = true;

            //tSalesPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            //tSalesPrice.Properties.Mask.EditMask = "f2";
            //tSalesPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            #endregion Mask


            Clear();
            
            gridControlProducts.DataSource = dataList;
        }

        private async void fAddProduct_Shown(object sender, EventArgs e)
        {
            await UnitDataLoad();
            await TaxDataLoad();
            await CategoryDataLoad();

            if (_operation == Enums.Operation.Edit)
                ProductDataLoad();
        }

        private void ProductDataLoad()
        {
            tProductName.Text = _product.ProductName;
            lookCategory.EditValue = _product.CategoryId;
            tBarcode.Text = _product.Barcode;
            tQuantity.Enabled = false;
            tPurchasePrice.EditValue = _product.PurchasePrice;
            tSalePrice.EditValue = _product.SalePrice;
            lookUnit.EditValue = _product.UnitId;
            lookTax.EditValue = _product.TaxId;
            tProductCode.Text = _product.ProductCode;
            chEditSalePrice.Checked = _product.CanEditSalePrice;
            chSellWithoutStock.Checked = _product.CanSellWithoutStock;
            chApplyDiscount.Checked = _product.CanApplyDiscount;
        }

        private async Task UnitDataLoad()
        {
            var data = await unitTypeOperation.ToListAsync();
            FormHelpers.ControlLoad(data, lookUnit);
            lookUnit.EditValue = 0;
        }

        private async Task TaxDataLoad()
        {
            var data = await taxTypeOperation.ToListAsync();
            FormHelpers.ControlLoad(data, lookTax);
        }

        private async Task CategoryDataLoad()
        {
            var data = await categoryOperation.ToListAsync(x => x.IsDeleted == false && x.Status == true);
            FormHelpers.ControlLoad(data, lookCategory, "CategoryName");
        }

        private void bAddProduct_Click(object sender, EventArgs e)
        {
            if (_operation is Enums.Operation.Add)
                Add();
        }

        private async void Add()
        {
            _product = new Products();
            _product.Type = (byte)Enums.ProductType.Product;
            _product.ProductName = tProductName.Text.Trim();
            _product.CategoryId = lookCategory.EditValue == null ? 0 : (int)lookCategory.EditValue;
            _product.Barcode = tBarcode.Text.Trim();
            _product.Quantity = Convert.ToDecimal(tQuantity.EditValue);
            _product.PurchasePrice = Convert.ToDecimal(tPurchasePrice.EditValue);
            _product.SalePrice = Convert.ToDecimal(tSalePrice.EditValue);
            _product.UnitId = lookUnit.EditValue == null ? 0 : (int)lookUnit.EditValue;
            _product.TaxId = lookTax.EditValue == null ? 0 : (int)lookTax.EditValue;
            _product.ProductCode = string.IsNullOrWhiteSpace(tProductCode.Text) ? null : tProductCode.Text.Trim();
            _product.CanEditSalePrice = chEditSalePrice.Checked;
            _product.CanSellWithoutStock = chSellWithoutStock.Checked;
            _product.CanApplyDiscount = chApplyDiscount.Checked;
            _product.IsActive = true;
            _product.IsDeleted = false;
            _product.CreatedDate = DateTime.Now;
            _product.CreatedUserId = UserCacheService.User.Id;

            var barcodeCheck = await productOperation.Get(x => x.Barcode == _product.Barcode);
            if (barcodeCheck != null)
            {
                NotificationHelpers.Messages.InfoMessage(this, "Daxil edilən barkod sistemdə mövcuddur");
                return;
            }

            var validator = ValidationHelpers.ValidateMessage(_product, new ProductValidation(), this);

            if (!validator.IsValid)
            {
                return;
            }

            var resultProductId = await productOperation.Add(_product);

            if (resultProductId > 0)
            {
                ProductAddGrid(resultProductId);
                Clear();
            }
        }

        private async void Edit()
        {
            _product.ProductName = tProductName.Text.Trim();
            _product.CategoryId = (int)lookCategory.EditValue;
            _product.Barcode = tBarcode.Text.TrimStart().Trim();
            _product.PurchasePrice = Convert.ToDecimal(tPurchasePrice.EditValue);
            _product.SalePrice = Convert.ToDecimal(tSalePrice.EditValue);
            _product.UnitId = lookUnit.EditValue == null ? 0 : (int)lookUnit.EditValue;
            _product.TaxId = lookTax.EditValue == null ? 0 : (int)lookTax.EditValue;
            _product.ProductCode = string.IsNullOrWhiteSpace(tProductCode.Text) ? null : tProductCode.Text.Trim();
            _product.CanEditSalePrice = chEditSalePrice.Checked;
            _product.CanSellWithoutStock = chSellWithoutStock.Checked;
            _product.CanApplyDiscount = chApplyDiscount.Checked;

            if (_barcode != tBarcode.Text.TrimStart().Trim())
            {
                var barcodeCheck = await productOperation.Get(x => x.Barcode == _product.Barcode);
                if (barcodeCheck != null)
                {
                    NotificationHelpers.Messages.InfoMessage(this, "Daxil edilən barkod sistemdə mövcuddur");
                    return;
                }
            }

            var validator = ValidationHelpers.ValidateMessage(_product, new ProductValidation(), this);

            if (!validator.IsValid)
            {
                return;
            }
            
            var resultUpdate = await productOperation.Update(_product, 
                x=> x.ProductName,
                x=> x.CategoryId,
                x=> x.Barcode,
                x=> x.PurchasePrice,
                x=> x.SalePrice,
                x=> x.UnitId,
                x=> x.TaxId,
                x=> x.ProductCode,
                x=> x.CanEditSalePrice,
                x=> x.CanSellWithoutStock,
                x=> x.CanApplyDiscount);

            if (resultUpdate)
            {
                Clear();
                NotificationHelpers.Messages.SuccessMessage(this, "Uğurla düzəliş edildi");
            }
        }

        private void ProductAddGrid(int productId)
        {
            ProductInvoiceDto grid = new ProductInvoiceDto();
            grid.Id = productId;
            grid.Category = lookCategory.Text;
            grid.ProductName = tProductName.Text.Trim();
            grid.Barcode = tBarcode.Text.Trim();
            grid.UnitName = lookUnit.Text;
            grid.TaxName = lookTax.Text;
            grid.PurchasePrice = Decimal.Parse(tPurchasePrice.EditValue.ToString());
            grid.SalePrice = Decimal.Parse(tSalePrice.EditValue.ToString());
            dataList.Add(grid);
        }

        private void Clear()
        {
            tProductName.Text = null;
            lookCategory.SelectedText = null; 
            tBarcode.Text = null;
            tProductCode.Text = null;
            tPurchasePrice.EditValue = 0;
            tSalePrice.EditValue = 0;
            tProductName.Focus();
        }

        private void tBarcode_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            tBarcode.Text = ConvertToEAN13();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            Clear();
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
            fSupplier f = new fSupplier(Enums.Operation.Add, null);
            //f.FormClosed += async (s, args) =>
            //{
            //    await SupplierDataLoad();
            //};
            f.ShowDialog();
        }

        private void bAddCategory_Click(object sender, EventArgs e)
        {
            fAddCategory f = new fAddCategory(Enums.Operation.Add, null);
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

        private void bSave_Click(object sender, EventArgs e)
        {
            if (_operation is Enums.Operation.Add)
                Add();
            else
                Edit();


            //if (bSave.Cursor == Cursors.No)
            //    return;

            //this.Hide();
            //FormHelpers.OpenForm<fInvoiceProduct>(dataList);
        }

        private void fAddProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            //var dialog = NotificationHelpers.Dialogs.DialogResultYesNo("Səhifədən çıxış etmək istədiyinizə əminsiniz ?", "Xəbərdarlıq");
            //var result = XtraMessageBox.Show(dialog);
            //if (result is DialogResult.No)
            //    e.Cancel = true;
        }

        private string ConvertToEAN13()
        {
            string guidString = Guid.NewGuid().ToString("N");
            string barcodeContent = new String(guidString.Where(Char.IsDigit).ToArray());
            barcodeContent = barcodeContent.Substring(0, Math.Min(barcodeContent.Length, 9));

            int sum = barcodeContent.Select((c, index) => int.Parse(c.ToString()) * (index % 2 == 0 ? 1 : 3)).Sum();
            int checksum = (10 - (sum % 10)) % 10;

            barcodeContent += checksum.ToString();

            return $"994{barcodeContent}";
        }

        private void bProducts_Click(object sender, EventArgs e)
        {
            fSelectedProduct f = new fSelectedProduct();
            f.ShowDialog();
        }
    }
}