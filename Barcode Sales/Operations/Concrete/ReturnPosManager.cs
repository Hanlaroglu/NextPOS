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
    public class ReturnPosManager : IReturnPosOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();
        public bool Add(ReturnPos item)
        {
            try
            {
                db.ReturnPos.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task AddAsync(ReturnPos item)
        {
            throw new NotImplementedException();
        }

        public int InsertReturnData(ReturnPos item)
        {
            try
            {
                db.ReturnPos.Add(item);
                db.SaveChanges();
                return item.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public ReturnPos GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnPos> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ReturnPos item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(ReturnPos item)
        {
            throw new NotImplementedException();
        }

        public void Update(ReturnPos item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ReturnPos item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ReturnPos> Where(Expression<Func<ReturnPos, bool>> expression)
        {
           return db.ReturnPos.Where(expression);
        }

        public async Task<List<ReturnPos>> WhereAsync(Expression<Func<ReturnPos, bool>> expression = null)
        {
            return await db.ReturnPos.AsNoTracking().Where(expression).ToListAsync();
        }

        public int CurrentCountTotal()
        {
            var start = DateTime.Now.Date;
            var end = start.AddDays(1);
            return Where(rp => rp.ReturnDate >= start && rp.ReturnDate < end).Count();
        }

        public double CurrentAmountTotal()
        {
            var start = DateTime.Now.Date;
            var end = start.AddDays(1);
            return Where(rp => rp.ReturnDate >= start && rp.ReturnDate < end)
                    .Sum(rp => rp.Total) ??0;
        }
    }
}
