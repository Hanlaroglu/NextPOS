using Barcode_Sales.Barcode.Sales.Admin;
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
    public class CustomerDebtManager : ICustomerDebtOperation
    {
        NextposDBEntities db = new NextposDBEntities();
        public bool Add(CustomersDebt item)
        {
            try
            {
                db.CustomersDebts.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                fDashboard form = Application.OpenForms.OfType<fDashboard>().FirstOrDefault();
                NoticationHelpers.Messages.ErrorMessage(form, $"{ex.Message}");
                return false;
            }
        }

        public Task AddAsync(CustomersDebt item)
        {
            throw new NotImplementedException();
        }

        public CustomersDebt GetById(int id)
        {
            return db.CustomersDebts.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<CustomersDebt> GetByIdAsync(int id)
        {
            return await db.CustomersDebts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(CustomersDebt item)
        {
            var args = NoticationHelpers.Dialogs.DialogResultYesNo($"{item.Customer.NameSurname} müştərisinin {item.Type} borcunu silmək istədiyinizə əminsiniz ?");
            var result = XtraMessageBox.Show(args);
            if (result is DialogResult.Yes)
            {
                var data = db.CustomersDebts.Find(item.Id);
                data.IsDeleted = data.Id;
                db.SaveChanges();

                fDashboard form = Application.OpenForms.OfType<fDashboard>().FirstOrDefault();
                NoticationHelpers.Messages.SuccessMessage(form, $"{data.Customer.NameSurname} müştərisinin {data.Type} borcu uğurla silindi");
            }
        }

        public async Task RemoveAsync(CustomersDebt item)
        {
            var data = await GetByIdAsync(item.Id);
            data.IsDeleted = data.Id;
            await db.SaveChangesAsync();
        }

        public void Update(CustomersDebt item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CustomersDebt item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CustomersDebt> Where(Expression<Func<CustomersDebt, bool>> expression)
        {
            return db.CustomersDebts.AsNoTracking().Where(expression);
        }

        public async Task<List<CustomersDebt>> WhereAsync(Expression<Func<CustomersDebt, bool>> expression = null)
        {
            return await db.CustomersDebts.AsNoTracking()
                                          .Where(x => x.IsDeleted == 0)
                                          .Where(expression).ToListAsync();
        }

        public double CustomersTotalDebt(int customerId)
        {
            var debtTotal = db.CustomersDebts
                              .Where(x => x.CustomerId == customerId && x.IsDeleted == 0)
                              .Sum(x => (x.Debt ?? 0));

            return debtTotal;
        }
    }
}
