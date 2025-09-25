using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Abstract
{
    public interface ICustomerOperation : IBaseOperation<Customer>
    {
        string Active(Customer item);
        Task ActiveAsync(List<Customer> items);
        string Blocked(Customer item);
        Task BlockedAsync(List<Customer> items);
    }
}
