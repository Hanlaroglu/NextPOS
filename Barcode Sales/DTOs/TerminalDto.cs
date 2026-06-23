namespace Barcode_Sales.DTOs
{
    public class TerminalDto : Terminal
    {
        public string StatusName => IsStatus ? "Aktiv" : "Deaktiv";
    }
}