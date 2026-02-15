using Barcode_Sales.DTOs;
using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class PosSaleManager : IPosSaleOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(PosSale item)
        {
            try
            {
                db.Set<PosSale>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<PosSale> items)
        {
            if (items == null || items.Count == 0)
                return false;

            try
            {
                db.Set<PosSale>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public Task<DashboardUIDto.PaymentTypeTotal> CurrentPaymentTypeDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> CurrentSalesCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> CurrentSalesDataAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PosSale> Get(Expression<Func<PosSale, bool>> expression)
        {
            return await db.PosSales.FirstOrDefaultAsync(expression);
        }

        public async Task<bool> Remove(PosSale item)
        {
            try
            {
                db.Set<PosSale>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<int> CurrentSaleCount()
        {
            var result = await db.Database
                 .SqlQuery<int>(@"SELECT COUNT(*) AS [count] FROM PosSales 
WHERE SaleDate BETWEEN CAST(GETDATE() AS DATE) 
AND DATEADD(DAY,1,CAST(GETDATE() AS DATE))")
                 .SingleAsync();

            return result;
        }

        public async Task<List<PosSale>> ToListAsync(Expression<Func<PosSale, bool>> expression = null)
        {
            if (expression is null)
                return await db.PosSales.AsNoTracking().ToListAsync();
            else
                return await db.PosSales.AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<bool> Update(PosSale item, params Expression<Func<PosSale, object>>[] updateProperties)
        {
            try
            {
                db.Set<PosSale>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<PosSale> items, params Expression<Func<PosSale, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<PosSale>().Attach(entity);

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

        public IQueryable<PosSale> Where(Expression<Func<PosSale, bool>> expression)
        {
            return db.PosSales.Where(expression);
        }
    }
}
