﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IInvoiceOperation:IBaseOperation<Invoice>
    {
        int AddInvoice(Invoice item);
        Task<List<Invoice>> InvoiceReport(DateTime start,DateTime end);
    }
}
