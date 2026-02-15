using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Barcode_Sales.Operations.Concrete
{
    internal class SupplierDebtManager : ISupplierDebtOperation
    {
        KhanposDbEntities db = new KhanposDbEntities();


        public async Task<int> Add(SuppliersDebt item)
        {
            try
            {
                db.Set<SuppliersDebt>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<SuppliersDebt> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<SuppliersDebt>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(SuppliersDebt item, params Expression<Func<SuppliersDebt, object>>[] updateProperties)
        {
            try
            {
                db.Set<SuppliersDebt>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<SuppliersDebt> items, params Expression<Func<SuppliersDebt, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<SuppliersDebt>().Attach(entity);

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

        public async Task<bool> Remove(SuppliersDebt item)
        {
            try
            {
                db.Set<SuppliersDebt>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<SuppliersDebt> Get(Expression<Func<SuppliersDebt, bool>> expression)
        {
            return await db.SuppliersDebts.FirstOrDefaultAsync(expression);
        }

        public IQueryable<SuppliersDebt> Where(Expression<Func<SuppliersDebt, bool>> expression)
        {
            return db.SuppliersDebts.Where(expression);
        }

        public async Task<List<SuppliersDebt>> ToListAsync(Expression<Func<SuppliersDebt, bool>> expression = null)
        {
            if (expression is null)
                return await db.SuppliersDebts.AsNoTracking().ToListAsync();
            else
                return await db.SuppliersDebts.AsNoTracking().Where(expression).ToListAsync();
        }

        //public void Remove(SuppliersDebt item)
        //{
        //    var args = NotificationHelpers.Dialogs.DialogResultYesNo($"{item.Supplier.SupplierName} təchizatçısının {item.Name} adlı borcunu silmək istədiyinizə əminsiniz ?");
        //    var result = XtraMessageBox.Show(args);
        //    if (result is DialogResult.Yes)
        //    {
        //        var data = db.SuppliersDebts.Find(item.Id);
        //        data.IsDeleted = data.Id;
        //        db.SaveChanges();

        //        Barcode.Sales.Admin.fDashboard form = Application.OpenForms.OfType<Barcode.Sales.Admin.fDashboard>().FirstOrDefault();
        //        NotificationHelpers.Messages.SuccessMessage(form, $"{data.Supplier.SupplierName} təchizatçısının {data.Name} adlı borcu uğurla silindi");
        //    }
        //}

        public double SupplierTotalDebt(int supplierId)
        {
            var debtTotal = db.SuppliersDebts
                              .Where(x => x.SupplierId == supplierId && x.IsDeleted == 0)
                              .Sum(x => (x.Debt ?? 0) + (x.TaxDebt ?? 0));

            return debtTotal;
        }
    }
}
