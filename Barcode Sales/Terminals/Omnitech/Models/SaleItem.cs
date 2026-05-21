using Newtonsoft.Json;

namespace Barcode_Sales.Terminals.Omnitech.Models
{
    public class SaleItem
    {
        [JsonProperty("itemName")]
        public string ItemName { get; set; }

        [JsonProperty("itemCodeType")]
        public int ItemCodeType { get; set; }

        [JsonProperty("itemCode")]
        public string ItemCode { get; set; }

        [JsonProperty("itemQuantityType")]
        public int ItemQuantityType { get; set; }

        [JsonProperty("itemQuantity")]
        public decimal ItemQuantity { get; set; }

        [JsonProperty("itemPrice")]
        public decimal ItemPrice { get; set; }

        [JsonProperty("itemSum")]
        public decimal ItemSum { get; set; }

        [JsonProperty("itemVatPercent")]
        public decimal ItemVatPercent { get; set; }

        [JsonProperty("discount")]
        public decimal Discount { get; set; }
    }
}
