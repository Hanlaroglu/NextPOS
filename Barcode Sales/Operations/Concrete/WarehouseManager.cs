using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class WarehouseManager : IWarehouseOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(Warehouse item)
        {
            try
            {
                db.Set<Warehouse>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<Warehouse> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<Warehouse>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Warehouse item, params Expression<Func<Warehouse, object>>[] updateProperties)
        {
            try
            {
                db.Set<Warehouse>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<Warehouse> items, params Expression<Func<Warehouse, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<Warehouse>().Attach(entity);

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

        public async Task<bool> Remove(Warehouse item)
        {
            try
            {
                db.Set<Warehouse>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Warehouse> Get(Expression<Func<Warehouse, bool>> expression)
        {
            return await db.Warehouses.FirstOrDefaultAsync(expression);
        }

        public IQueryable<Warehouse> Where(Expression<Func<Warehouse, bool>> expression)
        {
            return db.Warehouses.Where(expression);
        }

        public async Task<List<Warehouse>> ToListAsync(Expression<Func<Warehouse, bool>> expression = null)
        {
            if (expression is null)
                return await db.Warehouses.AsNoTracking()
                    .Where(x => x.IsDeleted == 0)
                    .ToListAsync();
            else
                return await db.Warehouses.AsNoTracking()
                    .Where(x => x.IsDeleted == 0)
                    .Where(expression)
                    .ToListAsync();
        }

        //public void Update(Warehouses item)
        //{
        //    Warehouses entity = new Warehouses
        //    {
        //        Id = item.Id,
        //        Name = item.Name,
        //        Status = item.Status,
        //    };
        //    db.Warehouses.Attach(entity);
        //    db.Entry(entity).Property(x => x.Name).IsModified = true;
        //    db.Entry(entity).Property(x => x.Status).IsModified = true;
        //    db.SaveChanges();
        //}
    }
}
