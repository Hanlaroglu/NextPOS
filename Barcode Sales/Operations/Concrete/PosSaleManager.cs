using Barcode_Sales.DTOs;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Services.CacheServices;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<List<DashboardSalePayTypeDto>> CurrentPaymentTypeDataAsync()
        {
            DateTime currentDate = DatetimeService.CurrentDateTime.Date;

            var list = new List<DashboardSalePayTypeDto>();

            using (KhanposDbEntities db = new KhanposDbEntities())
            {
                var result = await db.PosSales
                    .Where(s => s.SaleDate == currentDate)
                    .GroupBy(s => 1)
                    .Select(g => new
                    {
                        Cash = g.Sum(s => s.Cash),
                        Card = g.Sum(s => s.Card),
                        Total = g.Sum(s => s.Total)
                    })
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    list.Add(new DashboardSalePayTypeDto { PaymentName = "Nağd", Amount = result.Cash });
                    list.Add(new DashboardSalePayTypeDto { PaymentName = "Kart", Amount = result.Card });
                }

                return list;
            }
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

        public Task<TopSellingProductDto> TopSellingProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<List<PosSaleSummaryDto>> PosSaleSummaryAsync(string filter)
        {
            string query = $@"
SELECT 
	ps.Id,
	ps.SaleDateTime,
	u.NameSurname AS Cashier,
	c.NameSurname AS CustomerName,
    c.Id AS CustomerId,
	ps.Total,
	MAX(ps.Cash) AS Cash,
	MAX(ps.Card) AS Card,
	MAX(CASE 
        WHEN ps.Cash = 0 AND ps.Card > 0 THEN N'KART'
        WHEN ps.Cash > 0 AND ps.Card = 0 THEN N'NAĞD'
        WHEN ps.Cash > 0 AND ps.Card > 0 THEN N'NAĞD-KART'
        ELSE NULL
    END) AS PaymentType,
    ps.ReceiptNo,
    ps.ShortFiscalId,
    ps.LongFiscalId,
    ps.BankRrn,
    ps.BankTransactionID,
    COUNT(*) AS RemainingItemCount
FROM 
    PosSales ps
INNER JOIN 
    PosSaleItems psi ON psi.PosSaleId = ps.Id
LEFT JOIN 
    PosRefunds pr ON pr.PosSaleId = ps.Id
INNER JOIN
	Users u ON u.Id = ps.UserId
LEFT JOIN
	Customers c ON c.Id = ps.CustomerId
LEFT JOIN 
    PosRefundItems pri ON pri.PosRefundId = pr.Id AND pri.ProductId = psi.ProductId
WHERE 
    pri.ProductId IS NULL
    AND EXISTS (
        SELECT 1
        FROM PosSaleItems psi2
        LEFT JOIN PosRefunds pr2 ON pr2.PosSaleId = psi2.PosSaleId
        LEFT JOIN PosRefundItems pri2 ON pri2.PosRefundId = pr2.Id AND pri2.ProductId = psi2.ProductId
        WHERE psi2.PosSaleId = ps.Id
        AND pri2.ProductId IS NULL
    )
   {filter}
GROUP BY 
	ps.Id,
    ps.ReceiptNo,
	ps.SaleDateTime,
	u.NameSurname,
    c.Id,
	c.NameSurname,
	ps.Total,
    ps.BankRrn,
	ps.BankTransactionID,
    ps.ShortFiscalId,
    ps.LongFiscalId
HAVING 
    COUNT(*) > 0";

            return await db.Database.SqlQuery<PosSaleSummaryDto>(query).ToListAsync();
        }
    }
}
