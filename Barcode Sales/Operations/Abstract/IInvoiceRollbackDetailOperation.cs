using Barcode_Sales.DTOs;
using System.Collections.Generic;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IInvoiceRollbackDetailOperation : IBaseOperation<InvoiceRollbackDetail>
    {
        List<InvoiceRollbackDetailDto> InvoiceRollbackDetailReport(int rollbackId);
    }
}