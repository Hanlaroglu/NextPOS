using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class SalesDataDetailManager : ISalesDataDetailOperation
    {
        NextposDBEntities db = new NextposDBEntities();
        public bool Add(SalesDataDetail item)
        {
            db.SalesDataDetails.Add(item);
            db.SaveChanges();
            return true;
        }

        public Task AddAsync(SalesDataDetail item)
        {
            throw new NotImplementedException();
        }

        public void InsertRangeSalesDataDetail(List<SalesDataDetail> items)
        {
            db.SalesDataDetails.AddRange(items);
            db.SaveChanges();
        }

        public SalesDataDetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SalesDataDetail> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(SalesDataDetail item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(SalesDataDetail item)
        {
            throw new NotImplementedException();
        }

        public void Update(SalesDataDetail item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SalesDataDetail item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SalesDataDetail> Where(Expression<Func<SalesDataDetail, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesDataDetail>> WhereAsync(Expression<Func<SalesDataDetail, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
    }
}
