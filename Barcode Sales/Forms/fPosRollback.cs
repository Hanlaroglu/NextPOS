using Barcode_Sales.DTOs;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Tools;
using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Barcode_Sales.Services.CacheServices;
using DevExpress.XtraGrid;

namespace Barcode_Sales.Forms
{
    public partial class fPosRollback : DevExpress.XtraEditors.XtraForm
    {
        IPosSaleOperation posSaleOperation = new PosSaleManager();
        IPosSaleItemOperation posSaleItemOperation = new PosSaleItemManager();

        public fPosRollback()
        {
            InitializeComponent();
        }

        private void fPosRollback_Shown(object sender, EventArgs e)
        {
            gridControlSalesData.MainView = gridSalesData;
            gridControlSalesData.LevelTree.Nodes.Add("PosSaleItems", gridSaleDetail);

            dateStart.DateTime = DatetimeService.FirstDayOfCurrentMonth;
            dateFinish.DateTime = DatetimeService.CurrentDateTime;
        }

        private enum CheckedType
        {
            Date,
            ReceiptNo,
            FiscalID
        }

        private void SelectedType(object sender, EventArgs e)
        {
            var type = (CheckEdit)sender;
            if (type.Checked)
            {
                switch (type.Tag)
                {
                    case nameof(CheckedType.Date):
                        navigationFrame1.SelectedPage = pageDate;
                        dateStart.DateTime = DateTime.Now;
                        dateFinish.DateTime = DateTime.Now;
                        break;
                    case nameof(CheckedType.ReceiptNo):
                        navigationFrame1.SelectedPage = pageReceiptNo;
                        tReceiptNo.Focus();
                        break;
                    case nameof(CheckedType.FiscalID):
                        navigationFrame1.SelectedPage = pageFıscal;
                        tFiscalId.Focus();
                        break;
                }
            }
        }

        private async void bSearch_Click(object sender, EventArgs e)
        {
            string filter = string.Empty;
            DateTime start = dateStart.DateTime;
            DateTime finish = dateFinish.DateTime;
            switch (navigationFrame1.SelectedPage)
            {
                case var page when page == pageDate:

                    filter = $@"AND ps.SaleDate BETWEEN '{start:yyyy-MM-dd}' AND '{finish:yyyy-MM-dd}'";
                    break;
                case var page when page == pageReceiptNo:

                    filter = $@"AND ps.ReceiptNo = N'{tReceiptNo.Text.Trim()}'";
                    break;
                case var page when page == pageFıscal:

                    filter = $@"AND ps.ShortFiscalId = N'{tFiscalId.Text.Trim()}'";
                    break;
            }

            var data = await posSaleOperation.PosSaleSummaryAsync(filter);

            gridControlSalesData.DataSource = data;
        }

        private void tReceiptNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bSearch_Click(null, null);
        }

        private void tFiscalId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bSearch_Click(null, null);
        }

        private void bReturnSale_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Point mousePosition = Control.MousePosition;
            popupMenu1.ShowPopup(mousePosition);
        }

        private void barBtnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridSalesData.GetFocusedRow() == null)
            {
                NotificationHelpers.Messages.WarningMessage(this, CommonMessages.NOT_SELECTİON);
                return;
            }

            int rowHandle = gridSalesData.FocusedRowHandle;
            var data = gridSalesData.GetRow(rowHandle) as PosSaleSummaryDto;
            fPosRollbackProduct f = new fPosRollbackProduct(Helpers.Enums.PosReturnType.Rollback, data);
            if (f.ShowDialog() is DialogResult.OK)
                DialogResult = DialogResult.OK;
        }

        private void barBtnReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridSalesData.GetFocusedRow() == null)
            {
                NotificationHelpers.Messages.WarningMessage(this, CommonMessages.NOT_SELECTİON);
                return;
            }

            int rowHandle = gridSalesData.FocusedRowHandle;
            var data = gridSalesData.GetRow(rowHandle) as PosSaleSummaryDto;
            fPosRollbackProduct f = new fPosRollbackProduct(Helpers.Enums.PosReturnType.MoneyBack, data);
            if (f.ShowDialog() is DialogResult.OK)
                DialogResult = DialogResult.OK;
        }

        private void gridSalesData_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "PosSaleItems";
        }

        private void gridSalesData_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gridSalesData_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            var item = (PosSaleSummaryDto)gridSalesData.GetRow(e.RowHandle);
            var result = posSaleItemOperation.GetRemainingSaleData(item.Id);

            e.ChildList = result;
        }

        private class PosSaleDetail
        {
          
        }
    }
}