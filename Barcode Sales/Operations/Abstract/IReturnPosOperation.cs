namespace Barcode_Sales.Operations.Abstract
{
    public interface IReturnPosOperation:IBaseOperation<ReturnPos>
    {
        int InsertReturnData(ReturnPos item);
        int CurrentCountTotal();
        double CurrentAmountTotal();
    }
}
