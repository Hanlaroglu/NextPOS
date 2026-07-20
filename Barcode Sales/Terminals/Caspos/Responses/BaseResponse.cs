using Barcode_Sales.Terminals.Services;

namespace Barcode_Sales.Terminals.Caspos.Responses
{
    public abstract class BaseResponse : ITerminalResponseService
    {
        public int code { get; set; }
        public string message { get; set; }
        public bool IsSuccess
        {
            get { return code == 0; }
        }
    }
}