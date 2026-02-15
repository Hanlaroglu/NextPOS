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
    internal class CloseShiftManager : ICloseShiftOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(CloseShiftReport item)
        {
            try
            {
                db.Set<CloseShiftReport>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<CloseShiftReport> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<CloseShiftReport>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(CloseShiftReport item, params Expression<Func<CloseShiftReport, object>>[] updateProperties)
        {
            try
            {
                db.Set<CloseShiftReport>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<CloseShiftReport> items, params Expression<Func<CloseShiftReport, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<CloseShiftReport>().Attach(entity);

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

        public async Task<bool> Remove(CloseShiftReport item)
        {
            try
            {
                db.Set<CloseShiftReport>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<CloseShiftReport> Get(Expression<Func<CloseShiftReport, bool>> expression)
        {
            return await db.CloseShiftReports.FirstOrDefaultAsync(expression);
        }

        public IQueryable<CloseShiftReport> Where(Expression<Func<CloseShiftReport, bool>> expression)
        {
            return db.CloseShiftReports.Where(expression);
        }

        public async Task<List<CloseShiftReport>> ToListAsync(Expression<Func<CloseShiftReport, bool>> expression = null)
        {
            if (expression is null)
                return await db.CloseShiftReports.AsNoTracking().ToListAsync();
            else
                return await db.CloseShiftReports.AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
