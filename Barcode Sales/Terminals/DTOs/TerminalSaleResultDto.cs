namespace Barcode_Sales.Terminals.DTOs
{
    public class TerminalSaleResultDto
    {
        public bool Success { get; set; }
        public string ReceiptNo { get; set; }
        public string LongFiscalId { get; set; }
        public string ShortFiscalId { get; set; }
        public string Rrn { get; set; }
    }
}