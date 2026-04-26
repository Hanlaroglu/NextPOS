using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Barcode_Sales.Operations.Concrete
{
    public class ProductManager : IProductOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(Products item)
        {
            try
            {
                db.Set<Products>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch (Exception ex)
            {
                throw ex;
                return 0;
            }
        }

        public async Task<bool> Add(List<Products> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<Products>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Products item, params Expression<Func<Products, object>>[] updateProperties)
        {
            try
            {
                db.Set<Products>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw e;
                return false;
            }
        }

        public async Task<bool> Update(List<Products> items, params Expression<Func<Products, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<Products>().Attach(entity);

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

        //public async Task<bool> Remove(Product item)
        //{
        //    try
        //    {
        //        db.Set<Product>().Remove(item);
        //        return await db.SaveChangesAsync() > 0;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public async Task<Products> Get(Expression<Func<Products, bool>> expression)
        {
            return await db.Products.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public IQueryable<Products> Where(Expression<Func<Products, bool>> expression)
        {
            return db.Products.Where(expression);
        }

        public async Task<List<Products>> ToListAsync(Expression<Func<Products, bool>> expression = null)
        {
            if (expression is null)
                return await db.Products.AsNoTracking().ToListAsync();
            else
                return await db.Products.AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<bool> Remove(Products item)
        {
            item.IsDeleted = true;
            if (await db.SaveChangesAsync() > 0)
                return true;

            return false;
        }
    }
}