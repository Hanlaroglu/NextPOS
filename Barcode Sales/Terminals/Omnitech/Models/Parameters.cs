using Newtonsoft.Json;

namespace Barcode_Sales.Terminals.Omnitech.Models
{
    public class Parameters
    {
        [JsonProperty("doc_type")] 
        public string DocType { get; set; } = null;
        public object data { get; set; }
    }
}