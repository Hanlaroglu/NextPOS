using System.Threading.Tasks;
using Barcode_Sales.DTOs;
using static Barcode_Sales.DTOs.DashboardUIDto;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IPosSaleOperation : IBaseOperation<PosSale>
    {
        Task<int> CurrentSaleCount();
        Task<string> CurrentSalesDataAsync();
        Task<string> CurrentSalesCountAsync();
        Task<PaymentTypeTotal> CurrentPaymentTypeDataAsync();
        Task<TopSellingProductDto> TopSellingProducts();
    }
}
