using Barcode_Sales.Terminals.Omnitech.Models;
using Newtonsoft.Json;

namespace Barcode_Sales.Terminals.Omnitech.Requests
{
    public class MoneyBackRequest
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("tokenData")]
        public TokenData TokenData { get; set; }

        [JsonProperty("checkData")]
        public CheckData checkData { get; set; } = new CheckData { check_type = Enums.OmnitechCheckType.MoneyBack };
    }
}
