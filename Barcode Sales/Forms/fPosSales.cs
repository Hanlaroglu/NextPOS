using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Barcode_Sales.Helpers.Classes.SaleClasses;
using static Barcode_Sales.Helpers.FormHelpers;

namespace Barcode_Sales.Forms
{
    public partial class fPosSales : DevExpress.XtraEditors.XtraForm
    {
        IPosSaleOperation posSaleOperation = new PosSaleManager();
        IProductOperation productOperation = new ProductManager();
        private BindingList<SaleDataItem> dataList = new BindingList<SaleDataItem>();
        private ITerminalOperation terminalOperation = new TerminalManager();
        short rowNo = 1;

        public fPosSales()
        {
            InitializeComponent();
            gridControlBasket.DataSource = dataList;
        }

        private class ProductSearchData : Product
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public decimal? PurchasePrice { get; set; }
            public decimal SalePrice { get; set; } = 0;
            public decimal Discount { get; set; } = 0;
            public string Barcode { get; set; }
            public int UnitId { get; set; }
            public int TaxId { get; set; }
            public decimal Amount { get; set; }
        }

        private async void fPosSales_Load(object sender, EventArgs e)
        {
            CommonData.terminal = terminalOperation.GetIpAddress();
            var saleCount = await posSaleOperation.CurrentSaleCount();
            tSaleCount.Text = saleCount.ToString();
            tToday.Properties.Buttons[1].Caption = CommonData.TODAY_DATE;
            tCashier.Properties.Buttons[1].Caption = CommonData.CURRENT_USER?.NameSurname;
            await SearchProductList();
        }

        private async Task SearchProductList()
        {
            var data = await productOperation.ToListAsync(x => x.IsDeleted == 0 || x.Status == true);
            var product = data.Select(x => new ProductSearchData
            {
                Id = x.Id,
                ProductName = x.ProductName,
                SalePrice = (decimal)x.SalePrice,
                PurchasePrice = (decimal)x.PurchasePrice,
                Barcode = x.Barcode,
                UnitId = (int)x.UnitId,
                TaxId = (int)x.TaxId
            }).ToList();

            tSearch.Properties.DataSource = product;
            tSearch.Properties.DisplayMember = "ProductName";
            tSearch.Properties.ValueMember = "Id";
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void bPay_Click(object sender, EventArgs e)
        {
            if (dataList.Count > 0)
            {
                fPosPay f = new fPosPay(new SaleData
                {
                    Cashier = tCashier.Properties.Buttons[1].Caption,
                    Items = dataList,
                    CustomerName = tCustomer.Text,
                    Note = tComment.Text
                });
                if (f.ShowDialog() is DialogResult.OK)
                {
                    Clear();
                }
            }
        }

        private void Clear()
        {
            dataList.Clear();
            tTotal.Text = 0.ToString("0.00");
            tCustomer.Clear();
            tComment.Clear();
            tProductCount.Text = CommonData.DEFAULT_INT_TOSTRING;
            // todo Növbə ərzindəki çek sayını artır
        }

        private void buttonEdit4_SizeChanged(object sender, EventArgs e)
        {
            tCashier.Size = tSaleCount.Size;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chBarcode_CheckedChanged(object sender, EventArgs e)
        {
            navigationSearchMode.SelectedPage = pageBarcodeSearch;
        }

        private void chName_CheckedChanged(object sender, EventArgs e)
        {
            navigationSearchMode.SelectedPage = pageNameSearch;
        }

        private void tSearch_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                tSearch.EditValueChanged -= tSearch_EditValueChanged;

                var selectedRow = tSearch.Properties.View.GetFocusedRow() as ProductSearchData;
                if (selectedRow == null) return;

                var existingProduct = dataList.FirstOrDefault(x => x.Id == selectedRow.Id);

                if (existingProduct != null)
                {
                    existingProduct.Amount += 1;
                }
                else
                {
                    SaleDataItem grid = new SaleDataItem
                    {
                        ProductName = selectedRow.ProductName,
                        PurchasePrice = selectedRow.PurchasePrice,
                        SalePrice = selectedRow.SalePrice,
                        Discount = selectedRow.Discount,
                        Id = selectedRow.Id,
                        Amount = 1,
                        RowNo = rowNo,
                        Barcode = selectedRow.Barcode,
                        UnitId = selectedRow.UnitId,
                        TaxId = selectedRow.TaxId,
                    };
                    dataList.Add(grid);
                    rowNo++;
                }
                gridControlBasket.RefreshDataSource();

                tSearch.EditValue = null;
            }
            finally
            {
                TotalAmountCalculation();
                tSearch.EditValueChanged += tSearch_EditValueChanged;
            }
        }

