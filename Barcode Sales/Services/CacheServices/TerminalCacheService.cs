using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;

namespace Barcode_Sales.Services.CacheServices
{
    public class TerminalCacheService
    {
        private static readonly ITerminalOperation terminalOperation = new TerminalManager();

        private static Terminal _terminal;
        public static Terminal Terminal
        {
            get
            {
                if (_terminal == null)
                    RefreshTerminal();

                return _terminal;
            }
        }

        public static async void RefreshTerminal()
        {
            _terminal = await terminalOperation.GetIpAddress();
        }
    }
}
