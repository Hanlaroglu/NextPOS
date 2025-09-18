using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    public class UnitTypeManager:IUnitTypeOperation
    {
        private NextposDBEntities db = new NextposDBEntities();
        public bool Add(UnitType item)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(UnitType item)
        {
            throw new NotImplementedException();
        }

        public void Update(UnitType item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UnitType item)
        {
            throw new NotImplementedException();
        }

        public void Remove(UnitType item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(UnitType item)
        {
            throw new NotImplementedException();
        }

        public UnitType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UnitType> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UnitType> Where(Expression<Func<UnitType, bool>> expression)
        {
            return db.UnitTypes.AsNoTracking().Where(expression);
        }

        public async Task<List<UnitType>> WhereAsync(Expression<Func<UnitType, bool>> expression = null)
        {
            if (expression is null)
                return await db.UnitTypes.ToListAsync();
            else
                return await db.UnitTypes.AsNoTracking().Where(expression).ToListAsync();
        }

        public Dictionary<int, string> Initialize()
        {
            return db.UnitTypes.ToDictionary(x => x.Id, x => x.Name);
        }
    }
}
