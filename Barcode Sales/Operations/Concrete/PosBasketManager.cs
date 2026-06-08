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
    public class PosBasketManager : IPosBasketOperation
    {
        private KhanposDbEntities db = new KhanposDbEntities();
        public async Task<int> Add(PosBasket item)
        {
            try
            {
                db.Set<PosBasket>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> Add(List<PosBasket> items)
        {
            if (items == null || items.Count == 0)
                return false;

            try
            {
                db.Set<PosBasket>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Task<bool> Update(PosBasket item, params Expression<Func<PosBasket, object>>[] updateProperties)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(List<PosBasket> items, params Expression<Func<PosBasket, object>>[] updateProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(PosBasket item)
        {
            try
            {
                var entity = await db.Set<PosBasket>().FirstOrDefaultAsync(x => x.Id == item.Id);

                if (entity == null)
                    return false;

                db.Set<PosBasket>().Remove(entity);
                return await db.SaveChangesAsync() > 0;
            }
            catch 
            {
                throw ;
            }
        }

        public async Task<PosBasket> Get(Expression<Func<PosBasket, bool>> expression)
        {
            return await db.PosBaskets.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public IQueryable<PosBasket> Where(Expression<Func<PosBasket, bool>> expression)
        {
            return db.PosBaskets.Where(expression);
        }

        public async Task<List<PosBasket>> ToListAsync(Expression<Func<PosBasket, bool>> expression = null)
        {
            if (expression is null)
                return await db.PosBaskets.AsNoTracking().ToListAsync();

            return await db.PosBaskets.AsNoTracking().Where(expression).ToListAsync();
        }

        public string LastBasketNumber()
        {
            var maxNumber = db.PosBaskets.AsNoTracking()
                .Select(x => x.BasketName)
                .AsEnumerable()
                .Select(x =>
                {
                    var cleaned = x.Replace("Səbət-", "").TrimStart('0');
                    return int.TryParse(string.IsNullOrWhiteSpace(cleaned) ? "0" : cleaned, out int number)
                        ? number
                        : 0;
                })
                .DefaultIfEmpty(0)
                .Max();

            return $"Səbət-{maxNumber + 1}";
        }

        public async Task<List<PosBasketDto>> GetBaskets()
        {
            var query = @"SELECT 
p.Id,
p.BasketName,
p.CustomerId,
c.NameSurname as CustomerName,
SUM(TotalAmount) AS TotalAmount,
p.CreatedDatetime
FROM PosBaskets p
INNER JOIN PosBasketItems pb ON pb.PosBasketId = p.Id
LEFT JOIN Customers c ON c.Id = p.CustomerId
GROUP BY
p.Id,
p.BasketName,
p.CustomerId,
c.NameSurname,
p.CreatedDatetime
ORDER BY p.Id asc";

            return await db.Database.SqlQuery<PosBasketDto>(query).ToListAsync();
        }
    }
}
