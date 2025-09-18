using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System;
using System.Linq;
using System.Threading.Tasks;

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
            //Terminallara görə kassadan təkrar çap et
        }

        private async void fTerminalSaleReport_Load(object sender, EventArgs e)
        {
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
                tFiscalCode.Visible = false;
            }
            else if (chFiscal.Checked)
            {
                tFiscalCode.Focus();
                tFiscalCode.Visible = true;
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            if (chDate.Checked)
            {
                var data = saleDataOperation.Where(x => x.SaleDate >= dateStart.DateTime &&
                                                        x.SaleDate <= dateEnd.DateTime).Select(x => new
                                                        {
                                                            x.Id,
                                                            Cashier = x.User.NameSurname,
                                                            CustomerName = x.Customer.NameSurname,
                                                            x.SaleDate,
                                                            x.SaleDatetime,
                                                            x.ReceiptNo,
                                                            x.ShortFiscalId,
                                                            x.Rrn,
                                                            PaymentType = x.Cash > 0 && x.Card == 0 ? "NAĞD"
                                                                : x.Cash == 0 && x.Card > 0 ? "KART"
                                                                : x.Cash > 0 && x.Card > 0 ? "NAĞD-KART" 
                                                                : string.Empty,
                                                            x.Total,
                                                            x.Note
                                                        }).ToList();

                FormHelpers.ControlLoad(data, gridControl1);
            }
            else if (chFiscal.Checked)
            {
                var data = saleDataOperation.Where(x => x.ShortFiscalId == tFiscalCode.Text.TrimStart().Trim())
                    .Select(x => new
                    {
                        x.Id,
                        Cashier = x.User.NameSurname,
                        CustomerName = x.Customer.NameSurname,
                        x.SaleDate,
                        x.SaleDatetime,
                        x.ReceiptNo,
                        x.ShortFiscalId,
                        x.Rrn,
                        PaymentType = x.Cash > 0 && x.Card == 0 ? "NAĞD"
                            : x.Cash == 0 && x.Card > 0 ? "KART"
                            : x.Cash > 0 && x.Card > 0 ? "NAĞD-KART" 
                            : string.Empty,
                        x.Total,
                        x.Note
                    }).ToList();

                FormHelpers.ControlLoad(data, gridControl1);
            }
        }

        private void gridView1_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            int Id = ((SalesData)gridView1.GetRow(e.RowHandle)).Id;
            e.ChildList = salesDataDetailOperation.Where(x => x.SaleDataId == Id).ToList();
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
                gridView1.ActiveFilterString = $"Contains([User.NameSurname], '{lookCashier.Text}')";
        }
    }
}