using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Barcode_Sales.Helpers.Messages;

namespace Barcode_Sales.Operations.Concrete
{
    public class CompanyManager : ICompanyOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(Company item)
        {
            try
            {
                db.Set<Company>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<Company> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<Company>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Company> Get(Expression<Func<Company, bool>> expression)
        {
            return await db.Company.FirstOrDefaultAsync(expression);
        }

        public async Task<bool> Remove(Company item)
        {
            try
            {
                db.Set<Company>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Company item, params Expression<Func<Company, object>>[] updateProperties)
        {
            try
            {
                db.Set<Invoice>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<Company> items, params Expression<Func<Company, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<Invoice>().Attach(entity);

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

        public IQueryable<Company> Where(Expression<Func<Company, bool>> expression)
        {
            return db.Company.Where(expression);
        }

        public async Task<List<Company>> ToListAsync(Expression<Func<Company, bool>> expression = null)
        {
            if (expression is null)
                return await db.Company.AsNoTracking().ToListAsync();
            else
                return await db.Company.AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
