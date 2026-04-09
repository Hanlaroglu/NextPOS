using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class PosRefundItemManager : IPosRefundItemOperation
    {
        public Task<int> Add(PosRefundItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(List<PosRefundItem> items)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(PosRefundItem item, params Expression<Func<PosRefundItem, object>>[] updateProperties)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(List<PosRefundItem> items, params Expression<Func<PosRefundItem, object>>[] updateProperties)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(PosRefundItem item)
        {
            throw new NotImplementedException();
        }

        public Task<PosRefundItem> Get(Expression<Func<PosRefundItem, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PosRefundItem> Where(Expression<Func<PosRefundItem, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<PosRefundItem>> ToListAsync(Expression<Func<PosRefundItem, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
    }
}
