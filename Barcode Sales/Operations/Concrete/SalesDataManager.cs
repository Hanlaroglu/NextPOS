using Barcode_Sales.DTOs;
using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Barcode_Sales.DTOs.DashboardUIDto;

namespace Barcode_Sales.Operations.Concrete
{
    public class SalesDataManager : ISaleDataOperation
    {
        NextposDBEntities db = new NextposDBEntities();
        public bool Add(SalesData item)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(SalesData item)
        {
            throw new NotImplementedException();
        }

        public int InsertSaleData(SalesData item)
        {
            try
            {
                db.SalesDatas.Add(item);
                db.SaveChanges();
                return item.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<string> SalesCount()
        {
            var result = await db.Database
                .SqlQuery<int>(@"SELECT COUNT(*) 
                                 FROM SalesData
                                 WHERE SaleDate BETWEEN CAST(GETDATE() AS DATE)
                                 AND DATEADD(DAY,1,CAST(GETDATE() AS DATE))")
                .SingleAsync();


            return result.ToString();
        }

        public async Task<string> CurrentSalesDataAsync()
        {
            var data = await db.Database
                .SqlQuery<double?>(@"SELECT SUM(Total) 
FROM SalesData
WHERE SaleDate = CAST(GETDATE() AS date)")
                .SingleAsync();

            string result = (data ?? 0).ToString("C2");
            return result;
        }

        public async Task<DashboardUIDto.PaymentTypeTotal> CurrentPaymentTypeDataAsync()
        {
            var data = await db.Database
                .SqlQuery<PaymentTypeTotal>(@"
            SELECT 
                 ISNULL(SUM(Cash), 0) AS TotalCash,
                 ISNULL(SUM(Card), 0) AS TotalCard
            FROM SalesData
            WHERE SaleDate = CAST(GETDATE() AS date)")
                .SingleOrDefaultAsync();

            return new PaymentTypeTotal
            {
                TotalCash = data?.TotalCash ?? 0,
                TotalCard = data?.TotalCard ?? 0
            };
        }

        public SalesData GetById(int id)
        {
            return db.SalesDatas.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Task<SalesData> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(SalesData item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(SalesData item)
        {
            throw new NotImplementedException();
        }

        public void Update(SalesData item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SalesData item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SalesData> Where(Expression<Func<SalesData, bool>> expression)
        {
            return db.SalesDatas.Where(expression);
        }

        public async Task<List<SalesData>> WhereAsync(Expression<Func<SalesData, bool>> expression = null)
        {
            return await db.SalesDatas.AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
