namespace Barcode_Sales.DTOs
{
    public class InvoiceRollbackDetailDto
    {
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public string ProductCode { get; set; }
        public decimal TotalPurchasePrice { get; set; }
        public string UnitName { get; set; }
        public decimal Quantity { get; set; }
    }
}
