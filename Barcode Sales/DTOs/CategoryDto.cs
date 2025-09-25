namespace Barcode_Sales.DTOs
{
    public class CategoryDto : Categories
    {
        public string StatusText
        {
            get { return Status.GetValueOrDefault() ? "Aktiv" : "Deaktiv"; }
        }
    }
}
