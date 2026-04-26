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
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
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
                return await db.InvoiceRollbacks
                    .AsNoTracking()
                    .Where(expression)
                    .OrderBy(x => x.RollbackDate)
                    .ToListAsync();
        }

        public async Task<List<view_InvoiceRollbackList>> RollbackList(int supplierId, DateTime? start = null, DateTime? end = null)
        {
            var query = db.view_InvoiceRollbackList.AsNoTracking()
                .Where(x => x.SupplierId == supplierId)
                .AsQueryable();

            if (start.HasValue)
                query = query.Where(x => x.InvoiceDate >= start.Value);

            if (end.HasValue)
                query = query.Where(x => x.InvoiceDate <= end.Value);

            return await query.ToListAsync();
        }
    }
}
