using Barcode_Sales.Operations.Abstract;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            db.CustomerGroups.Attach(item);
            db.Entry(item).Property(x => x.Name).IsModified = true;
            db.Entry(item).Property(x => x.Discount).IsModified = true;
            db.SaveChanges();
        }

        public async Task UpdateAsync(CustomerGroup item)
        {
            db.CustomerGroups.Attach(item);
            db.Entry(item).Property(x => x.Name).IsModified = true;
            db.Entry(item).Property(x => x.Discount).IsModified = true;
            await db.SaveChangesAsync();
        }

        public void Remove(CustomerGroup item)
        {
            item.IsDeleted = true;
            string query = $@"UPDATE Customers SET CustomerGroupId = NULL WHERE CustomerGroupId = {item.Id}";
            db.CustomerGroups.Attach(item);
            db.Entry(item).Property(x => x.IsDeleted).IsModified = true;
            db.SaveChanges();
            db.Database.ExecuteSqlCommand(query);
        }

        public async Task RemoveAsync(CustomerGroup item)
        {
            CustomerGroup entity = new CustomerGroup
            {
                Id = item.Id,
                IsDeleted = true,
            };
            db.CustomerGroups.Attach(entity);
            db.Entry(entity).Property(x => x.IsDeleted).IsModified = true;
            await db.SaveChangesAsync();
        }

        public CustomerGroup GetById(int id)
        {
            return db.CustomerGroups.FirstOrDefault(x => x.Id == id);
        }

        public async Task<CustomerGroup> GetByIdAsync(int id)
        {
            return await db.CustomerGroups.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
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
