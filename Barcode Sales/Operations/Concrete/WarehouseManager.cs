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
    public class WarehouseManager : IWarehouseOperation
    {
        NextposDBEntities db = new NextposDBEntities();
        public bool Add(Warehouses item)
        {
            try
            {
                db.Warehouses.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public Task AddAsync(Warehouses item)
        {
            throw new NotImplementedException();
        }

        public Warehouses GetById(int id)
        {
           return db.Warehouses.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Warehouses> GetByIdAsync(int id)
        {
            return await db.Warehouses.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);
        }

        public void Remove(Warehouses item)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Warehouses item)
        {
            throw new NotImplementedException();
        }

        public void Update(Warehouses item)
        {
            var existingItem = db.Warehouses.Find(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                db.SaveChanges();
            }
        }

        public Task UpdateAsync(Warehouses item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Warehouses> Where(Expression<Func<Warehouses, bool>> expression)
        {
            return db.Warehouses.AsNoTracking().Where(expression);
            
        }

        public async Task<List<Warehouses>> WhereAsync(Expression<Func<Warehouses, bool>> expression = null)
        {
            if (expression is null)
            {
                return await db.Warehouses.AsNoTracking()
                                         .Where(x => x.IsDeleted == 0)
                                         .ToListAsync();
            }
            else
            {
                return await db.Warehouses.AsNoTracking()
                                        .Where(x => x.IsDeleted == 0)
                                        .Where(expression).ToListAsync();
            }
            
        }
    }
}
