using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Barcode_Sales.Operations.Abstract;

namespace Barcode_Sales.Operations.Concrete
{
    public class InvoiceDetailManager:IInvoiceDetailOperation
    {
        private NextposDBEntities db = new NextposDBEntities();
        public bool Add(InvoiceDetail item)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(InvoiceDetail item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(List<InvoiceDetail> items)
        {
            db.InvoiceDetails.AddRange(items);
            db.SaveChanges();
        }

        public void Update(InvoiceDetail item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(InvoiceDetail item)
        {
            throw new NotImplementedException();
        }

        public void Remove(InvoiceDetail item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(InvoiceDetail item)
        {
            throw new NotImplementedException();
        }

        public InvoiceDetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDetail> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<InvoiceDetail> Where(Expression<Func<InvoiceDetail, bool>> expression)
        {
            return db.InvoiceDetails.AsNoTracking().Where(expression);
        }

        public Task<List<InvoiceDetail>> WhereAsync(Expression<Func<InvoiceDetail, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
    }
}
