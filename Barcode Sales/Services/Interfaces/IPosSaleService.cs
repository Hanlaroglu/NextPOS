using Barcode_Sales.Terminals.DTOs;
using System.Threading.Tasks;

namespace Barcode_Sales.Services.Interfaces
{
    public interface IPosSaleService
    {
        Task<int> CompleteSaleAsync(PosSaleDto sale, TerminalSaleResultDto terminal);
    }
}
