using Barcode_Sales.Terminals.Omnitech.Models;
using Newtonsoft.Json;

namespace Barcode_Sales.Terminals.Omnitech.Requests
{
    public class DepositRequest
    {
        public CheckData checkData { get; set; } = new CheckData { check_type = Enums.OmnitechCheckType.Deposit };

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        public TokenData tokenData { get; set; }
    }
}
