namespace Barcode_Sales.Operations.Abstract
{
    public interface IProductOperation : IBaseOperation<Products>
    {
        void StatusChanged(Products item);
    }
}