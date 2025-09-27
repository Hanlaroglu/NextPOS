using System.Threading.Tasks;
using static Barcode_Sales.DTOs.DashboardUIDto;

namespace Barcode_Sales.Operations.Abstract
{
    public interface ISaleDataOperation:IBaseOperation<SalesData>
    {
        int InsertSaleData(SalesData item);
        Task<string> SalesCount();
        Task<string> CurrentSalesDataAsync();
        Task<PaymentTypeTotal> CurrentPaymentTypeDataAsync();
    }
}
