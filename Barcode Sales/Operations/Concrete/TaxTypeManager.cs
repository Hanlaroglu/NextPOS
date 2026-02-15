using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class TaxTypeManager : ITaxTypeOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(TaxType item)
        {
            try
            {
                db.Set<TaxType>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<TaxType> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<TaxType>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(TaxType item, params Expression<Func<TaxType, object>>[] updateProperties)
        {
            try
            {
                db.Set<TaxType>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<TaxType> items, params Expression<Func<TaxType, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<TaxType>().Attach(entity);

                        foreach (var property in updateProperties)
                            db.Entry(entity).Property(property).IsModified = true;
                    }

                    await db.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<bool> Remove(TaxType item)
        {
            try
            {
                db.Set<TaxType>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<TaxType> Get(Expression<Func<TaxType, bool>> expression)
        {
            return await db.TaxTypes.FirstOrDefaultAsync(expression);
        }

        public IQueryable<TaxType> Where(Expression<Func<TaxType, bool>> expression)
        {
            return db.TaxTypes.Where(expression);
        }

        public async Task<List<TaxType>> ToListAsync(Expression<Func<TaxType, bool>> expression = null)
        {
            if (expression != null)
                return await db.TaxTypes.AsNoTracking().Where(expression).ToListAsync();
            else
                return await db.TaxTypes.AsNoTracking().ToListAsync();
        }

        public Dictionary<int, string> Initialize()
        {
            return db.TaxTypes.ToDictionary(x => x.Id, x => x.Name);
        }
    }
}
