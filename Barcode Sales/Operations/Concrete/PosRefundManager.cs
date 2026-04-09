using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class PosRefundManager : IPosRefundOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();
        public async Task<int> Add(PosRefund item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(List<PosRefund> items)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(PosRefund item, params Expression<Func<PosRefund, object>>[] updateProperties)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(List<PosRefund> items, params Expression<Func<PosRefund, object>>[] updateProperties)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(PosRefund item)
        {
            throw new NotImplementedException();
        }

        public Task<PosRefund> Get(Expression<Func<PosRefund, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PosRefund> Where(Expression<Func<PosRefund, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<PosRefund>> ToListAsync(Expression<Func<PosRefund, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
    }
}
