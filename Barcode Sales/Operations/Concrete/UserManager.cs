using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class UserManager : IUserOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(User item)
        {
            try
            {
                db.Set<User>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<User> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<User>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(User item, params Expression<Func<User, object>>[] updateProperties)
        {
            try
            {
                db.Set<User>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<User> items, params Expression<Func<User, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<User>().Attach(entity);

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

        public async Task<bool> Remove(User item)
        {
            try
            {
                db.Set<User>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> Get(Expression<Func<User, bool>> expression)
        {
            return await db.Users.FirstOrDefaultAsync(expression);
        }

        public IQueryable<User> Where(Expression<Func<User, bool>> expression)
        {
            return db.Users.Where(expression);
        }

        public async Task<List<User>> ToListAsync(Expression<Func<User, bool>> expression = null)
        {
            if (expression is null)
                return await db.Users.AsNoTracking().ToListAsync();
            else
                return await db.Users.AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
