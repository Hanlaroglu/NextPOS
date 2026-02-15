using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class CategoryManager : ICategoryOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();
        private IProductOperation productOperation { get; set; }

        public async Task<int> Add(Category item)
        {
            try
            {
                db.Set<Categories>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<Category> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<Categories>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Category> Get(Expression<Func<Category, bool>> expression)
        {
            return await db.Categories.FirstOrDefaultAsync(expression);
        }

        public async Task<bool> Update(Category item, params Expression<Func<Category, object>>[] updateProperties)
        {
            try
            {
                db.Set<Categories>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<Category> items, params Expression<Func<Category, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<Categories>().Attach(entity);

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

        public async Task<bool> Remove(Category item)
        {
            try
            {
                db.Set<Categories>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Category> Where(Expression<Func<Category, bool>> expression)
        {
            return db.Categories.AsNoTracking().Where(expression);
        }

        public async Task<List<Category>> ToListAsync(Expression<Func<Category, bool>> expression = null)
        {
            if (expression is null)
                return await db.Categories.AsNoTracking().ToListAsync();
            else
                return await db.Categories.AsNoTracking().Where(expression).OrderBy(x => x.Id).ToListAsync();
        }
    }
}