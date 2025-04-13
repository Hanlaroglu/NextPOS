using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class ReturnPosManager : IReturnPosOperation
    {
        NextposDBEntities db = new NextposDBEntities();
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
            throw new NotImplementedException();
        }

        public Task<List<ReturnPos>> WhereAsync(Expression<Func<ReturnPos, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
    }
}
