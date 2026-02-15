namespace Barcode_Sales.DTOs
{
    public class WarehousesDto : Warehouse
    {
        public string StatusText
        {
            get { return Status.GetValueOrDefault() ? "Aktiv" : "Deaktiv"; }
        }
    }
}
