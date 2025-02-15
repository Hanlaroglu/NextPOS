using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Barcode_Sales.Helpers.Messages;

namespace Barcode_Sales.Operations.Concrete
{
    public class CompanyManager : ICompanyOperation
    {
        NextposDBEntities db = new NextposDBEntities();

        public bool Add(Company item)
        {
            try
            {
                db.Company.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task AddAsync(Company item)
        {
            db.Company.Add(item);
            await db.SaveChangesAsync();
        }

        public Company GetById(int id)
        {
            return db.Company.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await db.Company.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Company item)
        {
            //Remove kodunu yaz
            if (CommonMessageBox.QuestionDialogResult($"{item.CompanyName} şirkətini silmək istədiyinizə əminsiniz ?"))
            {
                var data = db.Company.Find(item.Id);
                //data.IsDeleted = data.Id;
                db.SaveChanges();
            }
        }

        public async Task RemoveAsync(Company item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.CompanyName} şirkətini silmək istədiyinizə əminsiniz ?"))
            {
                var data = db.Company.FindAsync(item.Id);
                //data.IsDeleted = data.Id;
                await db.SaveChangesAsync();
            }
        }

        public void Update(Company item)
        {
            var existingItem = db.Company.Find(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                db.SaveChanges();
            }
        }

        public async Task UpdateAsync(Company item)
        {
            var existingItem = await db.Company.FindAsync(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                await db.SaveChangesAsync();
            }
        }

        public IQueryable<Company> Where(Expression<Func<Company, bool>> expression)
        {
            return db.Company.Where(expression);
        }

        public async Task<List<Company>> WhereAsync(Expression<Func<Company, bool>> expression)
        {
            return await db.Company.Where(expression).ToListAsync();
        }
    }
}
