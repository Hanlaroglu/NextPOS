using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IProductOperation : IBaseOperation<Products>
    {
        int AddProduct(Products item);
        void StatusChanged(Products item);
        Task<bool> BarcodeCheckAsync(string barcode, int supplierId);
        Task<Products> GetByBarcodeAsync(string barcode);
    }
}