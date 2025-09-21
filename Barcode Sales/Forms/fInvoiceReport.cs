using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System;
using System.Threading.Tasks;
using FluentValidation;

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

        private void bDetail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private async Task ReportLoad()
        {
            var data = await invoiceOperation.InvoiceReport(dateStart.DateTime, dateEnd.DateTime);
            FormHelpers.ControlLoad(data,gridControl1);
        }
    }
}