using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Barcode_Sales.Operations.Concrete
{
    public class ProductManager : IProductOperation
    {
        NextposDBEntities db = new NextposDBEntities();

        public bool Add(Products item)
        {
            try
            {
                db.Products.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
return false;
            }
        }

        public async Task AddAsync(Products item)
        {
            db.Products.Add(item);
            await db.SaveChangesAsync();
        }

        public Products GetById(int id)
        {
            return db.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<Products> GetByIdAsync(int id)
        {
            return await db.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Products item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.ProductName} məhsulunu silmək istədiyinizə əminsiniz ?"))
            {
                Products product = db.Products.FirstOrDefault(x => x.Id == item.Id);
                product.IsDeleted = product.Id;
                db.SaveChanges();
            }
        }

        public async Task RemoveAsync(Products item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.ProductName} məhsulunu silmək istədiyinizə əminsiniz ?"))
            {
                Products product = await db.Products.FirstOrDefaultAsync(x => x.Id == item.Id);
                product.IsDeleted = product.Id;
                await db.SaveChangesAsync();
            }
        }

        public void Update(Products item)
        {
            var existingItem = db.Products.Find(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                db.SaveChanges();
            }
        }

        public async Task UpdateAsync(Products item)
        {
            var existingItem = await db.Products.FindAsync(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
               await db.SaveChangesAsync();
            }
        }

        public IQueryable<Products> Where(Expression<Func<Products, bool>> expression)
        {
            return db.Products.Where(expression);
        }

        public async Task<List<Products>> WhereAsync(Expression<Func<Products, bool>> expression)
        {
            return await db.Products.Where(expression).ToListAsync();
        }

        public void StatusChanged(Products item)
        {
            //Məhsulun status dəyərini dəyişdirmək üçün
            throw new NotImplementedException();
        }
    }
}