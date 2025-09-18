namespace Barcode_Sales.Operations.Abstract
{
    public interface IInvoiceOperation:IBaseOperation<Invoice>
    {
        int AddInvoice(Invoice item);
    }
}
