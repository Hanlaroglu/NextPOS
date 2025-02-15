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
    public class AqtaProductsManager : IAqtaProductsOperation
    {
        NextposDBEntities db = new NextposDBEntities();

        public bool Add(AqtaProducts item)
        {
            try
            {
                db.AqtaProducts.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

            
        }

        public async Task AddAsync(AqtaProducts item)
        {
            db.AqtaProducts.Add(item);
            await db.SaveChangesAsync();
        }

        public AqtaProducts GetById(int id)
        {
            return db.AqtaProducts.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<AqtaProducts> GetByIdAsync(int id)
        {
            return await db.AqtaProducts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(AqtaProducts item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.ProductName} məhsulunu silmək istədiyinizə əminsiniz ?"))
            {
                var data = db.AqtaProducts.Find(item.Id);
                data.IsDeleted = data.Id;
                db.SaveChanges();
            }
        }

        public async Task RemoveAsync(AqtaProducts item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.ProductName} məhsulunu silmək istədiyinizə əminsiniz ?"))
            {
                var data = await db.AqtaProducts.FindAsync(item.Id);
                data.IsDeleted = data.Id;
                await db.SaveChangesAsync();
            }
        }

        public void Update(AqtaProducts item)
        {
            var existingItem = db.AqtaProducts.Find(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                db.SaveChanges();
            }
        }

        public async Task UpdateAsync(AqtaProducts item)
        {
            var existingItem = await db.AqtaProducts.FindAsync(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                await db.SaveChangesAsync();
            }
        }

        public IQueryable<AqtaProducts> Where(Expression<Func<AqtaProducts, bool>> expression)
        {
            return db.AqtaProducts.Where(expression);
        }

        public async Task<List<AqtaProducts>> WhereAsync(Expression<Func<AqtaProducts, bool>> expression)
        {
            return await db.AqtaProducts.Where(expression).ToListAsync();
        }
    }
}