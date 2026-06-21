using Newtonsoft.Json;

namespace Barcode_Sales.Terminals.Omnitech.Responses
{
    public class ReceiptCopyResponse : BaseResponse
    {
        [JsonProperty("document_number")]
        public int DocumentNumber { get; set; }

        [JsonProperty("long_id")]
        public string LongId { get; set; }

        [JsonProperty("shift_document_number")]
        public int ShiftDocumentNumber { get; set; }

        [JsonProperty("short_id")]
        public string ShortId { get; set; }
    }
}
