using Barcode_Sales.Forms;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales.Operations.Concrete
{
    public class CustomerManager : ICustomerOperation
    {
        NextposDBEntities db = new NextposDBEntities();

        public bool Add(Customers item)
        {
            try
            {
                db.Customers.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                fAddCustomer form = Application.OpenForms.OfType<fAddCustomer>().FirstOrDefault();
                NoticationHelpers.Messages.ErrorMessage(form, $"{ex.Message}");
                return false;
            }

        }

        public async Task AddAsync(Customers item)
        {
            db.Customers.Add(item);
            await db.SaveChangesAsync();
        }

        public Customers GetById(int id)
        {
            return db.Customers.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Customers> GetByIdAsync(int id)
        {
            return await db.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Customers item)
        {
            //Delete kodunu yaz
            if (CommonMessageBox.QuestionDialogResult($"{item.NameSurname} müştərisini silmək istədiyinizə əminsiniz ?"))
            {
                var data = db.Customers.FindAsync(item.Id);
                //data.IsDeleted = data.Id;
                db.SaveChanges();
            }
        }

        public async Task RemoveAsync(Customers item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.NameSurname} müştərisini silmək istədiyinizə əminsiniz ?"))
            {
                var data = await db.Customers.FindAsync(item.Id);
                data.IsDeleted = data.Id;
                await db.SaveChangesAsync();
            }
        }

        public void Update(Customers item)
        {
            var existingItem = db.Customers.Find(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                db.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Customers item)
        {
            var existingItem = db.Customers.FindAsync(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                await db.SaveChangesAsync();
            }
        }

        public IQueryable<Customers> Where(Expression<Func<Customers, bool>> expression)
        {
            return db.Customers.Where(expression);
        }

        public async Task<List<Customers>> WhereAsync(Expression<Func<Customers, bool>> expression)
        {
            return await db.Customers.Where(expression).ToListAsync();
        }

        public string Active(Customers item)
        {
            if (item is null) return null;

            item.Status = true;
            db.SaveChanges();

            return $"{item.NameSurname} müştərisi aktiv edildi";
        }

        public async Task ActiveAsync(List<Customers> items)
        {
            foreach (var item in items)
            {
                //var data = await GetByIdAsync(item.Id);
                if (item is null || item.Status is true) continue;

                item.Status = true;
            }
            await db.SaveChangesAsync();
        }

        public string Blocked(Customers item)
        {
            if (item is null) return null;

            item.Status = false;
            db.SaveChanges();

            return $"{item.NameSurname} müştərisi deaktiv edildi";
        }

        public async Task BlockedAsync(List<Customers> items)
        {
            foreach (var item in items)
            {
                if (item is null || item.Status is false) continue;

                item.Status = false;
            }
            await db.SaveChangesAsync();
        }
    }
}