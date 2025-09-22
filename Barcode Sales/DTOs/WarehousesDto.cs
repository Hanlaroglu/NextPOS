namespace Barcode_Sales.DTOs
{
    public class WarehousesDto : Warehouses
    {
        public string StatusText
        {
            get { return Status.GetValueOrDefault() ? "Aktiv" : "Deaktiv"; }
        }
    }
}
