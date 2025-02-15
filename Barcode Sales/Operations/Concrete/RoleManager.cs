using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class RoleManager : IRoleOperation
    {
        NextposDBEntities db = new NextposDBEntities();

        public bool Add(Roles item)
        {
            try
            {
                db.Roles.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task AddAsync(Roles item)
        {
            db.Roles.Add(item);
            await db.SaveChangesAsync();
        }

        public Roles GetById(int id)
        {
            return db.Roles.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<Roles> GetByIdAsync(int id)
        {
            return await db.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Roles item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.RoleName} rolunu silmək istədiyinizə əminsiniz ?"))
            {
                var data = db.Roles.FindAsync(item.Id);
                //data.IsDeleted = data.Id;
                db.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(Roles item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.RoleName} rolunu silmək istədiyinizə əminsiniz ?"))
            {
                var data = await db.Roles.FindAsync(item.Id);
                data.IsDeleted = data.Id;
                await db.SaveChangesAsync();
            }
        }

        public void Update(Roles item)
        {
            var existingItem = db.Roles.Find(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                db.SaveChanges();
            }
        }

        public async Task UpdateAsync(Roles item)
        {
            var existingItem = await db.Roles.FindAsync(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
               await db.SaveChangesAsync();
            }
        }

        public IQueryable<Roles> Where(Expression<Func<Roles, bool>> expression)
        {
            return db.Roles.Where(expression);
        }

        public async Task<List<Roles>> WhereAsync(Expression<Func<Roles, bool>> expression)
        {
            return await db.Roles.Where(expression).ToListAsync();
        }
    }
}
