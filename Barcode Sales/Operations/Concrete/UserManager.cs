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
        NextposDBEntities db = new NextposDBEntities();

        public bool Add(Users item)
        {
            try
            {
                db.Users.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task AddAsync(Users item)
        {
            db.Users.Add(item);
            await db.SaveChangesAsync();
        }

        public Users GetById(int id)
        {
            return db.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            return await db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Users item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.Username} istifadəçisini silmək istədiyinizə əminsiniz ?"))
            {
                var data = db.Users.Find(item.Id);
                data.IsDeleted = data.Id;
                db.SaveChanges();
            }
        }

        public async Task RemoveAsync(Users item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.Username} istifadəçisini silmək istədiyinizə əminsiniz ?"))
            {
                var data = await db.Users.FindAsync(item.Id);
                data.IsDeleted = data.Id;
                await db.SaveChangesAsync();
            }
        }

        public void Update(Users item)
        {
            var existingItem = db.Users.Find(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                db.SaveChanges();
            }
        }

        public async Task UpdateAsync(Users item)
        {
            var existingItem = await db.Users.FindAsync(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
               await db.SaveChangesAsync();
            }
        }

        public IQueryable<Users> Where(Expression<Func<Users, bool>> expression)
        {
           return db.Users.Where(expression);
        }

        public async Task<List<Users>> WhereAsync(Expression<Func<Users, bool>> expression)
        {
            return await db.Users.Where(x=> x.IsDeleted == 0).Where(expression).ToListAsync();
        }
    }
}
