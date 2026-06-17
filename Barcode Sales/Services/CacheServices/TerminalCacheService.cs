using System.Threading.Tasks;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;

namespace Barcode_Sales.Services.CacheServices
{
    public class TerminalCacheService
    {
        private static readonly ITerminalOperation terminalOperation = new TerminalManager();

        private static Terminal _terminal;
        public static Terminal Terminal => _terminal;

        public static async Task RefreshTerminal()
        {
            _terminal = await terminalOperation.GetIpAddress();
        }
    }
}
