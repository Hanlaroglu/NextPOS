using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Barcode_Sales.Helpers.Messages;

namespace Barcode_Sales.Operations.Concrete
{
    public class StoreManager : IStoreOperation
    {
        NextposDBEntities db = new NextposDBEntities();

        public bool Add(Store item)
        {
            try
            {
                db.Stores.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task AddAsync(Store item)
        {
            db.Stores.Add(item);
            await db.SaveChangesAsync();
        }

        public Store GetById(int id)
        {
            return db.Stores.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Store> GetByIdAsync(int id)
        {
            return await db.Stores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Store item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.Name} mağazasını silmək istədiyinizə əminsiniz ?"))
            {
                var data = GetById(item.Id);
                data.IsDeleted = true;
                db.SaveChanges();
            }
        }

        public async Task RemoveAsync(Store item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.Name} mağazasını silmək istədiyinizə əminsiniz ?"))
            {
                var data = await db.Stores.FindAsync(item.Id);
                data.IsDeleted = true;
                await db.SaveChangesAsync();
            }
        }

        public void Update(Store item)
        {
            var existingItem = db.Stores.Find(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                db.SaveChanges();
            }
        }

        public async Task UpdateAsync(Store item)
        {
            var existingItem = await db.Stores.FindAsync(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
              await  db.SaveChangesAsync();
            }
        }

        public IQueryable<Store> Where(Expression<Func<Store, bool>> expression)
        {
            return db.Stores.Where(expression);
        }

        public async Task<List<Store>> WhereAsync(Expression<Func<Store, bool>> expression)
        {
            return await db.Stores.Where(expression).ToListAsync();
        }
    }
}
