using Newtonsoft.Json;
using System;

namespace Barcode_Sales.Terminals.Omnitech.Responses
{
    public class ShiftStatusResponse : BaseResponse
    {
        public string desc { get; set; }
        public string serial { get; set; }
        [JsonProperty("shiftStatus")]
        public bool ShiftStatus { get; set; }
        [JsonProperty("shift_open_time")]
        public DateTime? ShiftOpenTime{ get; set; }
    }
}
