using Newtonsoft.Json;

namespace Barcode_Sales.Terminals.Omnitech.Responses
{
    public class DepositResponse : BaseResponse
    {
        [JsonProperty("document_number")]
        public int documentNumber { get; set; }

        [JsonProperty("long_id")]
        public string longId { get; set; }

        [JsonProperty("short_id")]
        public string shortId { get; set; }

        [JsonProperty("shift_document_number")]
        public int ShiftDocumentNumber { get; set; }
    }
}
