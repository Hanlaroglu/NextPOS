using System.Collections.Generic;

namespace Barcode_Sales.Operations.Abstract
{
    public interface IReturnPosDetailOperation:IBaseOperation<ReturnPosDetail>
    {
        void InsertRangeReturnDataDetail(List<ReturnPosDetail> items);
    }
}
