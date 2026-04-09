using Newtonsoft.Json;
using RestSharp;
using System;

namespace Barcode_Sales.Terminals
{
    public class TerminalHttpHelper
    {
        private static readonly RestClient client = new RestClient();

        public static TResponse Post<TRequest, TResponse>(string ipAddress, TRequest data)
            where TRequest : class
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
                throw new Exception("Terminal IP address boşdur");

            string json = JsonConvert.SerializeObject(data);

            var request = new RestRequest(ipAddress, Method.Post);

            request.AddHeader("Content-Type", "application/json;charset=utf-8");
            request.AddStringBody(json, DataFormat.Json);

            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Terminal request error");

            return JsonConvert.DeserializeObject<TResponse>(response.Content);
        }
    }
}
