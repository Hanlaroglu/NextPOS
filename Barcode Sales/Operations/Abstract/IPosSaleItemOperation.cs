using System.Collections.Generic;
using System.Threading.Tasks;
using Barcode_Sales.DTOs;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IPosSaleItemOperation : IBaseOperation<PosSaleItem>
    {
        List<PosSaleItemDto> GetRemainingSaleData(int posSaleId);
    }
}
