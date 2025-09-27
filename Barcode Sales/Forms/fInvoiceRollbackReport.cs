using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fInvoiceRollbackReport : DevExpress.XtraEditors.XtraForm
    {
        private IInvoiceRollbackOperation invoiceRollbackOperation = new InvoiceRollbackManager();
        public fInvoiceRollbackReport()
        {
            InitializeComponent();
        }

        private void fInvoiceRollbackReport_Load(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            dateStart.DateTime = dateTime;
            dateEnd.DateTime = dateTime;
        }

        private async Task ReportLoad()
        {
            if (dateStart.EditValue is null || dateEnd.EditValue is null) return;

            DateTime start = dateStart.DateTime;
            DateTime end = dateEnd.DateTime;


            if (!ValidationHelpers.IsValidDate(start.ToString()) ||
                !ValidationHelpers.IsValidDate(end.ToString()))
            {
                NotificationHelpers.Messages.ErrorMessage(this, "Tarix formatı düzgün seçilmədi");
                return;
            }

            if (start > end)
            {
                NotificationHelpers.Messages.ErrorMessage(this, "Başlanğıc tarixi bitiş tarixindən böyük ola bilməz!");
                return;
            }

            var data = await invoiceRollbackOperation.Report(start, end);
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
    }
}