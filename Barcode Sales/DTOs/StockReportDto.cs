namespace Barcode_Sales.DTOs
{
    public class StockReportDto
    {
        public string CategoryName { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public string UnitName { get; set; }
        public string TaxName { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Quantity { get; set; }
    }
}
