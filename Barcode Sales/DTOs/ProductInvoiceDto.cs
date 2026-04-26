namespace Barcode_Sales.DTOs
{
    public class ProductInvoiceDto
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }
        public string TaxName { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public string Barcode { get; set; }
        public decimal? Stock { get; set; } = 0; //Anbar qalığı
        public decimal Quantity { get; set; } = 1;
        public decimal TotalPurchaseAmount { get => Quantity * PurchasePrice; }
        public decimal TotalSaleAmount { get => Quantity * SalePrice; }
        private decimal _percent;
        public decimal Percent
        {
            get => _percent;
            set
            {
                _percent = value;
                SalePrice = PurchasePrice * (1 + (_percent / 100));
            }
        }
        public decimal GainAmount { get => TotalSaleAmount - TotalPurchaseAmount; }
    }
}
