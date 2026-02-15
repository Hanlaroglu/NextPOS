namespace Barcode_Sales.DTOs
{
    public class CategoryDto : Category
    {
        public string StatusText
        {
            get { return Status.GetValueOrDefault() ? "Aktiv" : "Deaktiv"; }
        }
    }
}
