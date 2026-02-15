using Barcode_Sales.Forms;
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
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(Customer item)
        {
            try
            {
                item.Phone = item.Phone == "(___)___-__-__" ? null : item.Phone;
                item.Debt = 0;
                item.Balance = 0;
                item.Status = true;
                item.IsDeleted = 0;
                item.CreateDate = DateTime.Now;
                db.Set<Customer>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch (Exception ex)
            {
                fAddCustomer form = Application.OpenForms.OfType<fAddCustomer>().FirstOrDefault();
                NotificationHelpers.Messages.ErrorMessage(form, $"{ex.Message}");
                return 0;
            }
        }

        public async Task<bool> Add(List<Customer> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<Customer>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Customer item, params Expression<Func<Customer, object>>[] updateProperties)
        {
            try
            {
                item.Phone = item.Phone is "(___)___-__-__" ? null : item.Phone;
                db.Set<Customer>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<Customer> items, params Expression<Func<Customer, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<Customer>().Attach(entity);

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

        public async Task<bool> Remove(Customer item)
        {
            try
            {
                item.IsDeleted = item.Id;
                db.Customers.Attach(item);
                db.Entry(item).Property(x => x.IsDeleted).IsModified = true;
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Customer> Get(Expression<Func<Customer, bool>> expression)
        {
            return await db.Customers.FirstOrDefaultAsync(expression);
        }

        public IQueryable<Customer> Where(Expression<Func<Customer, bool>> expression)
        {
            return db.Customers.Where(expression);
        }

        public async Task<List<Customer>> ToListAsync(Expression<Func<Customer, bool>> expression = null)
        {
            if (expression is null)
                return await db.Customers.AsNoTracking().ToListAsync();
            else
                return await db.Customers.AsNoTracking().Where(expression).ToListAsync();
        }

        //public async Task RemoveAsync(Customer item)
        //{
        //    if (CommonMessageBox.QuestionDialogResult($"{item.NameSurname} müştərisini silmək istədiyinizə əminsiniz ?"))
        //    {
        //        var data = await db.Customers.FindAsync(item.Id);
        //        data.IsDeleted = data.Id;
        //        await db.SaveChangesAsync();
        //    }
        //}
    }
}