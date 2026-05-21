using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class PosSaleItemManager : IPosSaleItemOperation
    {
        private KhanposDbEntities db = new KhanposDbEntities();
        public async Task<int> Add(PosSaleItem item)
        {
            try
            {
                db.Set<PosSaleItem>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<PosSaleItem> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<PosSaleItem>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<PosSaleItem> Get(Expression<Func<PosSaleItem, bool>> expression)
        {
            return await db.PosSaleItems.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public Task<bool> Remove(PosSaleItem item)
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
            return db.PosSaleItems.Where(expression);
        }

        public async Task<List<PosSaleItem>> ToListAsync(Expression<Func<PosSaleItem, bool>> expression = null)
        {
            if (expression is null)
                return await db.PosSaleItems.AsNoTracking().ToListAsync();

            return await db.PosSaleItems.AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
