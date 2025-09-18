using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class InvoiceManager:IInvoiceOperation
    {
        private NextposDBEntities db = new NextposDBEntities();
        public bool Add(Invoice item)
        {
            throw new NotImplementedException();
        }

        public int AddInvoice(Invoice item)
        {
            db.Invoices.Add(item);
            db.SaveChanges();
            return item.Id;
        }

        public Task AddAsync(Invoice item)
        {
            throw new NotImplementedException();
        }

        public void Update(Invoice item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Invoice item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Invoice item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Invoice item)
        {
            throw new NotImplementedException();
        }

        public Invoice GetById(int id)
        {
            return db.Invoices.FirstOrDefault(x => x.Id == id);
        }

        public Task<Invoice> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Invoice> Where(Expression<Func<Invoice, bool>> expression)
        {
            return db.Invoices.AsNoTracking().Where(expression);
        }

        public Task<List<Invoice>> WhereAsync(Expression<Func<Invoice, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

      
    }
}
