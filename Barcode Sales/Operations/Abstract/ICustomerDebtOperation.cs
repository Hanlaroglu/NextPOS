namespace Barcode_Sales.Operations.Abstract
{
    public interface ICustomerDebtOperation:IBaseOperation<CustomersDebt>
    {
        double CustomersTotalDebt(int customerId);
    }
}
