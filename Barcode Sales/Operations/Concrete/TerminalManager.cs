using Barcode_Sales.Forms;
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
using static Barcode_Sales.Helpers.Enums;

namespace Barcode_Sales.Operations.Concrete
{
    public class TerminalManager : ITerminalOperation
    {
        NextposDBEntities db = new NextposDBEntities();
        public bool Add(Terminals item)
        {
            try
            {
                db.Terminals.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task AddAsync(Terminals item)
        {
            db.Terminals.Add(item);
            await db.SaveChangesAsync();
        }

        public Terminals GetById(int id)
        {
            return db.Terminals.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<Terminals> GetByIdAsync(int id)
        {
            return await db.Terminals.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Terminals item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.Name} kassasını silmək istədiyinizə əminsiniz ?"))
            {
                var data = db.Terminals.Find(item.Id);
                data.IsDeleted = data.Id;
                db.SaveChanges();
            }
        }

        public async Task RemoveAsync(Terminals item)
        {
            if (CommonMessageBox.QuestionDialogResult($"{item.Name} kassasını silmək istədiyinizə əminsiniz ?"))
            {
                var data = await db.Terminals.FindAsync(item.Id);
                data.IsDeleted = data.Id;
                await db.SaveChangesAsync();
            }
        }

        public void Update(Terminals item)
        {
            var existingItem = db.Terminals.Find(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                db.SaveChanges();
            }
        }

        public async Task UpdateAsync(Terminals item)
        {
            var existingItem = await db.Terminals.FindAsync(item.Id);
            if (existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(item);
                await db.SaveChangesAsync();
            }
        }

        public IQueryable<Terminals> Where(Expression<Func<Terminals, bool>> expression)
        {
            return db.Terminals.AsNoTracking().Where(expression);
        }

        public async Task<List<Terminals>> WhereAsync(Expression<Func<Terminals, bool>> expression = null)
        {
            expression = expression ?? (x => x.IsDeleted == 0);

            return await db.Terminals.AsNoTracking()
                                     .Where(expression)
                                     .ToListAsync()
                                     .ConfigureAwait(false);
        }

        public Terminals GetIpAddress()
        {
            var terminal = Where(x => x.UserId == CommonData.CURRENT_USER.Id && x.IsDeleted == 0).FirstOrDefault();
            fPosSales _form = Application.OpenForms.OfType<fPosSales>().FirstOrDefault();

            if (terminal is null || terminal?.IsDeleted != 0)
            {
                NotificationHelpers.Messages.WarningMessage(_form, "İstifadəçiyə kassa təyin edilməmiştir");
                return null;
            }
            else if (terminal.Status is false)
            {
                NotificationHelpers.Messages.WarningMessage(_form, "İstifadəçinin kassa statusu aktiv deyil");
                return null;
            }

            if (terminal != null)
            {
                KassaOperator kassa = (KassaOperator)Enum.Parse(typeof(KassaOperator), terminal.Name);

                switch (kassa)
                {
                    case KassaOperator.SUNMI:
                        terminal.IpAddress = $"http://{terminal.IpAddress}";
                        break;
                    case KassaOperator.OMNITECH:
                        terminal.IpAddress = $"http://{terminal.IpAddress}/v2";
                        break;
                    case KassaOperator.AZSMART:
                        terminal.IpAddress = $"http://{terminal.IpAddress}";
                        break;
                    case KassaOperator.NBA:
                        terminal.IpAddress = $"http://{terminal.IpAddress}/api/v1";
                        break;
                    case KassaOperator.TIANYU:
                        terminal.IpAddress = $"http://{terminal.IpAddress}";
                        break;
                    case KassaOperator.DATAPAY:
                        terminal.IpAddress = $"http://{terminal.IpAddress}";
                        break;
                    case KassaOperator.ONECLICK:
                        terminal.IpAddress = $"http://{terminal.IpAddress}";
                        break;
                }
                return terminal;
            }
            else
                return null;

        }
    }
}
