using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class InvoiceDetailManager : IInvoiceDetailOperation
    {
        private KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(InvoiceDetail item)
        {
            try
            {
                db.Set<InvoiceDetail>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<InvoiceDetail> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<InvoiceDetail>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(InvoiceDetail item, params Expression<Func<InvoiceDetail, object>>[] updateProperties)
        {
            try
            {
                db.Set<InvoiceDetail>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<InvoiceDetail> items, params Expression<Func<InvoiceDetail, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<InvoiceDetail>().Attach(entity);

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

        public async Task<bool> Remove(InvoiceDetail item)
        {
            try
            {
                db.Set<InvoiceDetail>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<InvoiceDetail> Get(Expression<Func<InvoiceDetail, bool>> expression)
        {
            return await db.InvoiceDetails.FirstOrDefaultAsync(expression);
        }

        public IQueryable<InvoiceDetail> Where(Expression<Func<InvoiceDetail, bool>> expression)
        {
            return db.InvoiceDetails.Where(expression);
        }

        public async Task<List<InvoiceDetail>> ToListAsync(Expression<Func<InvoiceDetail, bool>> expression = null)
        {
            if (expression is null)
                return await db.InvoiceDetails.AsNoTracking().ToListAsync();
            else
                return await db.InvoiceDetails.AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
