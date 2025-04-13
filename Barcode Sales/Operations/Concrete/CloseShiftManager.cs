using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    internal class CloseShiftManager : ICloseShiftOperation
    {
        NextposDBEntities db = new NextposDBEntities();

        public bool Add(CloseShiftReport item)
        {
            try
            {
                db.CloseShiftReports.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task AddAsync(CloseShiftReport item)
        {
            throw new NotImplementedException();
        }

        public CloseShiftReport GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CloseShiftReport> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(CloseShiftReport item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(CloseShiftReport item)
        {
            throw new NotImplementedException();
        }

        public void Update(CloseShiftReport item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CloseShiftReport item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CloseShiftReport> Where(Expression<Func<CloseShiftReport, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<CloseShiftReport>> WhereAsync(Expression<Func<CloseShiftReport, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
    }
}
