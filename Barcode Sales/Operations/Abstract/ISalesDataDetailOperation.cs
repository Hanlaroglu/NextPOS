using System.Collections.Generic;

namespace Barcode_Sales.Operations.Abstract
{
    public interface ISalesDataDetailOperation:IBaseOperation<SalesDataDetail>
    {
        void InsertRangeSalesDataDetail(List<SalesDataDetail> items);
    }
}