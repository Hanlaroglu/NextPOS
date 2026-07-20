using Newtonsoft.Json;
using System;

namespace Barcode_Sales.Terminals.Caspos.Responses
{
    public class GetShiftStatusResponse : BaseResponse
    {
        public Data data { get; set; }
        public class Data
        {
            [JsonProperty("shift_open")]
            public bool ShiftOpen { get; set; }

            [JsonProperty("shift_open_time")]
            public string ShiftOpenTime { get; set; }
        }
    }
}
