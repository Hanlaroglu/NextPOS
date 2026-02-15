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
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(Product item)
        {
            try
            {
                db.Set<Product>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<Product> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<Product>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Product item, params Expression<Func<Product, object>>[] updateProperties)
        {
            try
            {
                db.Set<Product>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<Product> items, params Expression<Func<Product, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<Product>().Attach(entity);

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

        //public async Task<bool> Remove(Product item)
        //{
        //    try
        //    {
        //        db.Set<Product>().Remove(item);
        //        return await db.SaveChangesAsync() > 0;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public async Task<Product> Get(Expression<Func<Product, bool>> expression)
        {
            return await db.Products.FirstOrDefaultAsync(expression);
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return db.Products.Where(expression);
        }

        public async Task<List<Product>> ToListAsync(Expression<Func<Product, bool>> expression = null)
        {
            if (expression is null)
                return await db.Products.AsNoTracking().ToListAsync();
            else
                return await db.Products.AsNoTracking().Where(expression).ToListAsync();
        }













        public void Remove(Product item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.ProductName} məhsulunu silmək istədiyinizə əminsiniz ?"))
            {
                Product product = db.Products.FirstOrDefault(x => x.Id == item.Id);
                product.IsDeleted = product.Id;
                db.SaveChanges();
            }
        }

        public void Update(Product item)
        {
            var existingItem = db.Products.Find(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                db.SaveChanges();
            }
        }

        public void StatusChanged(Product item)
        {
            //Məhsulun status dəyərini dəyişdirmək üçün
            throw new NotImplementedException();
        }

        public async Task<Product> GetByBarcodeAsync(string barcode)
        {
            return await db.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Barcode == barcode.Trim() && x.IsDeleted == 0);
        }

        public async Task<bool> BarcodeCheckAsync(string barcode, int supplierId)
        {
            return await db.Products.AsNoTracking().AnyAsync(x => x.Barcode == barcode.Trim()
                                                                  && x.SupplierId == supplierId
                                                                  && x.IsDeleted == 0);
        }
    }
}