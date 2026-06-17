using Newtonsoft.Json;
using System;

namespace Barcode_Sales.Terminals.Omnitech.Responses
{
    public class GetInfoResponse : BaseResponse
    {
        public Data data { get; set; }
        public class Data
        {
            [JsonProperty("cashbox_factory_number")]
            public string CashboxFactoryNumber { get; set; }

            [JsonProperty("cashbox_tax_number")]
            public string CasboxTaxNumber { get; set; } 
            
            [JsonProperty("cashregister_factory_number")]
            public string CashregisterFactoryNumber { get; set; }

            [JsonProperty("cashregister_model")]
            public string CashregisterModel { get; set; }

            [JsonProperty("company_name")]
            public string CompanyName { get; set; }

            [JsonProperty("company_tax_number")] 
            public string CompanyTaxNUmber { get; set; }

            [JsonProperty("firmware_version")]
            public string FirmwareVersion { get; set; }

            [JsonProperty("last_doc_number")] 
            public string LastDocumentNumber { get; set; }

            [JsonProperty("last_online_time")] 
            public DateTime LastOnlineTime { get; set; }

            [JsonProperty("not_after")] 
            public DateTime NotAfter { get; set; }

            [JsonProperty("not_before")] 
            public DateTime NotBefore { get; set; }

            [JsonProperty("object_address")] 
            public string ObjectAddress { get; set; }

            [JsonProperty("object_name")] 
            public string ObjectName { get; set; }

            [JsonProperty("object_tax_number")]
            public string ObjectTaxNumber { get; set; }

            [JsonProperty("qr_code_url")] 
            public string QrCodeUrl { get; set; }

            [JsonProperty("state")] 
            public string State { get; set; }
        }
    }
}
