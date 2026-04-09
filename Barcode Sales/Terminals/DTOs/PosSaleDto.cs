using System.ComponentModel;
using System.Linq;

namespace Barcode_Sales.Terminals.DTOs
{
    public class PosSaleDto : BaseDto
    {
        public string CashierName { get; set; }
        public decimal Total => Items?.Sum(x => x.Total) ?? 0;
        public decimal Cash { get; set; }
        public decimal Card { get; set; }
        public decimal IncomingSum { get; set; }
        public decimal Bonus { get; set; }
        public string Note { get; set; }
        public string Rrn { get; set; }
        public Customer Customer { get; set; }
        public BindingList<PosSaleItemDto> Items { get; set; } = new BindingList<PosSaleItemDto>();
    }
}
