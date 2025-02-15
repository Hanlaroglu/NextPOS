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

        public bool Add(Stores item)
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

        public async Task AddAsync(Stores item)
        {
            db.Stores.Add(item);
            await db.SaveChangesAsync();
        }

        public Stores GetById(int id)
        {
            return db.Stores.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<Stores> GetByIdAsync(int id)
        {
            return await db.Stores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Stores item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.StoreName} mağazasını silmək istədiyinizə əminsiniz ?"))
            {
                var data = db.Stores.Find(item.Id);
                data.IsDeleted = data.Id;
                db.SaveChanges();
            }
        }

        public async Task RemoveAsync(Stores item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.StoreName} mağazasını silmək istədiyinizə əminsiniz ?"))
            {
                var data = await db.Stores.FindAsync(item.Id);
                data.IsDeleted = data.Id;
                await db.SaveChangesAsync();
            }
        }

        public void Update(Stores item)
        {
            var existingItem = db.Stores.Find(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                db.SaveChanges();
            }
        }

        public async Task UpdateAsync(Stores item)
        {
            var existingItem = await db.Stores.FindAsync(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
              await  db.SaveChangesAsync();
            }
        }

        public IQueryable<Stores> Where(Expression<Func<Stores, bool>> expression)
        {
            return db.Stores.Where(expression);
        }

        public async Task<List<Stores>> WhereAsync(Expression<Func<Stores, bool>> expression)
        {
            return await db.Stores.Where(expression).ToListAsync();
        }
    }
}
