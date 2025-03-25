using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class IncomeAndExpenseManager : ITerminalIncomeAndExpenseOperation
    {
        NextposDBEntities db = new NextposDBEntities();
        public bool Add(TerminalIncomesAndExpens item)
        {
            try
            {
                db.TerminalIncomesAndExpenses.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task AddAsync(TerminalIncomesAndExpens item)
        {
            throw new NotImplementedException();
        }

        public TerminalIncomesAndExpens GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TerminalIncomesAndExpens> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TerminalIncomesAndExpens item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(TerminalIncomesAndExpens item)
        {
            throw new NotImplementedException();
        }

        public void Update(TerminalIncomesAndExpens item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TerminalIncomesAndExpens item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TerminalIncomesAndExpens> Where(Expression<Func<TerminalIncomesAndExpens, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<TerminalIncomesAndExpens>> WhereAsync(Expression<Func<TerminalIncomesAndExpens, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
    }
}
