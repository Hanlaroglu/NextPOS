namespace Barcode_Sales.Terminals
{
    public class TerminalResult
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        private object Data { get; set; }

        public static TerminalResult Ok(string message = "Əməliyyat uğurla tamamlandı", object data = null)
        {
            return new TerminalResult { Success = true, Message = message, Data = data };
        }

        public static TerminalResult Fail(string message, object data = null)
        {
            return new TerminalResult { Success = false, Message = message, Data = data };
        }

        public T GetData<T>() where T : class
        {
            return Data as T;
        }
    }
}