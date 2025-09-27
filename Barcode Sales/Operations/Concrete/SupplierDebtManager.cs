using Barcode_Sales.Barcode.Sales.Admin;
using Barcode_Sales.Forms;
using Barcode_Sales.Operations.Abstract;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales.Operations.Concrete
{
    internal class SupplierDebtManager : ISupplierDebtOperation
    {
        NextposDBEntities db = new NextposDBEntities();

        public bool Add(SuppliersDebt item)
        {
            try
            {
                db.SuppliersDebts.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Barcode.Sales.Admin.fDashboard form = Application.OpenForms.OfType<Barcode.Sales.Admin.fDashboard>().FirstOrDefault();
                NotificationHelpers.Messages.ErrorMessage(form, $"{ex.Message}");
                return false;
            }
        }

        public Task AddAsync(SuppliersDebt item)
        {
            throw new NotImplementedException();
        }

        public SuppliersDebt GetById(int id)
        {
            return db.SuppliersDebts.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<SuppliersDebt> GetByIdAsync(int id)
        {
            return await db.SuppliersDebts.FirstOrDefaultAsync(x => x.Id == id);

        }

        public void Remove(SuppliersDebt item)
        {
            var args = NotificationHelpers.Dialogs.DialogResultYesNo($"{item.Supplier.SupplierName} təchizatçısının {item.Name} adlı borcunu silmək istədiyinizə əminsiniz ?");
            var result = XtraMessageBox.Show(args);
            if (result is DialogResult.Yes)
            {
                var data = db.SuppliersDebts.Find(item.Id);
                data.IsDeleted = data.Id;
                db.SaveChanges();

                Barcode.Sales.Admin.fDashboard form = Application.OpenForms.OfType<Barcode.Sales.Admin.fDashboard>().FirstOrDefault();
                NotificationHelpers.Messages.SuccessMessage(form, $"{data.Supplier.SupplierName} təchizatçısının {data.Name} adlı borcu uğurla silindi");
            }
        }

        public async Task RemoveAsync(SuppliersDebt item)
        {
            var data = await GetByIdAsync(item.Id);
            data.IsDeleted = data.Id;
            await db.SaveChangesAsync();
        }

        public void Update(SuppliersDebt item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SuppliersDebt item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SuppliersDebt> Where(Expression<Func<SuppliersDebt, bool>> expression)
        {
            return db.SuppliersDebts.AsNoTracking().Where(expression);
        }

        public async Task<List<SuppliersDebt>> WhereAsync(Expression<Func<SuppliersDebt, bool>> expression = null)
        {
            return await db.SuppliersDebts.AsNoTracking()
                                          .Where(x => x.IsDeleted == 0)
                                          .Where(expression).ToListAsync();

        }

        public double SupplierTotalDebt(int supplierId)
        {
            var debtTotal = db.SuppliersDebts
                              .Where(x => x.SupplierId == supplierId && x.IsDeleted == 0)
                              .Sum(x => (x.Debt ?? 0) + (x.TaxDebt ?? 0));

            return debtTotal;
        }
    }
}
