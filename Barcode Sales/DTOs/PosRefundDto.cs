using System.ComponentModel;
using System.Linq;

namespace Barcode_Sales.DTOs
{
    public class PosRefundDto
    {
        public int PosSaleId { get; set; }
        public string Cashier { get; set; }
        public decimal Total => Items?.Sum(x => x.TotalAmount) ?? 0;
        public decimal Cash { get; set; }
        public decimal Card { get; set; }
        public decimal Bonus { get; set; }
        public string Note { get; set; } = null;
        public string LongFiscalId { get; set; }
        public string ShortFiscalId { get; set; }
        public string ReceiptNo { get; set; }
        public string BankRrn { get; set; } = null;
        public string BankTransactionId { get; set; }
        public Customer Customer { get; set; }
        public BindingList<PosSaleItemDto> Items { get; set; } = new BindingList<PosSaleItemDto>();
    }
}
