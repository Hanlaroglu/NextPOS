using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Barcode_Sales.DTOs;

namespace Barcode_Sales.Operations.Concrete
{
    public class InvoiceRollbackDetailManager : IInvoiceRollbackDetailOperation
    {
        private KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(InvoiceRollbackDetail item)
        {
            try
            {
                db.Set<InvoiceRollbackDetail>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<InvoiceRollbackDetail> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<InvoiceRollbackDetail>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(InvoiceRollbackDetail item, params Expression<Func<InvoiceRollbackDetail, object>>[] updateProperties)
        {
            try
            {
                db.Set<InvoiceRollbackDetail>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<InvoiceRollbackDetail> items, params Expression<Func<InvoiceRollbackDetail, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<InvoiceRollbackDetail>().Attach(entity);

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

        public async Task<bool> Remove(InvoiceRollbackDetail item)
        {
            try
            {
                db.Set<InvoiceRollbackDetail>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<InvoiceRollbackDetail> Get(Expression<Func<InvoiceRollbackDetail, bool>> expression)
        {
            return await db.InvoiceRollbackDetails.FirstOrDefaultAsync(expression);
        }

        public IQueryable<InvoiceRollbackDetail> Where(Expression<Func<InvoiceRollbackDetail, bool>> expression)
        {
            return db.InvoiceRollbackDetails.Where(expression);
        }

        public async Task<List<InvoiceRollbackDetail>> ToListAsync(Expression<Func<InvoiceRollbackDetail, bool>> expression = null)
        {
            if (expression is null)
                return await db.InvoiceRollbackDetails.AsNoTracking().ToListAsync();

            return await db.InvoiceRollbackDetails.AsNoTracking().Where(expression).ToListAsync();
        }

        public List<InvoiceRollbackDetailDto> InvoiceRollbackDetailReport(int rollbackId)
        {
            string query = @"SELECT p.ProductName,
       p.Barcode,
       p.ProductCode,
       id.TotalPurchasePrice,
       ut.Name as UnitName,
       ird.Quantity
FROM   invoicerollbackdetails ird
       INNER JOIN invoicerollbacks ir ON ir.id = @rollbackId
       INNER JOIN invoices i ON i.id = ir.invoiceid
       INNER JOIN invoicedetails id ON id.invoiceid = i.id
       INNER JOIN products p ON p.id = id.productid
       INNER JOIN unittypes ut ON ut.id = p.unitid ";

            var parameters = new[]
            {
                new SqlParameter("@rollbackId", rollbackId)
            };

            var result =  db.Database.SqlQuery<InvoiceRollbackDetailDto>(query, parameters).ToList();

            return result;
        }
    }
}
