using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Barcode_Sales.Barcode.Sales.Admin;

namespace Barcode_Sales.Operations.Concrete
{
    public class SupplierManager : ISupplierOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(Supplier item)
        {
            try
            {
                db.Set<Supplier>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<Supplier> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<Supplier>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Supplier> Get(Expression<Func<Supplier, bool>> expression)
        {
            return await db.Suppliers.FirstOrDefaultAsync(expression);
        }

        public async Task<bool> Remove(Supplier item)
        {
            try
            {
                db.Set<Supplier>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Supplier item, params Expression<Func<Supplier, object>>[] updateProperties)
        {
            try
            {
                db.Set<Supplier>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<Supplier> items, params Expression<Func<Supplier, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<Supplier>().Attach(entity);

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

        public IQueryable<Supplier> Where(Expression<Func<Supplier, bool>> expression)
        {
            return db.Suppliers.AsNoTracking().Where(expression);
        }

        public async Task<List<Supplier>> ToListAsync(Expression<Func<Supplier, bool>> expression = null)
        {
            if (expression is null)
                return await db.Suppliers.AsNoTracking().ToListAsync();
            else
                return await db.Suppliers.AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
