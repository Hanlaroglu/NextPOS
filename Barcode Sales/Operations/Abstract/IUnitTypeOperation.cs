using System.Collections.Generic;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IUnitTypeOperation : IBaseOperation<UnitType>
    {
        Dictionary<int, string> Initialize();
    }
}
