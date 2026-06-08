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
        private KhanposDbEntities db = new KhanposDbEntities();
        public async Task<int> Add(PosRefundItem item)
        {
            try
            {
                db.Set<PosRefundItem>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch (Exception ex)
            {
                throw ex;
                return 0;
            }
        }

        public async Task<bool> Add(List<PosRefundItem> items)
        {
            if (items == null || items.Count == 0)
                return false;

            try
            {
                db.Set<PosRefundItem>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
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
