using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System;
using System.Data;
using System.Linq;

namespace Barcode_Sales.Forms
{
    public partial class fInvoiceDetailsReport : DevExpress.XtraEditors.XtraForm
    {
        private IInvoiceDetailOperation invoiceDetailOperation = new InvoiceDetailManager();
        private readonly Invoice _invoice;
        public fInvoiceDetailsReport(Invoice invoice)
        {
            InitializeComponent();
            _invoice = invoice;
        }

        private async void fInvoiceDetailsReport_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void DataLoad()
        {
            if (_invoice is null) return;

            tDate.Text = _invoice.InvoiceDate.Value.ToShortDateString();
            tContractNo.Text = _invoice.InvoiceNo;
            tWarehouse.Text = _invoice.Warehouse.Name;
            tUser.Text = _invoice.Users.NameSurname;
            tPaymentType.Text = _invoice.PaymentType.Name;
            tTotalPurchase.Text = _invoice.TotalPurchasePrice.Value.ToString("C2");
            tNote.Text = _invoice.Comment;


            var data = invoiceDetailOperation
                .Where(x => x.InvoiceId == _invoice.Id)
                .Select(x=> new InvoiceDetailsDto()
                {
                    ProductName = x.Products.ProductName,
                    Barcode = x.Products.Barcode,
                    Quantity = x.Amount ??0,
                    PurchasePrice = x.PurchasePrice ?? 0,
                    SalePrice = x.SalePrice ?? 0
                })
                .ToList();



            FormHelpers.ControlLoad(data, gridControl2);
        }

        private class InvoiceDetailsDto
        {
            public string ProductName { get; set; }
            public string Barcode { get; set; }
            public double PurchasePrice { get; set; }
            public double Quantity { get; set; }
            public double TotalPurchasePrice { get => PurchasePrice * Quantity; }
            public double SalePrice { get; set; }
            public double TotalSalePrice
            {
                get => SalePrice * Quantity;
            }
            public double Gain
            {
                get => TotalSalePrice - TotalPurchasePrice;
            }
        }

    }
}