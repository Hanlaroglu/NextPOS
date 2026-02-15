using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class UnitTypeManager:IUnitTypeOperation
    {
        private KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(UnitType item)
        {
            try
            {
                db.Set<UnitType>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<UnitType> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<UnitType>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(UnitType item, params Expression<Func<UnitType, object>>[] updateProperties)
        {
            try
            {
                db.Set<UnitType>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<UnitType> items, params Expression<Func<UnitType, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<UnitType>().Attach(entity);

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

        public async Task<bool> Remove(UnitType item)
        {
            try
            {
                db.Set<UnitType>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<UnitType> Get(Expression<Func<UnitType, bool>> expression)
        {
            return await db.UnitTypes.FirstOrDefaultAsync(expression);
        }

        public IQueryable<UnitType> Where(Expression<Func<UnitType, bool>> expression)
        {
            return db.UnitTypes.Where(expression);
        }

        public async Task<List<UnitType>> ToListAsync(Expression<Func<UnitType, bool>> expression = null)
        {
            if (expression is null)
                return await db.UnitTypes.ToListAsync();
            else
                return await db.UnitTypes.AsNoTracking().Where(expression).ToListAsync();
        }

        public Dictionary<int, string> Initialize()
        {
            return db.UnitTypes.ToDictionary(x => x.Id, x => x.Name);
        }
    }
}
