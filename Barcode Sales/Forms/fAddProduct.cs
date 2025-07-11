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
    public partial class fAddProduct : FormBase
    {
        NextposDBEntities db = new NextposDBEntities();

        IWarehouseOperation warehouseOperation = new WarehouseManager();
        ICategoryOperation categoryOperation = new CategoryManager();
        IProductOperation productOperation = new ProductManager();
        ITaxTypeOperation taxTypeOperation = new TaxTypeManager();



        private Enums.Operation Operation { get; }
        private Products Product { get; set; }
        private BindingList<GridData> dataList = new BindingList<GridData>();
        private byte[] imageBytes;

        public fAddProduct(Enums.Operation _operation, Products _product = null)
        {
            InitializeComponent();
            Operation = _operation;
            Product = _product;
        }

        private async void fAddProduct_Load(object sender, EventArgs e)
        {
            #region Mask
            //tCreatedDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            //tCreatedDate.Properties.Mask.EditMask = "dd.MM.yyyy";
            //tCreatedDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            //tCreatedDate.EditValue = DateTime.Now;

            //tEndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            //tEndDate.Properties.Mask.EditMask = "dd.MM.yyyy";
            //tEndDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            //tEndDate.EditValue = DateTime.Now;

            tPurchasePrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            tPurchasePrice.Properties.Mask.EditMask = "n2";
            tPurchasePrice.Properties.Mask.UseMaskAsDisplayFormat = true;

            tSalesPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            tSalesPrice.Properties.Mask.EditMask = "n2";
            tSalesPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            #endregion Mask


            ClearProduct();
            UnitDataLoad();
            await TaxDataLoad();
            await WarehouseDataLoad();
            await CategoryDataLoad();
            gridControlProducts.DataSource = dataList;
        }

        private void UnitDataLoad()
        {
            var unitTypes = Enum.GetValues(typeof(Enums.UnitTypes))
                                .Cast<Enums.UnitTypes>()
                                .ToDictionary(e => e, e => Enums.GetEnumDescription(e));

            FormHelpers.ControlLoad(new BindingSource(unitTypes, null), lookUnit, "Value", "Key");
        }

        private async Task TaxDataLoad()
        {
            var data = await taxTypeOperation.WhereAsync(null);

            FormHelpers.ControlLoad(data, lookTax);
        }

        private async Task WarehouseDataLoad()
        {
            var data = await warehouseOperation.WhereAsync();

            FormHelpers.ControlLoad(data, lookWarehouse, "Name", "Id");
        }

        private async Task CategoryDataLoad()
        {
            var data = await categoryOperation.WhereAsync(x => x.IsDeleted == 0);
            lookCategory.Properties.DataSource = data;
            lookCategory.Properties.DisplayMember = "CategoryName";
            lookCategory.Properties.ValueMember = "Id";
        }

        private void bAddProduct_Click(object sender, EventArgs e)
        {
            if (Operation is Enums.Operation.Add)
            {
                AddProduct();
            }
            else if (Operation is Enums.Operation.Edit)
            {
                EditProduct();
            }
        }

        private void EditProduct()
        {
            Product.CategoryID = GetCategoryId(lookCategory.Text);
            Product.ProductName = tProductName.Text;
            Product.Barcode = tBarcode.Text;
            Product.ProductCode = tProductCode.Text;
            Product.PurchasePrice = ParseHelpers.GetConvertStringToDouble(tPurchasePrice.EditValue.ToString());
            Product.SalePrice = ParseHelpers.GetConvertStringToDouble(tSalesPrice.EditValue.ToString());
            Product.Unit = lookUnit.Text;
            Product.Tax = lookTax.Text;
            Product.Comment = tComment.Text.Trim();
            Product.Image = null;
            productOperation.Update(Product);
            DialogResult = DialogResult.OK;
        }

        private void ProductAddGrid()
        {
            short rowNo = 1;

            GridData grid = new GridData();
            grid.No = rowNo;
            grid.Category = lookCategory.SelectedText;
            grid.ProductName = tProductName.Text.Trim();
            grid.Barcode = tBarcode.Text.Trim();
            grid.UnitName = lookUnit.Text;
            grid.TaxName = lookTax.Text;
            grid.PurchasePrice = Double.Parse(tPurchasePrice.Text);
            grid.SalePrice = Double.Parse(tSalesPrice.Text);

            dataList.Add(grid);
            rowNo++;
            
        }

        private bool GetExistsBarcode(string barcode)
        {
            return db.Products.AsNoTracking()
                              .Any(x => x.Barcode == barcode && x.IsDeleted == 0);
        }

        private void AddProduct()
        {
            if (GetExistsBarcode(tBarcode.Text.Trim()))
            {
                Message("Daxil edilən barkod sistemdə mövcuddur", fMessage.enmType.Warning);
                return;
            }


            Product = new Products();

            Product.Type = (byte)ProductType.Product;
            Product.WarehousesID = (int?)lookWarehouse.EditValue;
            Product.ProductName = tProductName.Text.Trim();
            Product.CategoryID = (int?)lookCategory.EditValue;
            Product.Barcode = tBarcode.Text.Trim();
            Product.Amount = 0;
            Product.PurchasePrice = Double.Parse(tPurchasePrice.Text);
            Product.SalePrice = Double.Parse(tSalesPrice.Text);
            Product.Unit = lookUnit.Text;
            Product.TaxId = (int?)lookTax.EditValue;
            Product.ProductCode = tProductCode.Text.Trim();
            Product.Comment = tComment.Text.Trim();
            Product.Status = true;
            Product.IsDeleted = 0;

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
            tComment.Text = null;
        }

        private void tBarcode_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            tBarcode.Text = FormHelpers.ConvertToEAN13(Guid.NewGuid());
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

        private void tCategory_EditValueChanged(object sender, EventArgs e)
        {
            lookCategory.EditValueChanged -= tCategory_EditValueChanged;

            var selectedRow = lookCategory.Properties.View.GetFocusedRow() as Categories;
            if (selectedRow == null) return;


        }

        private class GridData
        {
            public short No { get; set; }
            public string Warehouse { get; set; }
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