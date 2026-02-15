namespace Barcode_Sales.DTOs
{
    public class ProductDto : Product
    {
        public string TaxName { get; set; }
        public string UnitName { get; set; }
        public string StatusText
        {
            get { return Status.GetValueOrDefault() ? "Aktiv" : "Deaktiv"; }
        }
    }
}
