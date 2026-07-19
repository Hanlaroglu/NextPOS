using Barcode_Sales.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IProductOperation : IBaseOperation<Product>
    {
        Task<List<StockReportDto>> StockReport();
        Task<List<HotSaleProductDto>> HotSaleProducts();
    }
}