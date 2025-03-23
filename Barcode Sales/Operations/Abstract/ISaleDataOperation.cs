namespace Barcode_Sales.Operations.Abstract
{
    public interface ISaleDataOperation:IBaseOperation<SalesData>
    {
        int InsertSaleData(SalesData item);
    }
}
