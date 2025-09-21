using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fTerminalSaleReport : DevExpress.XtraEditors.XtraForm
    {
        ISaleDataOperation saleDataOperation = new SalesDataManager();
        ISalesDataDetailOperation salesDataDetailOperation = new SalesDataDetailManager();
        private IUserOperation userOperation = new UserManager();

        public fTerminalSaleReport()
        {
            InitializeComponent();
        }

        private void bReceiptCopy_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //todo Terminallara görə kassadan təkrar çap et
        }

        private async void fTerminalSaleReport_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dateStart.DateTime = today;
            dateEnd.DateTime = today;
            dateStart.Focus();
            await CashiersLoad();

            gridControl1.MainView = gridView1;
            gridControl1.LevelTree.Nodes.Add("SalesDataDetails", gridView2);
        }

        private async Task CashiersLoad()
        {
            var data = await userOperation.WhereAsync(x => x.IsDeleted == 0);
            FormHelpers.ControlLoad(data, lookCashier, "NameSurname");
        }

        private void CheckedSearchType(object sender, EventArgs e)
        {
            if (chDate.Checked)
            {
                dateStart.Focus();
                textEdit1.Visible = false;
            }
            else
            {
                textEdit1.Focus();
                textEdit1.Visible = true;
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            var data = new List<SaleDataDto>();
            if (chDate.Checked)
            {
                data = saleDataOperation.Where(x => x.SaleDate >= dateStart.DateTime &&
                                                        x.SaleDate <= dateEnd.DateTime)
                    .Select(x => new SaleDataDto()
                    {
                        Id = x.Id,
                        Cashier = x.User.NameSurname,
                        CustomerName = x.Customer.NameSurname,
                        SaleDate = x.SaleDate,
                        SaleDatetime = x.SaleDatetime,
                        ReceiptNo = x.ReceiptNo,
                        ShortFiscalId = x.ShortFiscalId,
                        Rrn = x.Rrn,
                        PaymentType = x.Cash > 0 && x.Card == 0 ? "NAĞD"
                                                                : x.Cash == 0 && x.Card > 0 ? "KART"
                                                                : x.Cash > 0 && x.Card > 0 ? "NAĞD-KART"
                                                                : string.Empty,
                        Total = x.Total,
                        Note = x.Note
                    })
                    .ToList();
            }
            else if (chFiscal.Checked)
            {
                string fiscal = textEdit1.Text.TrimStart().Trim();
                data = saleDataOperation.Where(x => x.ShortFiscalId == fiscal)
                    .Select(x => new SaleDataDto()
                    {
                        Id = x.Id,
                        Cashier = x.User.NameSurname,
                        CustomerName = x.Customer.NameSurname,
                        SaleDate = x.SaleDate,
                        SaleDatetime = x.SaleDatetime,
                        ReceiptNo = x.ReceiptNo,
                        ShortFiscalId = x.ShortFiscalId,
                        Rrn = x.Rrn,
                        PaymentType = x.Cash > 0 && x.Card == 0 ? "NAĞD"
                            : x.Cash == 0 && x.Card > 0 ? "KART"
                            : x.Cash > 0 && x.Card > 0 ? "NAĞD-KART"
                            : string.Empty,
                        Total = x.Total,
                        Note = x.Note
                    })
                    .ToList();
            }
            else if (chReceipt.Checked)
            {
                string receipt = textEdit1.Text.TrimStart().Trim();
                data = saleDataOperation.Where(x => x.ReceiptNo == receipt)
                    .Select(x => new SaleDataDto()
                    {
                        Id = x.Id,
                        Cashier = x.User.NameSurname,
                        CustomerName = x.Customer.NameSurname,
                        SaleDate = x.SaleDate,
                        SaleDatetime = x.SaleDatetime,
                        ReceiptNo = x.ReceiptNo,
                        ShortFiscalId = x.ShortFiscalId,
                        Rrn = x.Rrn,
                        PaymentType = x.Cash > 0 && x.Card == 0 ? "NAĞD"
                            : x.Cash == 0 && x.Card > 0 ? "KART"
                            : x.Cash > 0 && x.Card > 0 ? "NAĞD-KART"
                            : string.Empty,
                        Total = x.Total,
                        Note = x.Note
                    })
                    .ToList();
            }
            FormHelpers.ControlLoad(data, gridControl1);
        }

        private void gridView1_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            var data = (SaleDataDto)gridView1.GetRow(e.RowHandle);
            if (data != null)
            {
                var dataSource = salesDataDetailOperation.Where(x => x.SaleDataId == data.Id)
                    .Select(x => new SalesDataDetailDto()
                    {
                        Id = x.Id,
                        SaleDataId = x.SaleDataId,
                        ProductId = x.ProductId,
                        ProductName = x.Products.ProductName,
                        Barcode = x.Products.Barcode,
                        Unit = x.Products.UnitTypes.Name,
                        Tax = x.Products.TaxTypes.Name,
                        Quantity = x.Quantity,
                        SalePrice = x.SalePrice,
                        Discount = x.Discount,
                        Total = (double)x.Quantity * (double)x.SalePrice,
                    })
                    .ToList();
                e.ChildList = dataSource;
            }

        }

        private void gridView1_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "SalesDataDetails";
        }

        private void gridView1_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void lookCashier_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lookCashier.Text))
                gridView1.ActiveFilterString = $"Contains([Cashier], '{lookCashier.Text}')";
        }

        private class SaleDataDto : SalesData
        {
            public string PaymentType { get; set; }
            public string Cashier { get; set; }
            public string CustomerName { get; set; }
        }

        private class SalesDataDetailDto : SalesDataDetail
        {
            public string ProductName { get; set; }
            public string Barcode { get; set; }
            public string Unit { get; set; }
            public string Tax { get; set; }
            public double Total { get; set; }
        }

        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
                bSearch.PerformClick();
        }
    }
}