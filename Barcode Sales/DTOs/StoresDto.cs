namespace Barcode_Sales.DTOs
{
    public class StoresDto : Store
    {
        public string WarehouseName { get; set; }
        public string StatusText => Status ? "Aktiv" : "Deaktiv";
    }
}
