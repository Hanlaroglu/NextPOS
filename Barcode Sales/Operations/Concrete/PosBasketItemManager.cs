using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Barcode_Sales.Operations.Abstract;

namespace Barcode_Sales.Operations.Concrete
{
    public class PosBasketItemManager : IPosBasketItemOperation
    {
        private KhanposDbEntities db = new KhanposDbEntities();
        public async Task<int> Add(PosBasketItem item)
        {
            try
            {
                db.Set<PosBasketItem>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch (Exception ex)
            {
                throw ex;
                throw;
            }
        }

        public async Task<bool> Add(List<PosBasketItem> items)
        {
            if (items == null || items.Count == 0)
                return false;

            try
            {
                db.Set<PosBasketItem>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public Task<bool> Update(PosBasketItem item, params Expression<Func<PosBasketItem, object>>[] updateProperties)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(List<PosBasketItem> items, params Expression<Func<PosBasketItem, object>>[] updateProperties)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(PosBasketItem item)
        {
            throw new NotImplementedException();
        }

        public async Task<PosBasketItem> Get(Expression<Func<PosBasketItem, bool>> expression)
        {
            return await db.PosBasketItems.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public IQueryable<PosBasketItem> Where(Expression<Func<PosBasketItem, bool>> expression)
        {
            return db.PosBasketItems.Where(expression);
        }

        public async Task<List<PosBasketItem>> ToListAsync(Expression<Func<PosBasketItem, bool>> expression = null)
        {
            if (expression is null)
                return await db.PosBasketItems.AsNoTracking().ToListAsync();

            return await db.PosBasketItems.AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
