namespace Barcode_Sales.Operations.Abstract
{
    public interface ISupplierDebtOperation : IBaseOperation<SuppliersDebt>
    {
        decimal SupplierTotalDebt(int supplierId);
    }
}
