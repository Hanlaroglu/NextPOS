using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Services.CacheServices;
using Barcode_Sales.Terminals.Omnitech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fTerminalSaleReport : DevExpress.XtraEditors.XtraForm
    {
        private IPosSaleOperation posSaleOperation = new PosSaleManager();
        private IPosSaleItemOperation posSaleItemOperation = new PosSaleItemManager();

        private IUserOperation userOperation = new UserManager();

        public fTerminalSaleReport()
        {
            InitializeComponent();
        }

        private async void fTerminalSaleReport_Shown(object sender, EventArgs e)
        {
            if (TerminalCacheService.Terminal is null)
                await TerminalCacheService.RefreshTerminal();

            dateStart.DateTime = DatetimeService.FirstDayOfCurrentMonth;
            dateEnd.DateTime = DatetimeService.CurrentDateTime;
            dateStart.Focus();
            await CashiersLoad();

            gridControl1.MainView = gridView1;
            gridControl1.LevelTree.Nodes.Add("SalesDataDetails", gridView2);
        }

        private async void bReceiptCopy_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridView1.GetFocusedRow() as SaleDataDto;
            if (row is null) return;

            if (TerminalCacheService.Terminal != null)
            {
                var terminal = (Helpers.Enums.Terminal)Enum.Parse(typeof(Helpers.Enums.Terminal), TerminalCacheService.Terminal.Name);
                switch (terminal)
                {
                    case Helpers.Enums.Terminal.OMNİTECH:
                        OmnnitechTerminal omnitech = new OmnnitechTerminal(TerminalCacheService.Terminal.IpAddress);

                        var result = await omnitech.ReceiptCopy(row.LongFiscalId);
                        if (result.Success)
                        {
                            NotificationHelpers.Messages.SuccessMessage(this, result.Message);
                            DialogResult = DialogResult.OK;
                        }
                        else
                            NotificationHelpers.Messages.ErrorMessage(this, result.Message);
                        break;
                }
            }
        }

        private async Task CashiersLoad()
        {
            var data = await userOperation.ToListAsync(x => x.IsDeleted == false);
            FormHelpers.ControlLoad(data, lookCashier, "NameSurname");
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            var data = new List<SaleDataDto>();
            data = posSaleOperation.Where(x => x.SaleDate >= dateStart.DateTime &&
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
                    LongFiscalId = x.LongFiscalId,
                    BankRrn = x.BankRrn,
                    PaymentType = x.Cash > 0 && x.Card == 0 ? "NAĞD"
                        : x.Cash == 0 && x.Card > 0 ? "KART"
                        : x.Cash > 0 && x.Card > 0 ? "NAĞD-KART"
                        : string.Empty,
                    Total = x.Total,
                    Note = x.Note
                })
                .OrderBy(x => x.Id)
                .ToList();

            /*
            else if (chFiscal.Checked)
            {
                string fiscal = textEdit1.Text.TrimStart().Trim();
                data = posSaleOperation.Where(x => x.ShortFiscalId == fiscal)
                    .Select(x => new SaleDataDto()
                    {
                        Id = x.Id,
                        Cashier = x.User.NameSurname,
                        CustomerName = x.Customer.NameSurname,
                        SaleDate = x.SaleDate,
                        SaleDatetime = x.SaleDatetime,
                        ReceiptNo = x.ReceiptNo,
                        ShortFiscalId = x.ShortFiscalId,
                        BankRrn = x.BankRrn,
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
                data = posSaleOperation.Where(x => x.ReceiptNo == receipt)
                    .Select(x => new SaleDataDto()
                    {
                        Id = x.Id,
                        Cashier = x.User.NameSurname,
                        CustomerName = x.Customer.NameSurname,
                        SaleDate = x.SaleDate,
                        SaleDatetime = x.SaleDatetime,
                        ReceiptNo = x.ReceiptNo,
                        ShortFiscalId = x.ShortFiscalId,
                        BankRrn = x.BankRrn,
                        PaymentType = x.Cash > 0 && x.Card == 0 ? "NAĞD"
                            : x.Cash == 0 && x.Card > 0 ? "KART"
                            : x.Cash > 0 && x.Card > 0 ? "NAĞD-KART"
                            : string.Empty,
                        Total = x.Total,
                        Note = x.Note
                    })
                    .ToList();
            }
            */
            FormHelpers.ControlLoad(data, gridControl1);
        }

        private void gridView1_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            //gridView1.CollapseMasterRow(gridView1.FocusedRowHandle); //Gridi bağlayır
            //gridView1.ExpandMasterRow(gridView1.FocusedRowHandle);
            var data = (SaleDataDto)gridView1.GetRow(e.RowHandle);
            if (data != null)
            {
                var dataSource = posSaleItemOperation.Where(x => x.PosSaleId == data.Id)
                    .Select(x => new SalesDataDetailDto()
                    {
                        Id = x.Id,
                        PosSaleId = x.PosSaleId,
                        ProductId = x.ProductId,
                        ProductName = x.Product.ProductName,
                        Barcode = x.Product.Barcode,
                        Unit = x.Product.UnitTypes.Name,
                        Tax = x.Product.TaxTypes.Name,
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

        private class SaleDataDto : PosSale
        {
            public string PaymentType { get; set; }
            public string Cashier { get; set; }
            public string CustomerName { get; set; }
        }

        private class SalesDataDetailDto : PosSaleItem
        {
            public string ProductName { get; set; }
            public string Barcode { get; set; }
            public string Unit { get; set; }
            public string Tax { get; set; }
            public double Total { get; set; }
        }
    }
}