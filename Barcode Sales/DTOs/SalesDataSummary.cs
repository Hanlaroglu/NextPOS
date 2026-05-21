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
        public decimal Cash { get; set; }
        public decimal Card { get; set; }
        public decimal Total { get; set; }
        public string PaymentType { get; set; }
        public string ReceiptNo { get; set; }
        public string ShortFiscalId { get; set; }
        public string LongFiscalId { get; set; }
        public string BankRrn { get; set; }
        public string BankTarnsactionID { get; set; }
        public int RemainingItemCount { get; set; }
    }
}
