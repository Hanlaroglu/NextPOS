namespace Barcode_Sales.DTOs
{
    public class CategoryDto : Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int ProductsCount { get; set; } = 0;
        public bool Status { get; set; }
        public string StatusText
        {
            get { return Status ? "Aktiv" : "Deaktiv"; }
        }
        public bool IsDeleted { get; set; }
        
    }
}
