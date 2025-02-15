using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Abstract
{
    public interface ISupplierOperation:IBaseOperation<Suppliers>
    {
        string Blocked(Suppliers item);
        Task BlockedAsync(List<Suppliers> items);
        string Active(Suppliers item);
        Task ActiveAsync(List<Suppliers> items);

    }
}