namespace Barcode_Sales.DTOs
{
    public class TerminalDto : Terminal
    {
        public string CashierName { get; set; }
        public string StatusName => IsStatus ? "Aktiv" : "Deaktiv";
    }
}