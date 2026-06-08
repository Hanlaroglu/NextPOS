namespace Barcode_Sales.Terminals.Omnitech.Models
{
    public class TokenData
    {
        public Parameters parameters { get; set; }
        public string operationId { get; set; } = null;
        public int? version { get; set; } = null;
    }
}