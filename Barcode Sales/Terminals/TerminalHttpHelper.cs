using Barcode_Sales.Terminals.Services;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace Barcode_Sales.Terminals
{
    public class TerminalHttpHelper
    {
        public static TerminalResult Post<TRequest, TResponse>(string ipAddress, TRequest data)
            where TRequest : class
            where TResponse : class, ITerminalResponseService
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
                return TerminalResult.Fail("Terminal IP addresi boşdur");

            var json = JsonConvert.SerializeObject(data);

            try
            {
                using (RestClient client = new RestClient())
                {
                    var request = new RestRequest(ipAddress, Method.Post);
                    request.AddHeader("Content-Type", "application/json;charset=utf-8");
                    request.AddStringBody(json, DataFormat.Json);

                    var response = client.Execute(request);

                    if (!response.IsSuccessful)
                        return TerminalResult.Fail($"Terminal ilə əlaqə xətası\n\n{response.ErrorMessage}");

                    var result = JsonConvert.DeserializeObject<TResponse>(response.Content);

                    if (result == null)
                        return TerminalResult.Fail("Cavab boşdur");

                    if (result.message is "login success")
                        return TerminalResult.Ok(result.message, result);

                    if (result.IsSuccess)
                        return TerminalResult.Ok(result.message, result);

                    return TerminalResult.Fail(result.message);
                }
            }
            catch (Exception e)
            {
                return TerminalResult.Fail("Xəta: " + e.Message);
            }
        }
    }
}