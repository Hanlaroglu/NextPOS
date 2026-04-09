namespace Barcode_Sales.DTOs
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Voen { get; set; }
        public decimal Debt { get; set; }
        public string Status { get; set; }
        public bool StatusType { get; set; }
    }
}
