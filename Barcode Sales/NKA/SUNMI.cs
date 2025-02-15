using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.NKA
{
    public static class SUNMI
    {
        private static ResponseRoot RequestPOST(string url, string json)
        {
            RestClient rest = new RestClient();
            RestRequest request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json;charset=utf-8");
            request.AddStringBody(json, DataFormat.Json);
            RestResponse restResponse = rest.Execute(request);

            ResponseRoot response = System.Text.Json.JsonSerializer.Deserialize<ResponseRoot>(restResponse.Content);

            return response;
        }

        private static void OpenShift(string ipAddress, string cashierName)
        {
            RequestRoot request = new RequestRoot
            {
                cashierName = cashierName
            };

            string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var response = RequestPOST(ipAddress, json);

            if (response.message == "Növbə artıq açıqdır")
            {

            }
        }
    }

    #region [...REQUEST CLASSESS...]
    public class Item
    {
        public string name { get; set; }
        public string code { get; set; }
        public double quantity { get; set; }
        public decimal salePrice { get; set; }
        public double? realPrice { get; set; } = null;
        public decimal? purchasePrice { get; set; } = null;
        public int? codeType { get; set; } = null;
        public int quantityType { get; set; }
        public int vatType { get; set; }
        public double? discountAmount { get; set; } = null;
    }

    public class Data
    {
        public DateTime? startDate { get; set; } = null;
        public DateTime? endDate { get; set; } = null;
        public string parentDocumentId { get; set; } = null;
        public string documentUUID { get; set; } = null;
        public decimal? cashPayment { get; set; } = null;
        public decimal? creditPayment { get; set; } = null;
        public decimal? depositPayment { get; set; } = null;
        public decimal? cardPayment { get; set; } = null;
        public decimal? bonusPayment { get; set; } = null;
        public List<Item> items { get; set; } = null;
        public int? moneyBackType { get; set; } = null;
        public string clientName { get; set; } = "YENİ MÜŞTƏRİ";
        public double? clientTotalBonus { get; set; } = null;
        public double? clientEarnedBonus { get; set; } = null;
        public string clientBonusCardNumber { get; set; } = null;
        public string cashierName { get; set; } = null;
        public string rrn { get; set; } = null;
        public string currency { get; set; } = "AZN";
        public string creditPayer { get; set; } = null;
        public double? residue { get; set; } = null;
        public string creditContract { get; set; } = null;
        public string paymentNumber { get; set; } = null;
        public string note { get; set; } = null;
    }

    public class RequestRoot
    {
        public Data data { get; set; }
        public string cashierName { get; set; }
        public string operation { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

    #endregion [...REQUEST CLASSESS...]


    #region [..RESPONSE CLASSESS..]

    public class ResponseData
    {
        public string document_id { get; set; }
        public int document_number { get; set; }
        public string number { get; set; }
        public int shift_document_number { get; set; }
        public string short_document_id { get; set; }
        public decimal totalSum { get; set; }
        public bool shift_open { get; set; }
        public string shift_open_time { get; set; }
    }

    public class ResponseRoot
    {
        public ResponseData data { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }

    #endregion [..RESPONSE CLASSESS..]
}