using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class InvoiceManager : IInvoiceOperation
    {
        private KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(Invoice item)
        {
            try
            {
                db.Set<Invoice>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch 
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<Invoice> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<Invoice>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Invoice>> InvoiceReport(DateTime start, DateTime end)
        {
            return await db.Invoices.AsNoTracking()
                .Where(x => x.IsDeleted == 0 && x.InvoiceDate >= start.Date && x.InvoiceDate <= end.Date)
                .OrderBy(x=> x.InvoiceDate)
                .ToListAsync();
        }

        public async Task<bool> Update(Invoice item, params Expression<Func<Invoice, object>>[] updateProperties)
        {
            try
            {
                db.Set<Invoice>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<Invoice> items, params Expression<Func<Invoice, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<Invoice>().Attach(entity);

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

        public async Task<bool> Remove(Invoice item)
        {
            try
            {
                db.Set<Invoice>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Invoice> Get(Expression<Func<Invoice, bool>> expression)
        {
            return await db.Invoices.FirstOrDefaultAsync(expression);
        }

        public IQueryable<Invoice> Where(Expression<Func<Invoice, bool>> expression)
        {
            return db.Invoices.Where(expression);
        }

        public async Task<List<Invoice>> ToListAsync(Expression<Func<Invoice, bool>> expression = null)
        {
            if (expression is null)
                return await db.Invoices.AsNoTracking().ToListAsync();
            else
                return await db.Invoices.AsNoTracking().Where(expression).OrderBy(x=> x.InvoiceDate).ToListAsync();
        }
    }
}