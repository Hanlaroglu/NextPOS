using System.ComponentModel;
using System.Linq;

namespace Barcode_Sales.Terminals.DTOs
{
    public class PosSaleDto
    {
        public string Cashier { get; set; }
        public decimal Total => Items?.Sum(x => x.Total) ?? 0;
        public decimal Cash { get; set; }
        public decimal Card { get; set; }
        public decimal IncomingSum { get; set; }
        public decimal Bonus { get; set; }
        public string Note { get; set; } = null;
        public string Rrn { get; set; } = null;
        public Customer Customer { get; set; }
        public string CustomerName { get; set; } //Test üçün istifadə olunur. Digər hallarda Customer classsindan istifadə olunacaq
        public BindingList<PosSaleItemDto> Items { get; set; } = new BindingList<PosSaleItemDto>();
    }
}
