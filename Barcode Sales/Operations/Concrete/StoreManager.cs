using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class StoreManager : IStoreOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(Store item)
        {
            try
            {
                db.Set<Store>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<Store> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<Store>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Store item, params Expression<Func<Store, object>>[] updateProperties)
        {
            try
            {
                db.Set<Store>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<Store> items, params Expression<Func<Store, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<Store>().Attach(entity);

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

        public async Task<bool> Remove(Store item)
        {
            try
            {
                db.Set<Store>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Store> Get(Expression<Func<Store, bool>> expression)
        {
            return await db.Stores.FirstOrDefaultAsync(expression);
        }

        public IQueryable<Store> Where(Expression<Func<Store, bool>> expression)
        {
            return db.Stores.Where(expression);
        }

        public async Task<List<Store>> ToListAsync(Expression<Func<Store, bool>> expression = null)
        {
            if (expression is null)
                return await db.Stores.AsNoTracking().ToListAsync();
            else
                return await db.Stores.AsNoTracking().Where(expression).ToListAsync();
        }

        //public void Remove(Store item)
        //{
        //    if (CommonMessageBox.QuestionDialogResult($"{item.Name} mağazasını silmək istədiyinizə əminsiniz ?"))
        //    {
        //        var data = GetById(item.Id);
        //        data.IsDeleted = true;
        //        db.SaveChanges();
        //    }
        //}
    }
}
