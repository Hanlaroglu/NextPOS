namespace Barcode_Sales.DTOs
{
    public class ScaleDto : Scale
    {
        public string StatusName => IsActive ? "Aktiv" : "Deaktiv";
    }
}
