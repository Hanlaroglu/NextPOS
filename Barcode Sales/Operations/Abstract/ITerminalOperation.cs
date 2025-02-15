using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Abstract
{
    public interface ITerminalOperation : IBaseOperation<Terminals>
    {
        string GetIpAddress();
    }
}