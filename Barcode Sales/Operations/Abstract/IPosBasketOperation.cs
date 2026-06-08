using System.Collections.Generic;
using System.Threading.Tasks;
using Barcode_Sales.DTOs;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IPosBasketOperation : IBaseOperation<PosBasket>
    {
        string LastBasketNumber();
        Task<List<PosBasketDto>> GetBaskets();
    }
}
