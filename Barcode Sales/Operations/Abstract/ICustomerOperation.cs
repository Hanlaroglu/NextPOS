using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Abstract
{
    public interface ICustomerOperation : IBaseOperation<Customers>
    {
        string Active(Customers item);
        Task ActiveAsync(List<Customers> items);
        string Blocked(Customers item);
        Task BlockedAsync(List<Customers> items);
    }
}
