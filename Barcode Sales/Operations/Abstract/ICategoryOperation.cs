namespace Barcode_Sales.Operations.Abstract
{
    public interface ICategoryOperation : IBaseOperation<Categories>
    {
        void StatusUpdate(Categories item);
    }
}