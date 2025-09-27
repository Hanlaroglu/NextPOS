using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentValidation;
using Barcode_Sales.Validations;

namespace Barcode_Sales.Forms
{
    public partial class fInvoiceReport : DevExpress.XtraEditors.XtraForm
    {
        private IInvoiceOperation invoiceOperation = new InvoiceManager();
        public fInvoiceReport()
        {
            InitializeComponent();
        }

        private void fInvoiceReport_Load(object sender, EventArgs e)
        {
            dateStart.DateTime = DateTime.Now;
            dateEnd.DateTime = DateTime.Now.AddDays(1);
        }

        private async void bSearch_Click(object sender, EventArgs e)
        {
            await ReportLoad();
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

            var data = await invoiceOperation.InvoiceReport(start, end);
            FormHelpers.ControlLoad(data,gridControl1);
        }

        private async void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
                await ReportLoad();
        }

        private void bDetail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var data = gridView1.GetFocusedRow() as Invoice;
            if (data is null) return;
            fInvoiceDetailsReport f = new fInvoiceDetailsReport(data);
            f.ShowDialog();
        }
    }
}