        private async void tBarcodeSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                try
                {
                    tSearch.EditValueChanged -= tSearch_EditValueChanged;

                    var product = await productOperation.Get(x=> x.Barcode == tBarcodeSearch.Text.Trim());

                    if (product is null)
                    {
                        NotificationHelpers.Messages.WarningMessage(this, "Məhsul tapılmadı");
                        tBarcodeSearch.Clear();
                        return;
                    }
                        

                    var existingProduct = dataList.FirstOrDefault(x => x.Id == product.Id);

                    if (existingProduct != null)
                        existingProduct.Amount += 1;
                    else
                    {
                        SaleDataItem grid = new SaleDataItem
                        {
                            ProductName = product.ProductName,
                            SalePrice = (decimal)product.SalePrice,
                            Id = product.Id,
                            Amount = 1,
                            RowNo = rowNo,
                            Barcode = product.Barcode,
                            UnitId = (int)product.UnitId
                        };
                        dataList.Add(grid);
                        rowNo++;
                    }
                    gridControlBasket.RefreshDataSource();

                    tBarcodeSearch.EditValue = null;
                }
                finally
                {
                    TotalAmountCalculation();
                    tSearch.EditValueChanged += tSearch_EditValueChanged;
                }
            }
        }

        private void TotalAmountCalculation()
        {
            gridBasket.RefreshData();
            //tProductCount.Text = dataList.Count.ToString();
            tProductCount.Text = dataList == null ? CommonData.DEFAULT_INT_TOSTRING : dataList.Count.ToString();
            //tTotal.Text = dataList.Sum(x => x.Total).ToString("0.00");
            tTotal.Text = dataList == null ? 0.ToString("N2") : dataList.Sum(x => x.Total).ToString("0.00");
        }

        private void bProductDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridBasket.DeleteRow(gridBasket.FocusedRowHandle);
            TotalAmountCalculation();
        }

        private void bDiscount_Click(object sender, EventArgs e)
        {
            if (gridBasket.GetFocusedRow() != null)
            {
                int focusedRow = Int32.Parse(gridBasket.GetFocusedRowCellValue(colId).ToString());

                var selectedProduct = dataList.FirstOrDefault(x => x.Id == focusedRow);
                fPriceChange f = new fPriceChange(new Helpers.Classes.SaleClasses.PosChangeType
                {
                    ChangeType = Enums.PosChangeType.Discount,
                    Amount = selectedProduct.SalePrice,
                    ProductName = selectedProduct.ProductName,
                });
                if (f.ShowDialog() is DialogResult.OK)
                {
                    selectedProduct.Discount = f.Amount;
                    TotalAmountCalculation();
                }
            }
        }

        private void bManagement_Click(object sender, EventArgs e)
        {
            fPosSalesControlPanel f = new fPosSalesControlPanel();
            f.ShowDialog();
        }

        private void gridBasket_decimalClick(object sender, EventArgs e)
        {
            Point pt = gridBasket.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = gridBasket.CalcHitInfo(pt);
            var value = gridBasket.GetFocusedRowCellValue(colId);
            if (value == null || !Int32.TryParse(value.ToString(), out int focusedRow))
                return;

            var selectedProduct = dataList.FirstOrDefault(x => x.Id == focusedRow);
            if (info.InRowCell)
            {

                switch (info.Column.FieldName)
                {
                    case "Amount":
                        fPriceChange amount = new fPriceChange(new Helpers.Classes.SaleClasses.PosChangeType
                        {
                            ChangeType = Enums.PosChangeType.Quantity,
                            ProductName = selectedProduct.ProductName,
                        });
                        if (amount.ShowDialog() is DialogResult.OK)
                        {
                            selectedProduct.Amount = amount.Amount;
                            TotalAmountCalculation();
                        }
                        break;
                    case "SalePrice":
                        fPriceChange price = new fPriceChange(new Helpers.Classes.SaleClasses.PosChangeType
                        {
                            ChangeType = Enums.PosChangeType.PriceChange,
                            Amount = selectedProduct.SalePrice,
                            ProductName = selectedProduct.ProductName,
                        });
                        if (price.ShowDialog() is DialogResult.OK)
                        {
                            focusedRow = Int32.Parse(gridBasket.GetFocusedRowCellValue(colId).ToString());

                            selectedProduct = dataList.FirstOrDefault(x => x.Id == focusedRow);
                            selectedProduct.SalePrice = price.Amount;
                            TotalAmountCalculation();
                        }
                        break;
                    case "Discount":
                        focusedRow = Int32.Parse(gridBasket.GetFocusedRowCellValue(colId).ToString());

                        selectedProduct = dataList.FirstOrDefault(x => x.Id == focusedRow);

                        fPriceChange discount = new fPriceChange(new Helpers.Classes.SaleClasses.PosChangeType
                        {
                            ChangeType = Enums.PosChangeType.Discount,
                            Amount = selectedProduct.SalePrice,
                            ProductName = selectedProduct.ProductName,
                        });
                        if (discount.ShowDialog() is DialogResult.OK)
                        {

                            selectedProduct.Discount = discount.Amount;
                            TotalAmountCalculation();
                        }
                        break;
                }
            }
        }

        private void fPosSales_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }
    }
}