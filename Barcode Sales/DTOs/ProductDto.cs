namespace Barcode_Sales.DTOs
{
    public class ProductDto : Product
    {
        public string CategoryName { get; set; }
        public string TaxName { get; set; }
        public string UnitName { get; set; }
        public string StatusText
        {
            get { return IsActive ? "Aktiv" : "Deaktiv"; }
        }
    }
}
