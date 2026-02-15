using Barcode_Sales.Barcode.Sales.Admin;
using Barcode_Sales.Operations.Abstract;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales.Operations.Concrete
{
    public class CustomerDebtManager : ICustomerDebtOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(CustomersDebt item)
        {
            try
            {
                db.Set<CustomersDebt>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch (Exception ex)
            {
                fDashboard form = Application.OpenForms.OfType<fDashboard>().FirstOrDefault();
                NotificationHelpers.Messages.ErrorMessage(form, $"{ex.Message}");
                return 0;
            }
        }

        public async Task<bool> Add(List<CustomersDebt> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<CustomersDebt>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(CustomersDebt item, params Expression<Func<CustomersDebt, object>>[] updateProperties)
        {
            try
            {
                db.Set<CustomersDebt>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<CustomersDebt> items, params Expression<Func<CustomersDebt, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<CustomersDebt>().Attach(entity);

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

        public async Task<bool> Remove(CustomersDebt item)
        {
            try
            {
                db.Set<CustomersDebt>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<CustomersDebt> Get(Expression<Func<CustomersDebt, bool>> expression)
        {
            return await db.CustomersDebts.FirstOrDefaultAsync(expression);
        }

        public IQueryable<CustomersDebt> Where(Expression<Func<CustomersDebt, bool>> expression)
        {
            return db.CustomersDebts.Where(expression);
        }

        public async Task<List<CustomersDebt>> ToListAsync(Expression<Func<CustomersDebt, bool>> expression = null)
        {
            if (expression is null)
                return await db.CustomersDebts.AsNoTracking().Where(x=> x.IsDeleted == 0).ToListAsync();
            else
                return await db.CustomersDebts.AsNoTracking().Where(expression).OrderBy(x => x.DebtDate).ToListAsync();
        }

        public double CustomersTotalDebt(int customerId)
        {
            var debtTotal = db.CustomersDebts
                              .Where(x => x.CustomerId == customerId && x.IsDeleted == 0)
                              .Sum(x => (x.Debt ?? 0));

            return debtTotal;
        }
    }
}
