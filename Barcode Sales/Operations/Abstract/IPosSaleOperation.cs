using Barcode_Sales.DTOs;
using Barcode_Sales.Terminals.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IPosSaleOperation : IBaseOperation<PosSale>
    {
        Task<int> CurrentSaleCount();
        Task<string> CurrentSalesDataAsync();
        Task<string> CurrentSalesCountAsync();
        Task<List<DashboardSalePayTypeDto>> CurrentPaymentTypeDataAsync();
        Task<TopSellingProductDto> TopSellingProducts();
        Task<List<PosSaleSummaryDto>> PosSaleSummaryAsync(string filter);
    }
}
