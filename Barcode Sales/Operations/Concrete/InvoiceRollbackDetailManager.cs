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
    public class InvoiceRollbackDetailManager: IInvoiceRollbackDetailOperation
    {
        private NextposDBEntities db = new NextposDBEntities();
        public bool Add(InvoiceRollbackDetail item)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(InvoiceRollbackDetail item)
        {
            throw new NotImplementedException();
        }

        public void Update(InvoiceRollbackDetail item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(InvoiceRollbackDetail item)
        {
            throw new NotImplementedException();
        }

        public void Remove(InvoiceRollbackDetail item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(InvoiceRollbackDetail item)
        {
            throw new NotImplementedException();
        }

        public InvoiceRollbackDetail GetById(int id)
        {
            return db.InvoiceRollbackDetails.FirstOrDefault(x => x.Id == id);
        }

        public async Task<InvoiceRollbackDetail> GetByIdAsync(int id)
        {
            return await db.InvoiceRollbackDetails.FirstOrDefaultAsync(x => x.Id == id);

        }

        public IQueryable<InvoiceRollbackDetail> Where(Expression<Func<InvoiceRollbackDetail, bool>> expression)
        {
            return db.InvoiceRollbackDetails.Where(expression);
        }

        public async Task<List<InvoiceRollbackDetail>> WhereAsync(Expression<Func<InvoiceRollbackDetail, bool>> expression = null)
        {
            return await db.InvoiceRollbackDetails.AsNoTracking().Where(expression).ToListAsync();
        }

        public void AddRange(List<InvoiceRollbackDetail> items)
        {
            db.InvoiceRollbackDetails.AddRange(items);
            db.SaveChanges();
        }
    }
}
