namespace Barcode_Sales.DTOs
{
    public class ProductInvoiceDto
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Category { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }
        public string TaxName { get; set; }
        public double? PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public string Barcode { get; set; }
        public double? Stock { get; set; } = 0; //Anbar qalığı
        public double Quantity { get; set; } = 1;
        public double TotalPurchaseAmount { get => Quantity * (double)PurchasePrice; }
        public double TotalSaleAmount { get => Quantity * SalePrice; }
        private double _percent;
        public double Percent
        {
            get => _percent;
            set
            {
                _percent = value;
                SalePrice = (double)PurchasePrice * (1 + (_percent / 100));
            }
        }
        public double GainAmount { get => TotalSaleAmount - TotalPurchaseAmount; }
    }
}
