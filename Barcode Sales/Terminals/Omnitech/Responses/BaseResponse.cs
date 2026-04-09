namespace Barcode_Sales.Terminals.Omnitech.Responses
{
    public abstract class BaseResponse
    {
        public int code { get; set; }
        public string message { get; set; }
    }
}