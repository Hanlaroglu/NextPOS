using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class InvoiceRollbackManager : IInvoiceRollbackOperation
    {
        private KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(InvoiceRollback item)
        {
            try
            {
                db.Set<InvoiceRollback>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<InvoiceRollback> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<InvoiceRollback>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(InvoiceRollback item, params Expression<Func<InvoiceRollback, object>>[] updateProperties)
        {
            try
            {
                db.Set<InvoiceRollback>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<InvoiceRollback> items, params Expression<Func<InvoiceRollback, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<InvoiceRollback>().Attach(entity);

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

        public async Task<bool> Remove(InvoiceRollback item)
        {
            try
            {
                db.Set<InvoiceRollback>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<InvoiceRollback> Get(Expression<Func<InvoiceRollback, bool>> expression)
        {
            return await db.InvoiceRollbacks.FirstOrDefaultAsync(expression);
        }

        public IQueryable<InvoiceRollback> Where(Expression<Func<InvoiceRollback, bool>> expression)
        {
            return db.InvoiceRollbacks.Where(expression);
        }

        public async Task<List<InvoiceRollback>> ToListAsync(Expression<Func<InvoiceRollback, bool>> expression = null)
        {
            if (expression is null)
                return await db.InvoiceRollbacks.AsNoTracking().ToListAsync();
            else
                return await db.InvoiceRollbacks.AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<List<InvoiceRollback>> Report(DateTime start, DateTime end)
        {
            return await db.InvoiceRollbacks.AsNoTracking()
                .Where(x =>
                    x.IsDeleted == false &&
                    x.RollbackDate >= start.Date &&
                    x.RollbackDate <= end.Date)
                .OrderBy(x => x.RollbackDate)
                .ToListAsync();
        }
    }
}
