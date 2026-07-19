using System;
using System.Collections.Generic;
using System.Linq;
using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Services.CacheServices;
using DevExpress.XtraEditors.Repository;

namespace Barcode_Sales.Forms
{
    public partial class fTerminalRefundReport : DevExpress.XtraEditors.XtraForm
    {
        IPosRefundOperation posRefundOperation = new PosRefundManager();
        IPosRefundItemOperation posRefundItemOperation = new PosRefundItemManager();

        RepositoryItemTextEdit repositoryN3;
        RepositoryItemTextEdit repositoryN0;

        public fTerminalRefundReport()
        {
            InitializeComponent();
            //GridRepoAdd();
        }

        private async void fTerminalRefundReport_Shown(object sender, EventArgs e)
        {
            if (TerminalCacheService.Terminal is null)
                await TerminalCacheService.RefreshTerminal();

            dateStart.DateTime = DatetimeService.FirstDayOfCurrentMonth;
            dateEnd.DateTime = DatetimeService.CurrentDateTime;
            dateStart.Focus();

            gridControl2.MainView = gridView4;
            gridControl2.LevelTree.Nodes.Add("RefundDetailDto", gridView3);
        }

        private void bReceiptCopy_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            GetReport();
        }

        private void GetReport()
        {
            var data = new List<RefundDataDto>();
            data = posRefundOperation.Where(x => x.OperationDate >= dateStart.DateTime &&
                                               x.OperationDate <= dateEnd.DateTime)
                .Select(x => new RefundDataDto
                {
                    Id = x.Id,
                    Cashier = x.User.NameSurname,
                    CustomerName = x.Customer.NameSurname,
                    OperationDate = x.OperationDate,
                    SaleReceiptNo = x.PosSale.ReceiptNo,
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

            FormHelpers.ControlLoad(data, gridControl2);
        }

        private void gridView4_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gridView4_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "RefundDetailDto";
        }

        private void gridView4_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            var data = (RefundDataDto)gridView4.GetRow(e.RowHandle);
            if (data != null)
            {
                var dataSource = posRefundItemOperation.Where(x => x.PosRefundId == data.Id)
                    .Select(x => new RefundDetailDto
                    {
                        Id = x.Id,
                        PosRefundId = x.PosRefundId,
                        ProductId = x.ProductId,
                        ProductName = x.Product.ProductName,
                        Barcode = x.Product.Barcode,
                        Unit = x.Product.UnitType.Name,
                        Tax = x.Product.TaxType.Name,
                        Quantity = x.Quantity,
                        SalePrice = x.SalePrice,
                        Discount = x.Discount,
                        Total = x.Quantity * x.SalePrice,
                    })
                    .ToList();
                e.ChildList = dataSource;
            }
        }


        private void GridRepoAdd()
        {
            repositoryN3 = new RepositoryItemTextEdit();
            repositoryN3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            repositoryN3.Mask.EditMask = "n3";
            repositoryN3.Mask.UseMaskAsDisplayFormat = true;

            repositoryN0 = new RepositoryItemTextEdit();
            repositoryN0.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            repositoryN0.Mask.EditMask = "n0";
            repositoryN0.Mask.UseMaskAsDisplayFormat = true;

            gridControl2.RepositoryItems.Add(repositoryN3);
            gridControl2.RepositoryItems.Add(repositoryN0);
        }

        private void gridView3_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            //if (e.Column.FieldName == "Quantity")
            //{
            //    var unitName = gridView3.GetRowCellValue(e.RowHandle, "Unit")?.ToString();

            //    if (unitName is "Kq")
            //        e.RepositoryItem = repositoryN3;
            //    else
            //        e.RepositoryItem = repositoryN0;
            //}
        }

        private class RefundDataDto : PosRefund
        {
            public string SaleReceiptNo { get; set; }
            public string PaymentType { get; set; }
            public string Cashier { get; set; }
            public string CustomerName { get; set; }
        }

        private class RefundDetailDto : PosRefundItem
        {
            public string ProductName { get; set; }
            public string Barcode { get; set; }
            public string Unit { get; set; }
            public string Tax { get; set; }
            public decimal Total { get; set; }
        }
    }
}