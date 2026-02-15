using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class CustomerGroupManager : ICustomerGroupOperation
    {
        private KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(CustomerGroup item)
        {
            try
            {
                db.Set<CustomerGroup>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<CustomerGroup> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<CustomerGroup>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(CustomerGroup item, params Expression<Func<CustomerGroup, object>>[] updateProperties)
        {
            try
            {
                db.Set<CustomerGroup>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<CustomerGroup> items, params Expression<Func<CustomerGroup, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<CustomerGroup>().Attach(entity);

                        foreach (var property in updateProperties)
                            db.Entry(entity).Property(property).IsModified = true;
                    }

                    await db.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<bool> Remove(CustomerGroup item)
        {
            try
            {
                db.Set<CustomerGroup>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<CustomerGroup> Get(Expression<Func<CustomerGroup, bool>> expression)
        {
            return await db.CustomerGroups.FirstOrDefaultAsync(expression);
        }

        public IQueryable<CustomerGroup> Where(Expression<Func<CustomerGroup, bool>> expression)
        {
            return db.CustomerGroups.Where(expression);
        }

        public async Task<List<CustomerGroup>> ToListAsync(Expression<Func<CustomerGroup, bool>> expression = null)
        {
            if (expression is null)
                return await db.CustomerGroups.AsNoTracking().ToListAsync();
            else
                return await db.CustomerGroups.AsNoTracking().Where(expression).ToListAsync();
        }


        //public void Remove(CustomerGroup item)
        //{
        //    item.IsDeleted = true;
        //    string query = $@"UPDATE Customers SET CustomerGroupId = NULL WHERE CustomerGroupId = {item.Id}";
        //    db.CustomerGroups.Attach(item);
        //    db.Entry(item).Property(x => x.IsDeleted).IsModified = true;
        //    db.SaveChanges();
        //    db.Database.ExecuteSqlCommand(query);
        //}

        //public async Task RemoveAsync(CustomerGroup item)
        //{
        //    CustomerGroup entity = new CustomerGroup
        //    {
        //        Id = item.Id,
        //        IsDeleted = true,
        //    };
        //    db.CustomerGroups.Attach(entity);
        //    db.Entry(entity).Property(x => x.IsDeleted).IsModified = true;
        //    await db.SaveChangesAsync();
        //}
    }
}
