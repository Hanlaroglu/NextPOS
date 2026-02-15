using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class PosSaleItemManager : IPosSaleItemOperation
    {
        public Task<int> Add(PosSaleItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(List<PosSaleItem> items)
        {
            throw new NotImplementedException();
        }

        public Task<PosSaleItem> Get(Expression<Func<PosSaleItem, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(PosSaleItem item)
        {
            throw new NotImplementedException();
        }

        public Task<List<PosSaleItem>> ToListAsync(Expression<Func<PosSaleItem, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(PosSaleItem item, params Expression<Func<PosSaleItem, object>>[] updateProperties)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(List<PosSaleItem> items, params Expression<Func<PosSaleItem, object>>[] updateProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PosSaleItem> Where(Expression<Func<PosSaleItem, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
