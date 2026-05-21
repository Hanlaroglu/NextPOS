using Newtonsoft.Json;
using System.Collections.Generic;

namespace Barcode_Sales.Terminals.Omnitech.Models
{
    public class SaleData
    {
        [JsonProperty("cashier")]
        public string Cashier { get; set; }

        [JsonProperty("currency")] 
        public string Currency { get; set; } = "AZN";

        [JsonProperty("items")]
        public List<SaleItem> Items { get; set; }

        [JsonProperty("sum")]
        public decimal Sum { get; set; }

        [JsonProperty("cashSum")]
        public decimal CashSum { get; set; }

        [JsonProperty("cashlessSum")]
        public decimal CashlessSum { get; set; }

        [JsonProperty("prepaymentSum")]
        public decimal PrepaymentSum { get; set; }

        [JsonProperty("creditSum")]
        public decimal CreditSum { get; set; }

        [JsonProperty("bonusSum")]
        public decimal BonusSum { get; set; }

        [JsonProperty("incomingSum")]
        public decimal IncomingSum { get; set; }

        [JsonProperty("rrn")] 
        public string Rrn { get; set; }

        [JsonProperty("vatAmounts")]
        public List<VatAmount> VatAmounts { get; set; }
    }
}
