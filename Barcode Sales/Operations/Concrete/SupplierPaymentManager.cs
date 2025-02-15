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
    public class SupplierPaymentManager : ISupplierPaymentOperation
    {
        NextposDBEntities db = new NextposDBEntities();

        public bool Add(SupplierPayment item)
        {
            try
            {
                db.SupplierPayments.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        public async Task AddAsync(SupplierPayment item)
        {
            db.SupplierPayments.Add(item);
            await db.SaveChangesAsync();
        }

        public SupplierPayment GetById(int id)
        {
            return db.SupplierPayments.FirstOrDefault(x => x.Id == id);
        }

        public async Task<SupplierPayment> GetByIdAsync(int id)
        {
            return await db.SupplierPayments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(SupplierPayment item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(SupplierPayment item)
        {
            throw new NotImplementedException();
        }

        public void Update(SupplierPayment item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SupplierPayment item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SupplierPayment> Where(Expression<Func<SupplierPayment, bool>> expression)
        {
            return db.SupplierPayments.AsNoTracking().Where(expression);
        }

        public async Task<List<SupplierPayment>> WhereAsync(Expression<Func<SupplierPayment, bool>> expression = null)
        {
            return await db.SupplierPayments.Where(expression).ToListAsync();
        }
    }
}
