using Barcode_Sales.Terminals.Omnitech.Models;

namespace Barcode_Sales.Terminals.Omnitech.Requests
{
    public class WithdrawRequest
    {
        public CheckData checkData { get; set; } = new CheckData { check_type = Enums.OmnitechCheckType.Withdraw };
        public string access_token { get; set; }
        public TokenData tokenData { get; set; }
    }
}