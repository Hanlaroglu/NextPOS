using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class PaymentTypeManager : IPaymentTypeOperation
    {
        private KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(PaymentType item)
        {
            try
            {
                db.Set<PaymentType>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<PaymentType> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<PaymentType>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(PaymentType item, params Expression<Func<PaymentType, object>>[] updateProperties)
        {
            try
            {
                db.Set<PaymentType>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<PaymentType> items, params Expression<Func<PaymentType, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<PaymentType>().Attach(entity);

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

        public async Task<bool> Remove(PaymentType item)
        {
            try
            {
                db.Set<PaymentType>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<PaymentType> Get(Expression<Func<PaymentType, bool>> expression)
        {
            return await db.PaymentTypes.FirstOrDefaultAsync(expression);
        }

        public IQueryable<PaymentType> Where(Expression<Func<PaymentType, bool>> expression)
        {
            return db.PaymentTypes.AsNoTracking().Where(expression);
        }

        public async Task<List<PaymentType>> ToListAsync(Expression<Func<PaymentType, bool>> expression = null)
        {
            if (expression is null)
                return await db.PaymentTypes.AsNoTracking().ToListAsync();
            else
                return await db.PaymentTypes.AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
