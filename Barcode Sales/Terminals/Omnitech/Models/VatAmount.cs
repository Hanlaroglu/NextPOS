using Newtonsoft.Json;

namespace Barcode_Sales.Terminals.Omnitech.Models
{
    public class VatAmount
    {
        [JsonProperty("vatSum")]
        public decimal VatSum { get; set; }

        [JsonProperty("vatPercent")]
        public decimal VatPercent { get; set; }
    }
}
