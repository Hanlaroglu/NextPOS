using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using DevExpress.XtraEditors;
using NextPOS.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fAqtaAddProfuct : FormBase
    {
        NextposDBEntities db = new NextposDBEntities();
        IAqtaProductsOperation aqtaProductsOperation = new AqtaProductsManager();
        private Enums.Operation Operation { get; }
        private AqtaProducts AqtaProducts { get; set; }
        private BindingList<GridData> dataList;
        short rowNo = 1;

        public fAqtaAddProfuct(Enums.Operation _operation, AqtaProducts _product)
        {
            InitializeComponent();
            Operation = _operation;
            AqtaProducts = _product;
        }

        private void fAqtaAddProfuct_Load(object sender, EventArgs e)
        {
            bAddProduct.Text = Enums.GetEnumDescription(Operation);
            UnitDataLoad();
            WarehouseDataLoad();
            switch (Operation)
            {
                case Enums.Operation.Add:
                    dataList = new BindingList<GridData>();
                    gridControlProducts.DataSource = dataList;
                    break;
                case Enums.Operation.Edit:
                    //GetProductDataLoad();
                    gridControlProducts.Visible = false;
                    bSendWarehouses.Visible = false;
                    bClear.Visible = false;
                    break;
                case Enums.Operation.Show:
                    //GetProductDataLoad();
                    gridControlProducts.Visible = false;
                    bAddProduct.Visible = false;
                    bSendWarehouses.Visible = false;
                    bClear.Visible = false;
                    lookUnit.Enabled = false;
                    lookWarehouse.Enabled = false;
                    break;
            }
        }

        void WarehouseDataLoad()
        {
            if (db.Warehouses.AsNoTracking().Any())
            {

                var data = db.Warehouses.AsNoTracking()
                                        .Where(x => x.IsDeleted == 0)
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

        void UnitDataLoad()
        {
            var unitTypes = Enum.GetValues(typeof(Enums.UnitTypes))
                                .Cast<Enums.UnitTypes>()
                                .ToDictionary(e => e, e => Enums.GetEnumDescription(e));

            FormHelpers.ControlLoad(new BindingSource(unitTypes, null), lookUnit, "Value", "Key");
        }

        private void tBarcode_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            tBarcode.Text = FormHelpers.ConvertToEAN13(Guid.NewGuid());
        }

        private void tCategory_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            fSelected selected = new fSelected();
            if (selected.ShowDialog() is DialogResult.OK)
            {
                tCategory.Text = selected.CategoryName;
            }
        }

        private class GridData
        {
            public short No { get; set; }
            public short? RetentionPeriod { get; set; }
            public string StorageConditions { get; set; }
            public string Warehouses { get; set; } = "MƏRKƏZİ ANBAR";
            public string Category { get; set; }
            public string ProductName { get; set; }
            public string Barcode { get; set; }
            public string UnitName { get; set; }
            public DateTime? ReleaseDate { get; set; }
            public string Ingredients { get; set; }
            public double? PurchasePrice { get; set; }
            public double? SalePrice { get; set; }
            public bool ShowPosScreen { get; set; }
            public bool AmountNotification { get; set; }
            public bool FinishDateDeleteProduct { get; set; }
        }

        bool GetExistsBarcode(string barcode)
        {
            return db.AqtaProducts.AsNoTracking()
                              .Where(x => x.IsDeleted == 0)
                              .Any(x => x.Barcode == barcode);
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

        private void ProductAddGrid()
        {
            try
            {
                if (GetExistsBarcode(tBarcode.Text.Trim()))
                {
                    Message("Daxil edilən barkod sistemdə mövcuddur", fMessage.enmType.Warning);
                    return;
                }
                else if (string.IsNullOrWhiteSpace(tCategory.Text))
                {
                    Message(ValidationHelpers.CategoryNotSelected, fMessage.enmType.Warning);
                    return;
                }

                DateTime? ReleaseDate = ParseHelpers.StringConvertDatetime(tReleaseDate.EditValue.ToString());

                if (ReleaseDate == DateTime.MinValue)
                {
                    ReleaseDate = null;
                }

                GridData grid = new GridData();
                grid.No = rowNo;
                grid.Category = tCategory.Text;
                grid.ProductName = tProductName.Text;
                grid.Barcode = tBarcode.Text;
                grid.UnitName = lookUnit.Text;
                grid.ReleaseDate = ReleaseDate;
                grid.PurchasePrice = ParseHelpers.GetConvertStringToDouble(tPurchasePrice.EditValue.ToString());
                grid.SalePrice = ParseHelpers.GetConvertStringToDouble(tSalesPrice.EditValue.ToString());
                grid.RetentionPeriod = ParseHelpers.GetConvertStringToInt16(tRetentionPeriod.EditValue.ToString());
                grid.StorageConditions = tStorageConditions.Text;
                grid.Ingredients = tIngredients.Text;
                grid.ShowPosScreen = chPOSShowSales.Checked;
                grid.AmountNotification = chAmountNotification.Checked;
                //grid.FinishDateDeleteProduct = chFinishDateDeleteProduct.Checked;

                AqtaProducts validateProduct = GridDataToProductsMapper(grid);
                var validator = new AqtaProductsValidation();
                var validateResult = validator.Validate(validateProduct);
                if (!validateResult.IsValid)
                {
                    foreach (var error in validateResult.Errors)
                    {
                        Message(error.ErrorMessage, fMessage.enmType.Warning);
                        return;
                    }
                }
                dataList.Add(grid);
                rowNo++;
                Clear();
            }
            catch (Exception e)
            {
                CommonMessageBox.ErrorMessageBox(e.Message);
            }
        }

        private void EditProduct()
        {
            AqtaProducts.CategoryID = GetCategoryId(tCategory.Text);
            AqtaProducts.ProductName = tProductName.Text;
            AqtaProducts.Barcode = tBarcode.Text;
            AqtaProducts.PurchasePrice = ParseHelpers.GetConvertStringToDouble(tPurchasePrice.EditValue.ToString());
            AqtaProducts.SalePrice = ParseHelpers.GetConvertStringToDouble(tSalesPrice.EditValue.ToString());
            AqtaProducts.Unit = lookUnit.Text;
            AqtaProducts.ReleaseDate = ParseHelpers.StringConvertDatetime(tReleaseDate.EditValue.ToString());
            AqtaProducts.StorageConditions = tStorageConditions.Text;
            AqtaProducts.RetentionPeriod = Convert.ToInt32(tRetentionPeriod.EditValue.ToString());
            AqtaProducts.Ingredients = tIngredients.Text;
            AqtaProducts.ShowPosScreen = chPOSShowSales.Checked;
            AqtaProducts.AmountNotification = chAmountNotification.Checked;
            AqtaProducts.EndDateNotification = chFinishDateDeleteProduct.Checked;

            aqtaProductsOperation.Update(AqtaProducts);
            DialogResult = DialogResult.OK;
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            tCategory.Text = null;
            tProductName.Text = null;
            tBarcode.Text = null;
            tPurchasePrice.EditValue = 0;
            tSalesPrice.EditValue = 0;
            lookUnit.EditValue = null;
            tReleaseDate.Text = "<Null>";
            tRetentionPeriod.Text = null;
            tStorageConditions.Text = null;
            tIngredients.Text = null;
            chAmountNotification.Checked = false;
            chFinishDateDeleteProduct.Checked = false;
            chPOSShowSales.Checked = false;
        }

        private AqtaProducts GridDataToProductsMapper(GridData data)
        {
            int? categoryID = GetCategoryId(data.Category);
            AqtaProducts product = new AqtaProducts
            {
                WarehousesID = 1,
                StoreID = 1,
                CategoryID = categoryID,
                ProductName = data.ProductName,
                Barcode = data.Barcode,
                PurchasePrice = data.PurchasePrice,
                SalePrice = data.SalePrice,
                Unit = data.UnitName,
                Ingredients = data.Ingredients,
                ReleaseDate = data.ReleaseDate,
                RetentionPeriod = data.RetentionPeriod,
                StorageConditions = data.StorageConditions,
                ShowPosScreen = data.ShowPosScreen,
                AmountNotification = data.AmountNotification,
                //EndDateNotification = data.FinishDateDeleteProduct,
            };
            return product;
        }

        private int? GetCategoryId(string name)
        {
            if (db.Categories.AsNoTracking().Any(x => x.CategoryName == name))
            {
                return db.Categories.AsNoTracking().FirstOrDefault(x => x.CategoryName == name).Id;
            }
            else
            {
                throw new NullReferenceException(ValidationHelpers.CategoryNotSelected);
            }
        }

        private void bSendWarehouses_Click(object sender, EventArgs e)
        {
            SendProductsWarehouse();
        }

        void SendProductsWarehouse()
        {
            for (int i = 0; i < gridProducts.RowCount; i++)
            {
                if (gridProducts.IsValidRowHandle(i))
                {
                    int? categoryID = GetCategoryId(gridProducts.GetRowCellValue(i, colCategory).ToString());
                    var test = gridProducts.GetRowCellValue(i, colReleaseDate);

                    AqtaProducts = new AqtaProducts();
                    AqtaProducts.WarehousesID = 1;
                    AqtaProducts.StoreID = 1;
                    AqtaProducts.CategoryID = categoryID;
                    AqtaProducts.ProductName = gridProducts.GetRowCellValue(i, colProductName).ToString();
                    AqtaProducts.Barcode = gridProducts.GetRowCellValue(i, colBarcode).ToString();
                    AqtaProducts.PurchasePrice = Convert.ToDouble(gridProducts.GetRowCellValue(i, colPurchasePrice).ToString());
                    AqtaProducts.SalePrice = Convert.ToDouble(gridProducts.GetRowCellValue(i, colSalesPrice).ToString());
                    AqtaProducts.Unit = gridProducts.GetRowCellValue(i, colUnit).ToString();
                    AqtaProducts.Tax = null;
                    AqtaProducts.RetentionPeriod = Convert.ToInt32(gridProducts.GetRowCellValue(i, colRetentionPeriod).ToString());
                    AqtaProducts.StorageConditions = gridProducts.GetRowCellValue(i, colStorageConditions).ToString();
                    AqtaProducts.Ingredients = gridProducts.GetRowCellValue(i, colIngredients).ToString();
                    AqtaProducts.CreateDate = DateTime.Now;
                    AqtaProducts.ReleaseDate = Convert.ToDateTime(gridProducts.GetRowCellValue(i, colReleaseDate).ToString());
                    AqtaProducts.ShowPosScreen = Convert.ToBoolean(gridProducts.GetRowCellValue(i, colShowPosScreen));
                    AqtaProducts.AmountNotification = Convert.ToBoolean(gridProducts.GetRowCellValue(i, colAmountEndNotification));
                    AqtaProducts.EndDateNotification = false;
                    AqtaProducts.Status = true;
                    AqtaProducts.IsDeleted = 0;

                    aqtaProductsOperation.Add(AqtaProducts);
                }
            }
            dataList.Clear();
            gridProducts.RefreshData();
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
    }
}