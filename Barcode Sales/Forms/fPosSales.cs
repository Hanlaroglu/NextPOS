using Barcode_Sales.Cache;
using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraPrinting.Native.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Input;
using static Barcode_Sales.Helpers.Classes.SaleClasses;
using static Barcode_Sales.Helpers.FormHelpers;

namespace Barcode_Sales.Forms
{
    public partial class fPosSales : DevExpress.XtraEditors.XtraForm
    {
        IProductOperation productOperation = new ProductManager();
        private BindingList<SaleDataItem> dataList;
        short rowNo = 1;

        public fPosSales()
        {
            InitializeComponent();
            dataList = new BindingList<SaleDataItem>();
            gridControlBasket.DataSource = dataList;
            GridLocalizer.Active = new MyGridLocalizer();
        }

        private class ProductSearchData
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public double SalePrice { get; set; } = 0;
            public double Discount { get; set; } = 0;
            public string Barcode { get; set; }
            public string Unit { get; set; }
            public string Tax { get; set; }
        }

        private void fPosSales_Load(object sender, EventArgs e)
        {
            SearchProductList();
        }

        private async void SearchProductList()
        {
            var data = await productOperation.WhereAsync(x => x.IsDeleted == 0);
            var product = data.Select(x => new ProductSearchData
            {
                Id = x.Id,
                ProductName = x.ProductName,
                SalePrice = (double)x.SalePrice,
                Barcode = x.Barcode,
                Unit = x.Unit,
                Tax = x.Tax
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

        private void Clear()
        {
            dataList.Clear();
            tTotal.Clear();
            tCustomer.Clear();
            tComment.Clear();
            tProductCount.Clear();
            // todo Növbə ərzindəki çek sayını artır
        }

        private void buttonEdit4_SizeChanged(object sender, EventArgs e)
        {
            tCashier.Size = buttonEdit5.Size;
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
                        SalePrice = selectedRow.SalePrice,
                        Discount = selectedRow.Discount,
                        Id = selectedRow.Id,
                        Amount = 1,
                        RowNo = rowNo,
                        Barcode = selectedRow.Barcode,
                        Unit = selectedRow.Unit,
                        Tax = selectedRow.Tax,
                    };
                    dataList.Add(grid);
                    rowNo++;
                }
                gridControlBasket.RefreshDataSource();

                tSearch.EditValue = null;
            }
            finally
            {
                tProductCount.Text = dataList.Count.ToString();
                tTotal.Text = dataList.Sum(x => x.Total).ToString("N2");
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

                    var product = await productOperation.GetByBarcodeAsync(tBarcodeSearch.Text);

                    if (product == null) return;

                    var existingProduct = dataList.FirstOrDefault(x => x.Id == product.Id);

                    if (existingProduct != null)
                    {
                        existingProduct.Amount += 1;
                    }
                    else
                    {
                        SaleDataItem grid = new SaleDataItem
                        {
                            ProductName = product.ProductName,
                            SalePrice = (double)product.SalePrice,
                            Id = product.Id,
                            Amount = 1,
                            RowNo = rowNo,
                            Barcode = product.Barcode,
                            Unit = product.Unit
                        };
                        dataList.Add(grid);
                        rowNo++;
                    }
                    gridControlBasket.RefreshDataSource();

                    tBarcodeSearch.EditValue = null;
                }
                finally
                {
                    tProductCount.Text = dataList.Count.ToString();
                    tTotal.Text = dataList.Sum(x => x.Total).ToString("N2");
                    tSearch.EditValueChanged += tSearch_EditValueChanged;
                }
            }
        }

        private void bProductDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridBasket.DeleteRow(gridBasket.FocusedRowHandle);
            tProductCount.Text = dataList.Count.ToString();
            tTotal.Text = dataList.Sum(x => x.Total).ToString("N2");
        }

        private void bDiscount_Click(object sender, EventArgs e)
        {
            fPriceChange f = new fPriceChange(Helpers.Enums.PriceChangeOperation.Discount);
            if (f.ShowDialog() is DialogResult.OK)
            {

            }
        }

        private void bManagement_Click(object sender, EventArgs e)
        {
            fPosSalesControlPanel f = new fPosSalesControlPanel();
            f.ShowDialog();
        }
    }
}