using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Security;

namespace Barcode_Sales.Operations.Concrete
{
    public class RoleManager : IRoleOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(Role item)
        {
            try
            {
                db.Set<Role>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<Role> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<Role>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Role> Get(Expression<Func<Role, bool>> expression)
        {
            return await db.Roles.FirstOrDefaultAsync(expression);
        }

        public async Task<bool> Remove(Role item)
        {
            try
            {
                db.Set<Role>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        //public void Remove(Role item)
        //{
        //    if (CommonMessageBox.QuestionDialogResult($"{item.RoleName} rolunu silmək istədiyinizə əminsiniz ?"))
        //    {
        //        var data = db.Roles.FindAsync(item.Id);
        //        //data.IsDeleted = data.Id;
        //        db.SaveChangesAsync();
        //    }
        //}

        //public async Task RemoveAsync(Role item)
        //{
        //    if (CommonMessageBox.QuestionDialogResult($"{item.RoleName} rolunu silmək istədiyinizə əminsiniz ?"))
        //    {
        //        var data = await db.Roles.FindAsync(item.Id);
        //        data.IsDeleted = data.Id;
        //        await db.SaveChangesAsync();
        //    }
        //}

        public async Task<bool> Update(Role item, params Expression<Func<Role, object>>[] updateProperties)
        {
            try
            {
                db.Set<Role>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<Role> items, params Expression<Func<Role, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<Role>().Attach(entity);

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

        public IQueryable<Role> Where(Expression<Func<Role, bool>> expression)
        {
            return db.Roles.Where(expression);
        }

        public async Task<List<Role>> ToListAsync(Expression<Func<Role, bool>> expression = null)
        {
            if (expression is null)
                return await db.Roles.AsNoTracking().ToListAsync();
            else
                return await db.Roles.AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
