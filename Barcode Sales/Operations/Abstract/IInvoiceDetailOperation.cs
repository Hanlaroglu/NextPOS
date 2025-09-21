using System.Collections.Generic;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IInvoiceDetailOperation:IBaseOperation<InvoiceDetail>
    {
        void AddRange(List<InvoiceDetail> items);
    }
}
