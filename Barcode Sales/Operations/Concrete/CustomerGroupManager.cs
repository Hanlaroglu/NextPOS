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
    public class CustomerGroupManager : ICustomerGroupOperation
    {
        private NextposDBEntities db = new NextposDBEntities();
        public bool Add(CustomerGroup item)
        {
            try
            {
               db.CustomerGroups.Add(item);
               db.SaveChanges();
               return true;
            }
            catch (Exception e)
            { 
                return false;
            }
        }

        public Task AddAsync(CustomerGroup item)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerGroup item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CustomerGroup item)
        {
            throw new NotImplementedException();
        }

        public void Remove(CustomerGroup item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(CustomerGroup item)
        {
            throw new NotImplementedException();
        }

        public CustomerGroup GetById(int id)
        {
            return db.CustomerGroups.FirstOrDefault(x => x.Id == id);
        }

        public async Task<CustomerGroup> GetByIdAsync(int id)
        {
            return await db.CustomerGroups.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<CustomerGroup> Where(Expression<Func<CustomerGroup, bool>> expression)
        {
            return db.CustomerGroups.Where(expression);
        }

        public async Task<List<CustomerGroup>> WhereAsync(Expression<Func<CustomerGroup, bool>> expression = null)
        {
            return await db.CustomerGroups.AsNoTracking()
                .Where(expression)
                .ToListAsync();
        }
    }
}
