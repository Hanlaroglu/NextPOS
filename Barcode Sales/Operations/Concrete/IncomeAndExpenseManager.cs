using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class IncomeAndExpenseManager : ITerminalIncomeAndExpenseOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(TerminalIncomesAndExpens item)
        {
            try
            {
                db.Set<TerminalIncomesAndExpens>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<TerminalIncomesAndExpens> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<TerminalIncomesAndExpens>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(TerminalIncomesAndExpens item, params Expression<Func<TerminalIncomesAndExpens, object>>[] updateProperties)
        {
            try
            {
                db.Set<TerminalIncomesAndExpens>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<TerminalIncomesAndExpens> items, params Expression<Func<TerminalIncomesAndExpens, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<TerminalIncomesAndExpens>().Attach(entity);

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

        public async Task<bool> Remove(TerminalIncomesAndExpens item)
        {
            try
            {
                db.Set<TerminalIncomesAndExpens>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<TerminalIncomesAndExpens> Get(Expression<Func<TerminalIncomesAndExpens, bool>> expression)
        {
            return await db.TerminalIncomesAndExpenses.FirstOrDefaultAsync(expression);
        }

        public IQueryable<TerminalIncomesAndExpens> Where(Expression<Func<TerminalIncomesAndExpens, bool>> expression)
        {
            return db.TerminalIncomesAndExpenses.Where(expression);
        }

        public async Task<List<TerminalIncomesAndExpens>> ToListAsync(Expression<Func<TerminalIncomesAndExpens, bool>> expression = null)
        {
            if (expression is null)
                return await db.TerminalIncomesAndExpenses.AsNoTracking().ToListAsync();
            else
                return await db.TerminalIncomesAndExpenses.AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
