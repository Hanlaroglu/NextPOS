using System.Collections.Generic;

namespace Barcode_Sales.Operations.Abstract
{
    public interface ITaxTypeOperation:IBaseOperation<TaxType>
    {
        Dictionary<int, string> Initialize();
    }
}
