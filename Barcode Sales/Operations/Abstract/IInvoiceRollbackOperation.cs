using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IInvoiceRollbackOperation:IBaseOperation<InvoiceRollback>
    {
        int AddRollback(InvoiceRollback item);
        Task<List<InvoiceRollback>> Report(DateTime start, DateTime end);
    }
}
