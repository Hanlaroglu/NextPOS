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

            tDate.Text = _invoice.InvoiceDate.ToShortDateString();
            tContractNo.Text = _invoice.InvoiceNo;
            tWarehouse.Text = _invoice.Warehouse.Name;
            tUser.Text = _invoice.User.NameSurname;
            tTotalPurchase.Text = _invoice.TotalPurchasePrice.ToString("C2");
            tNote.Text = _invoice.Comment;


            var data = invoiceDetailOperation
                .Where(x => x.InvoiceId == _invoice.Id)
                .Select(x=> new InvoiceDetailsDto()
                {
                    ProductName = x.Product.ProductName,
                    Barcode = x.Product.Barcode,
                    Quantity = x.Amount,
                    PurchasePrice = x.PurchasePrice,
                    SalePrice = x.SalePrice
                })
                .ToList();



            FormHelpers.ControlLoad(data, gridControl2);
        }

        private class InvoiceDetailsDto
        {
            public string ProductName { get; set; }
            public string Barcode { get; set; }
            public decimal PurchasePrice { get; set; }
            public decimal Quantity { get; set; }
            public decimal TotalPurchasePrice { get => PurchasePrice * Quantity; }
            public decimal SalePrice { get; set; }
            public decimal TotalSalePrice
            {
                get => SalePrice * Quantity;
            }
            public decimal Gain
            {
                get => TotalSalePrice - TotalPurchasePrice;
            }
        }

    }
}