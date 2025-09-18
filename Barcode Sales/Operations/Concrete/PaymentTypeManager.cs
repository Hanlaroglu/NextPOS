using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Barcode_Sales.Operations.Abstract;

namespace Barcode_Sales.Operations.Concrete
{
    public class PaymentTypeManager : IPaymentTypeOperation
    {
        private NextposDBEntities db = new NextposDBEntities();
        public bool Add(PaymentType item)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(PaymentType item)
        {
            throw new NotImplementedException();
        }

        public void Update(PaymentType item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PaymentType item)
        {
            throw new NotImplementedException();
        }

        public void Remove(PaymentType item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(PaymentType item)
        {
            throw new NotImplementedException();
        }

        public PaymentType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentType> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PaymentType> Where(Expression<Func<PaymentType, bool>> expression)
        {
            return db.PaymentTypes.AsNoTracking().Where(expression);
        }

        public async Task<List<PaymentType>> WhereAsync(Expression<Func<PaymentType, bool>> expression = null)
        {
            if (expression is null)
                return await db.PaymentTypes.AsNoTracking().ToListAsync();
            else
                return await db.PaymentTypes.AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
