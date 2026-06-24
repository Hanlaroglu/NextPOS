using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Barcode_Sales.Operations.Abstract;

namespace Barcode_Sales.Operations.Concrete
{
    public class ScaleManager : IScaleOperation
    {
        private KhanposDbEntities db = new KhanposDbEntities();
        public async Task<int> Add(Scale item)
        {
            try
            {
                db.Set<Scale>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Add(List<Scale> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<Scale>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Scale item, params Expression<Func<Scale, object>>[] updateProperties)
        {
            try
            {
                db.Set<Scale>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<Scale> items, params Expression<Func<Scale, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<Scale>().Attach(entity);

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

        public async Task<bool> Remove(Scale item)
        {
            try
            {
                item.IsDeleted = true;
                var result = await Update(item, x => x.IsDeleted);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Scale> Get(Expression<Func<Scale, bool>> expression)
        {
            return await db.Scales.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public IQueryable<Scale> Where(Expression<Func<Scale, bool>> expression)
        {
            return db.Scales.Where(expression);
        }

        public async Task<List<Scale>> ToListAsync(Expression<Func<Scale, bool>> expression = null)
        {
            if (expression is null)
                return await db.Scales.AsNoTracking().Where(x => x.IsDeleted == false).ToListAsync();

            return await db.Scales.AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
