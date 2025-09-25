using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class InvoiceRollbackManager:IInvoiceRollbackOperation
    {
        private NextposDBEntities db = new NextposDBEntities();
        public bool Add(InvoiceRollback item)
        {
            throw new NotImplementedException();
        }

        public int AddRollback(InvoiceRollback item)
        {
            db.InvoiceRollbacks.Add(item);
            db.SaveChanges();
            return item.Id;
        }

        public Task AddAsync(InvoiceRollback item)
        {
            throw new NotImplementedException();
        }

        public void Update(InvoiceRollback item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(InvoiceRollback item)
        {
            throw new NotImplementedException();
        }

        public void Remove(InvoiceRollback item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(InvoiceRollback item)
        {
            throw new NotImplementedException();
        }

        public InvoiceRollback GetById(int id)
        {
            return db.InvoiceRollbacks.FirstOrDefault(x => x.Id == id);
        }

        public Task<InvoiceRollback> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<InvoiceRollback> Where(Expression<Func<InvoiceRollback, bool>> expression)
        {
            return db.InvoiceRollbacks.AsNoTracking().Where(expression);
        }

        public async Task<List<InvoiceRollback>> WhereAsync(Expression<Func<InvoiceRollback, bool>> expression = null)
        {
            return await db.InvoiceRollbacks.AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<List<InvoiceRollback>> Report(DateTime start, DateTime end)
        {
            return await db.InvoiceRollbacks.AsNoTracking()
                .Where(x => 
                    x.IsDeleted == false && 
                    x.RollbackDate >= start.Date && 
                    x.RollbackDate <= end.Date)
                .OrderBy(x => x.RollbackDate)
                .ToListAsync();
        }
    }
}
