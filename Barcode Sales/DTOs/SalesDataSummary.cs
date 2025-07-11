using System;

namespace Barcode_Sales.DTOs
{
    public class SalesDataSummary
    {
        public int Id { get; set; }
        public DateTime? SaleDateTime { get; set; }
        public string Cashier { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public double Cash { get; set; }
        public double Card { get; set; }
        public double Total { get; set; }
        public string PaymentType { get; set; }
        public string ReceiptNo { get; set; }
        public string ShortFiscalId { get; set; }
        public string LongFiscalId { get; set; }
        public string RRN { get; set; }
        public int RemainingItemCount { get; set; }
    }
}
