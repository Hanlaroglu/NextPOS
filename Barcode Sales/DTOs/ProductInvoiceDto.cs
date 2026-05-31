namespace Barcode_Sales.DTOs
{
    public class ProductInvoiceDto
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public string UnitName { get; set; }
        public string TaxName { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal? Stock { get; set; } = 0; //Anbar qalığı
        public decimal Quantity { get; set; } = 1;
    }
}
