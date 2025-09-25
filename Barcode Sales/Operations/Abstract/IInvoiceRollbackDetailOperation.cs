using System.Collections.Generic;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IInvoiceRollbackDetailOperation : IBaseOperation<InvoiceRollbackDetail>
    {
        void AddRange(List<InvoiceRollbackDetail> items);
    }
}
