using Barcode_Sales.Terminals.Omnitech.Models;

namespace Barcode_Sales.Terminals.Omnitech.Requests
{
    public class OpenShiftRequest
    {
        public CheckData checkData { get; set; } = new CheckData { check_type = Enums.OmnitechCheckType.OpenShift };
        public string access_token { get; set; }
    }
}