using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class ReturnPosDetailManager : IReturnPosDetailOperation
    {
        NextposDBEntities db = new NextposDBEntities();
        public bool Add(ReturnPosDetail item)
        {
            try
            {
                db.ReturnPosDetails.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public Task AddAsync(ReturnPosDetail item)
        {
            throw new NotImplementedException();
        }

        public ReturnPosDetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnPosDetail> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ReturnPosDetail item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(ReturnPosDetail item)
        {
            throw new NotImplementedException();
        }

        public void Update(ReturnPosDetail item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ReturnPosDetail item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ReturnPosDetail> Where(Expression<Func<ReturnPosDetail, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReturnPosDetail>> WhereAsync(Expression<Func<ReturnPosDetail, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
    }
}
