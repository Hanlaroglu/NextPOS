using Barcode_Sales.Helpers;

namespace Barcode_Sales.DTOs
{
    public class PosChangeType
    {
        public decimal Amount { get; set; }
        public string UnitName { get; set; }
        public Enums.PosChangeType ChangeType { get; set; }
    }
}
