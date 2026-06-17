using Barcode_Sales.DTOs;
using Barcode_Sales.Operations.Abstract;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class PosSaleItemManager : IPosSaleItemOperation
    {
        private KhanposDbEntities db = new KhanposDbEntities();
        public async Task<int> Add(PosSaleItem item)
        {
            try
            {
                db.Set<PosSaleItem>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<PosSaleItem> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<PosSaleItem>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<PosSaleItem> Get(Expression<Func<PosSaleItem, bool>> expression)
        {
            return await db.PosSaleItems.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public Task<bool> Remove(PosSaleItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(PosSaleItem item, params Expression<Func<PosSaleItem, object>>[] updateProperties)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(List<PosSaleItem> items, params Expression<Func<PosSaleItem, object>>[] updateProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PosSaleItem> Where(Expression<Func<PosSaleItem, bool>> expression)
        {
            return db.PosSaleItems.Where(expression);
        }

        public async Task<List<PosSaleItem>> ToListAsync(Expression<Func<PosSaleItem, bool>> expression = null)
        {
            if (expression is null)
                return await db.PosSaleItems.AsNoTracking().ToListAsync();

            return await db.PosSaleItems.AsNoTracking().Where(expression).ToListAsync();
        }

        public List<PosSaleItemDto> GetRemainingSaleData(int posSaleId)
        {

            /*
            var query = @"SELECT 
	ps.Id as PosSaleId,
    psi.Id as PosSaleItemId,
	p.Barcode,
	p.ProductName,
	ut.[Name] AS UnitName,
    psi.[SalePrice],
    psi.[Discount],
    psi.[Quantity] - ISNULL((
        SELECT SUM(pri.[Quantity])
        FROM [dbo].[PosRefundItems] pri
        WHERE pri.[PosSaleItemId] = psi.[Id]
    ), 0) AS [RemainingQuantity]
FROM [dbo].[PosSales] ps
INNER JOIN [dbo].[PosSaleItems] psi ON psi.[PosSaleId] = ps.[Id]
INNER JOIN Users u ON u.Id = ps.UserId
LEFT JOIN Customers c ON c.Id = ps.CustomerId
INNER JOIN Products p ON p.Id = psi.ProductId
INNER JOIN UnitTypes ut ON ut.Id = p.UnitId
WHERE (
    psi.[Quantity] - ISNULL((
        SELECT SUM(pri.[Quantity])
        FROM [dbo].[PosRefundItems] pri
        WHERE pri.[PosSaleItemId] = psi.[Id]
    ), 0)
) > 0 AND ps.Id = @posSaleId
ORDER BY ps.[SaleDate] DESC, ps.[Id] DESC";
            */


            var query = @"SELECT 
	ps.Id as PosSaleId,
    psi.Id as PosSaleItemId,
	p.Id as ProductId,
	p.Barcode,
	p.ProductName,
	p.UnitId,
	p.TaxId,
	p.PurchasePrice,
    psi.[SalePrice],
    psi.[Discount],
    psi.[Quantity] - ISNULL((
        SELECT SUM(pri.[Quantity])
        FROM [dbo].[PosRefundItems] pri
        WHERE pri.[PosSaleItemId] = psi.[Id]
    ), 0) AS [RemainingQuantity]
FROM [dbo].[PosSales] ps
INNER JOIN [dbo].[PosSaleItems] psi ON psi.[PosSaleId] = ps.[Id]
INNER JOIN Users u ON u.Id = ps.UserId
LEFT JOIN Customers c ON c.Id = ps.CustomerId
INNER JOIN Products p ON p.Id = psi.ProductId
WHERE (
    psi.[Quantity] - ISNULL((
        SELECT SUM(pri.[Quantity])
        FROM [dbo].[PosRefundItems] pri
        WHERE pri.[PosSaleItemId] = psi.[Id]
    ), 0)
) > 0 AND ps.Id = @posSaleId
ORDER BY ps.[SaleDate] DESC, ps.[Id] DESC";

            var param = new SqlParameter("@posSaleId", posSaleId);


            return db.Database.SqlQuery<PosSaleItemDto>(query,param).ToList();
        }
    }
}
