namespace Barcode_Sales.Operations.Abstract
{
    public interface ISupplierDebtOperation : IBaseOperation<SuppliersDebt>
    {
        double SupplierTotalDebt(int supplierId);
    }
}
