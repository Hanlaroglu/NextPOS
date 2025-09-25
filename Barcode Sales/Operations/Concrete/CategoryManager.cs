using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Barcode_Sales.Operations.Concrete
{
    public class CategoryManager : ICategoryOperation
    {
        NextposDBEntities db = new NextposDBEntities();
        private IProductOperation productOperation { get; set; }
        public bool Add(Categories item)
        {
            try
            {
                db.Categories.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task AddAsync(Categories item)
        {
            db.Categories.Add(item);
            await db.SaveChangesAsync();
        }

        public Categories GetById(int id)
        {
            return db.Categories.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Categories> GetByIdAsync(int id)
        {
            return await db.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Categories item)
        {
            productOperation = new ProductManager();

            var product = productOperation.Where(x => x.IsDeleted == 0 && x.CategoryId == item.Id).ToList();

            bool message = false;

            if (product.Count == 0)
            {
                var args = NoticationHelpers.Dialogs.DialogResultYesNo(
                    $"({item.CategoryName}) kateqoriyasını silmək istədiyinizə əminsiniz ?", String.Empty);
                message = XtraMessageBox.Show(args) == DialogResult.Yes;
            }
            else
            {
  var args = NoticationHelpers.Dialogs.DialogResultYesNo(
                    $@"({item.CategoryName}) kateqoriyasında '{product.Count}' məhsul var. Bu kateqoriyanı silmək istədiyinizə əminsiniz ?", "Diqqət!");
                message = XtraMessageBox.Show(args) == DialogResult.Yes;
            }

            if (message)
            {
                foreach (var x in product)
                    x.IsDeleted = x.Id;

                Categories data = GetById(item.Id);
                data.IsDeleted = data.Id;
                db.SaveChanges();
            }
        }

        public async Task RemoveAsync(Categories item)
        {
            productOperation = new ProductManager();

            var product = productOperation.WhereAsync(x => x.IsDeleted == 0 && x.CategoryId == item.Id);

            bool message = false;

            if (product.Result.Count == 0)
            {
                message = CommonMessageBox.QuestionDialogResult($"{item.CategoryName} kateqoriyasını silmək istədiyinizə əminsiniz ?");

            }
            else
            {
                message = CommonMessageBox.QuestionDialogResult($"{item.CategoryName} kateqoriyasının daxilindəki '{product.Result.Count}' məhsulda silinəcəkdir.\n\n" +
                    $"{item.CategoryName} kateqoriyasını silmək istədiyinizə əminsiniz ?");

            }

            if (message)
            {
                foreach (var x in product.Result)
                {
                    x.IsDeleted = x.Id;
                    await db.SaveChangesAsync();
                }

                var data = await db.Categories.FindAsync(item.Id);
                data.IsDeleted = data.Id;
                await db.SaveChangesAsync();
            }
        }

        public void Update(Categories item)
        {
            var existingItem = GetById(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                db.SaveChanges();
            }
        }

        public async Task UpdateAsync(Categories item)
        {
            var existingItem = await db.Categories.FindAsync(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                await db.SaveChangesAsync();
            }
        }

        public IQueryable<Categories> Where(Expression<Func<Categories, bool>> expression)
        {
            return db.Categories.AsNoTracking().Where(expression);
        }

        public async Task<List<Categories>> WhereAsync(Expression<Func<Categories, bool>> expression)
        {
            return await db.Categories.Where(expression).ToListAsync();
        }

        public void StatusUpdate(Categories item)
        {
            productOperation = new ProductManager();

            var product = productOperation.Where(x => x.IsDeleted == 0 && x.CategoryId == item.Id).ToList();

            string boolMessage = (bool)item.Status ? "aktiv" : "deaktiv";

            bool message = false;

            if (product.Count == 0)
            {
                message = true;

            }
            else
            {
                message = CommonMessageBox.QuestionDialogResult($"{item.CategoryName} kateqoriyasının daxilindəki '{product.Count}' məhsulun statusu da {boolMessage} ediləcəkdir.\n\n" +
                    $"{item.CategoryName} kateqoriyasını deaktiv etmək istədiyinizə əminsiniz ?");

            }

            if (message)
            {
                foreach (var x in product)
                {
                    x.Status = item.Status;
                    db.SaveChanges();
                }

                var existingItem = db.Categories.Find(item.Id);
                existingItem.Status = item.Status;
                db.SaveChanges();
            }
        }
    }
}