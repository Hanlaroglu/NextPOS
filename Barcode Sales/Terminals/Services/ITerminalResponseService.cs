namespace Barcode_Sales.Terminals.Services
{
    public interface ITerminalResponseService
    {
        int code { get; set; }
        string message { get; set; }
        bool IsSuccess { get; }
    }
}