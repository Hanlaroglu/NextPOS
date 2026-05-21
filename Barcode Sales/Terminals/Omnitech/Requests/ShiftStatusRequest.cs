using Barcode_Sales.Terminals.Omnitech.Models;

namespace Barcode_Sales.Terminals.Omnitech.Requests
{
    public class ShiftStatusRequest
    {
        public CheckData checkData { get; set; } = new CheckData { check_type = Enums.OmnitechCheckType.ShiftStatus };
        public string access_token { get; set; }
    }
}
