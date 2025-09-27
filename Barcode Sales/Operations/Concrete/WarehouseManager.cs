using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
            return await db.Warehouses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Warehouses item)
        {
            Warehouses entity = new Warehouses
            {
                Id = item.Id,
                IsDeleted = item.Id,
            };
            db.Warehouses.Attach(entity);
            db.Entry(entity).Property(x => x.IsDeleted).IsModified = true;
            db.SaveChanges();
        }

        public async Task RemoveAsync(Warehouses item)
        {
            db.Warehouses.Attach(item);
            db.Entry(item).Property(x => x.IsDeleted).IsModified = true;
            item.IsDeleted = item.Id;
            await db.SaveChangesAsync();
        }

        public void Update(Warehouses item)
        {
            Warehouses entity = new Warehouses
            {
                Id = item.Id,
                Name = item.Name,
                Status = item.Status,
            };
            db.Warehouses.Attach(entity);
            db.Entry(entity).Property(x => x.Name).IsModified = true;
            db.Entry(entity).Property(x => x.Status).IsModified = true;
            db.SaveChanges();
        }

        public async Task UpdateAsync(Warehouses item)
        {
            db.Warehouses.Attach(item);
            db.Entry(item).Property(x => x.Name).IsModified = true;
            db.Entry(item).Property(x => x.Status).IsModified = true;
            await db.SaveChangesAsync();
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
