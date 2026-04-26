using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IInvoiceRollbackOperation:IBaseOperation<InvoiceRollback>
    {
        Task<List<view_InvoiceRollbackList>> RollbackList(int supplierId, DateTime? start = null,
            DateTime? end = null);
    }
}
