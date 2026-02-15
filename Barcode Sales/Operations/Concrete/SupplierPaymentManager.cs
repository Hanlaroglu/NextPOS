using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class SupplierPaymentManager : ISupplierPaymentOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(SupplierPayment item)
        {
            try
            {
                db.Set<SupplierPayment>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<SupplierPayment> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<SupplierPayment>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(SupplierPayment item, params Expression<Func<SupplierPayment, object>>[] updateProperties)
        {
            try
            {
                db.Set<SupplierPayment>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<SupplierPayment> items, params Expression<Func<SupplierPayment, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<SupplierPayment>().Attach(entity);

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

        public async Task<bool> Remove(SupplierPayment item)
        {
            try
            {
                db.Set<SupplierPayment>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<SupplierPayment> Get(Expression<Func<SupplierPayment, bool>> expression)
        {
            return await db.SupplierPayments.FirstOrDefaultAsync(expression);
        }

        public IQueryable<SupplierPayment> Where(Expression<Func<SupplierPayment, bool>> expression)
        {
            return db.SupplierPayments.Where(expression);
        }

        public async Task<List<SupplierPayment>> ToListAsync(Expression<Func<SupplierPayment, bool>> expression = null)
        {
            if (expression is null)
                return await db.SupplierPayments.AsNoTracking().ToListAsync();
            else
                return await db.SupplierPayments.AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
