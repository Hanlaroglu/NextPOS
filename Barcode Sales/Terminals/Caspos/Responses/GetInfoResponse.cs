using System.Text.Json.Serialization;

namespace Barcode_Sales.Terminals.Caspos.Responses
{
    public class GetInfoResponse : BaseResponse
    {
        [JsonPropertyName("application_version")]
        public string ApplicationVersion { get; set; }

        [JsonPropertyName("cashregister_model")]
        public string CashRegisterModel { get; set; }

        [JsonPropertyName("cashbox_tax_number")]
        public string CashboxTaxNumber { get; set; }

        [JsonPropertyName("cashbox_factory_number")]
        public string CashboxFactoryNumber { get; set; }

        [JsonPropertyName("cashregister_factory_number")]
        public string CashRegisterFactoryNumber { get; set; }

        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("company_tax_number")]
        public string CompanyTaxNumber { get; set; }

        [JsonPropertyName("last_doc_number")]
        public int LastDocNumber { get; set; }

        [JsonPropertyName("last_online_time")]
        public string LastOnlineTime { get; set; }

        [JsonPropertyName("object_address")]
        public string ObjectAddress { get; set; }

        [JsonPropertyName("object_name")]
        public string ObjectName { get; set; }

        [JsonPropertyName("object_tax_number")]
        public string ObjectTaxNumber { get; set; }

        [JsonPropertyName("qr_code_url")]
        public string QrCodeUrl { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("token_version")]
        public string TokenVersion { get; set; }
    }
}