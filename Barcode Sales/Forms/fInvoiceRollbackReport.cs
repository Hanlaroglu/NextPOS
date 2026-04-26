using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Services.CacheServices;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fInvoiceRollbackReport : DevExpress.XtraEditors.XtraForm
    {
        private IInvoiceRollbackOperation invoiceRollbackOperation = new InvoiceRollbackManager();
        private IInvoiceRollbackDetailOperation invoiceRollbackDetailOperation = new InvoiceRollbackDetailManager();
        IInvoiceDetailOperation invoiceDetailOperation = new InvoiceDetailManager();

        public fInvoiceRollbackReport()
        {
            InitializeComponent();
        }

        private void fInvoiceRollbackReport_Shown(object sender, EventArgs e)
        {
            dateStart.DateTime = DatetimeService.FirstDayOfCurrentMonth;
            dateEnd.DateTime = DatetimeService.CurrentDateTime;
        }

        private async Task ReportLoad()
        {
            if (dateStart.EditValue is null || dateEnd.EditValue is null) return;

            DateTime start = dateStart.DateTime;
            DateTime end = dateEnd.DateTime;

            if (start > end)
            {
                NotificationHelpers.Messages.ErrorMessage(this, "Başlanğıc tarixi bitiş tarixindən böyük ola bilməz!");
                return;
            }

            var data = await invoiceRollbackOperation.ToListAsync(x => x.RollbackDate >= start &&
                                                                       x.RollbackDate <= end && x.IsDeleted == false);
            FormHelpers.ControlLoad(data, gridControl1);
        }

        private async void bSearch_Click(object sender, EventArgs e)
        {
            await ReportLoad();
        }

        private async void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
                await ReportLoad();
        }

        private void bDetail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void bInvoiceDetail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private  void gridView1_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            var data = (InvoiceRollback)gridView1.GetRow(e.RowHandle);
            if (data != null)
            {
                var childData = invoiceRollbackDetailOperation.Where(x => x.InvoiceRollbackId == data.Id)
                    .ToList();

                var data1 = invoiceRollbackDetailOperation.InvoiceRollbackDetailReport(data.Id);

                e.ChildList = data1;
            }
        }

        private void gridView1_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "InvoiceRollbackDetails";
        }

        private void gridView1_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }
    }
}