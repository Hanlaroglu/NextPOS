using Barcode_Sales.Terminals.Omnitech.Models;
using Newtonsoft.Json;

namespace Barcode_Sales.Terminals.Omnitech.Requests
{
    public class RollbackRequest
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; } 
        
        [JsonProperty("fiscalId")]
        public string FiscalId { get; set; }

        [JsonProperty("checkData")]
        public CheckData checkData { get; set; } = new CheckData { check_type = Enums.OmnitechCheckType.Rollback };
    }
}
