using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IProductOperation : IBaseOperation<Product>
    {
        void StatusChanged(Product item);
        Task<bool> BarcodeCheckAsync(string barcode, int supplierId);
        Task<Product> GetByBarcodeAsync(string barcode);
    }
}