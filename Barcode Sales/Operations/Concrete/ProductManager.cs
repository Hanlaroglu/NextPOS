using Barcode_Sales.DTOs;
using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Barcode_Sales.Operations.Concrete
{
    public class ProductManager : IProductOperation
    {
        KhanposDbEntities db;

        public ProductManager(KhanposDbEntities _db = null)
        {
            db = _db ?? new KhanposDbEntities();
        }

        public async Task<int> Add(Product item)
        {
            try
            {
                db.Set<Product>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch (Exception ex)
            {
                throw ex;
                return 0;
            }
        }

        public async Task<bool> Add(List<Product> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<Product>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Product item, params Expression<Func<Product, object>>[] updateProperties)
        {
            try
            {
                var entry = db.Entry(item);
                if (entry.State == EntityState.Detached)
                    db.Set<Product>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw e;
                return false;
            }
        }

        public async Task<bool> Update(List<Product> items, params Expression<Func<Product, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            try
            {
                foreach (var entity in items)
                {
                    var entry = db.Entry(entity);
                    if (entry.State == EntityState.Detached)
                        db.Set<Product>().Attach(entity);

                    foreach (var property in updateProperties)
                        db.Entry(entity).Property(property).IsModified = true;
                }

                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public async Task<bool> Remove(Product item)
        //{
        //    try
        //    {
        //        db.Set<Product>().Remove(item);
        //        return await db.SaveChangesAsync() > 0;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public async Task<Product> Get(Expression<Func<Product, bool>> expression)
        {
            return await db.Products.FirstOrDefaultAsync(expression);
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return db.Products.Where(expression);
        }

        public async Task<bool> Remove(Product item)
        {
            var product = await db.Products.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (product == null) return false;

            product.IsDeleted = true;
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<List<Product>> ToListAsync(Expression<Func<Product, bool>> expression = null)
        {
            if (expression is null)
                return await db.Products.AsNoTracking().ToListAsync();

            return await db.Products.AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<List<StockReportDto>> StockReport()
        {
            string query = @"SELECT
    c.CategoryName        AS CategoryName,
    p.ProductCode         AS ProductCode,
    p.ProductName         AS ProductName,
    p.Barcode             AS Barcode,
    u.Name                AS UnitName,
    t.Name                AS TaxName,
    p.PurchasePrice       AS PurchasePrice,
    p.SalePrice           AS SalePrice,
    p.Quantity            AS Quantity
FROM Products p
INNER JOIN Categories c ON c.Id = p.CategoryId
INNER JOIN UnitTypes  u ON u.Id = p.UnitId
LEFT  JOIN TaxTypes   t ON t.Id = p.TaxId
WHERE
	p.IsDeleted = 0;
";

            var result = await db.Database.SqlQuery<StockReportDto>(query).ToListAsync();

            return result;
        }

        public async Task<List<HotSaleProductDto>> HotSaleProducts()
        {
            string query = @"SELECT
    p.ProductName         AS ProductName,
    p.SalePrice           AS SalePrice
FROM Products p
WHERE p.CanHotSaleProduct = 1
AND p.IsDeleted = 0 
AND p.IsActive = 1;";

            var result = await db.Database.SqlQuery<HotSaleProductDto>(query).ToListAsync();

            return result;
        }
    }
}