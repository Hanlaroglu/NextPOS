using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Barcode_Sales.Barcode.Sales.Admin;

namespace Barcode_Sales.Operations.Concrete
{
    public class SupplierManager : ISupplierOperation
    {
        NextposDBEntities db = new NextposDBEntities();

        public bool Add(Suppliers item)
        {
            try
            {
                db.Suppliers.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task AddAsync(Suppliers item)
        {
            db.Suppliers.Add(item);
            await db.SaveChangesAsync();
        }

        public Suppliers GetById(int id)
        {
            return db.Suppliers.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Suppliers> GetByIdAsync(int id)
        {
            return await db.Suppliers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Suppliers item)
        {
            var args = NoticationHelpers.Dialogs.DialogResultYesNo($"{item.SupplierName} təchizatçısını silmək istədiyinizə əminsiniz ?");
            var result = XtraMessageBox.Show(args);
            if (result is DialogResult.Yes)
            {
                fDashboard form = Application.OpenForms.OfType<fDashboard>().FirstOrDefault();
                var data = db.Suppliers.Find(item.Id);
                data.IsDeleted = data.Id;
                db.SaveChanges();
                NoticationHelpers.Messages.SuccessMessage(form, $"{data.SupplierName} təchizatçısı uğurla silindi");
            }
        }

        public async Task RemoveAsync(Suppliers item)
        {
            var data = await GetByIdAsync(item.Id);
            data.IsDeleted = data.Id;
            await db.SaveChangesAsync();
        }

        public void Update(Suppliers item)
        {
            var existingItem = db.Suppliers.Find(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                db.SaveChanges();
            }
        }

        public async Task UpdateAsync(Suppliers item)
        {
            var existingItem = await db.Suppliers.FindAsync(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                await db.SaveChangesAsync();
            }
        }

        public IQueryable<Suppliers> Where(Expression<Func<Suppliers, bool>> expression)
        {
            return db.Suppliers.AsNoTracking().Where(expression);
        }

        public async Task<List<Suppliers>> WhereAsync(Expression<Func<Suppliers, bool>> expression)
        {
            return await db.Suppliers.Where(expression).ToListAsync();
        }

        public string Blocked(Suppliers item)
        {
            if (item is null) return null;

            item.Status = false;
            db.SaveChanges();

            return $"{item.SupplierName} təchizatçısı deaktiv edildi";
        }

        public async Task BlockedAsync(List<Suppliers> items)
        {
            foreach (var item in items)
            {
                var data = await GetByIdAsync(item.Id);
                if (data is null || data.Status is false) continue;

                data.Status = false;
            }
            await db.SaveChangesAsync();
        }

        public string Active(Suppliers item)
        {
            if (item is null) return null;

            item.Status = true;
            db.SaveChanges();

            return $"{item.SupplierName} təchizatçısı aktiv edildi";
        }

        public async Task ActiveAsync(List<Suppliers> items)
        {
            foreach (var item in items)
            {
                var data = await GetByIdAsync(item.Id);
                if (data is null || data.Status is true) continue;

                data.Status = true;
            }
            await db.SaveChangesAsync();
        }
    }
}
