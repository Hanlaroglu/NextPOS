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
    public class TaxTypeManager : ITaxTypeOperation
    {
        NextposDBEntities db = new NextposDBEntities();
        public bool Add(TaxType item)
        {
            try
            {
                db.TaxTypes.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task AddAsync(TaxType item)
        {
            db.TaxTypes.Add(item);
            await db.SaveChangesAsync();
        }

        public TaxType GetById(int id)
        {
            return db.TaxTypes.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<TaxType> GetByIdAsync(int id)
        {
            return await db.TaxTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(TaxType item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(TaxType item)
        {
            throw new NotImplementedException();
        }

        public void Update(TaxType item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TaxType item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TaxType> Where(Expression<Func<TaxType, bool>> expression)
        {
            return db.TaxTypes.Where(expression);
        }

        public async Task<List<TaxType>> WhereAsync(Expression<Func<TaxType, bool>> expression = null)
        {
            if (expression != null)
                return await db.TaxTypes.Where(expression).ToListAsync();
            else
                return await db.TaxTypes.ToListAsync();
        }

        public Dictionary<int, string> Initialize()
        {
            return db.TaxTypes.ToDictionary(x => x.Id, x => x.Name);
        }
    }
}
