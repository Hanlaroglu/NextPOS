using Barcode_Sales.Forms;
using Barcode_Sales.Helpers;
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
        KhanposDbEntities db = new KhanposDbEntities();

        public async Task<int> Add(Terminal item)
        {
            try
            {
                db.Set<Terminal>().Add(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> Add(List<Terminal> items)
        {
            if (items == null || items.Count == 0)
                return false;


            try
            {
                db.Set<Terminal>().AddRange(items);
                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Terminal> Get(Expression<Func<Terminal, bool>> expression)
        {
            return await db.Terminals.FirstOrDefaultAsync(expression);
        }

        public async Task<bool> Update(Terminal item, params Expression<Func<Terminal, object>>[] updateProperties)
        {
            try
            {
                db.Set<Terminal>().Attach(item);

                foreach (var property in updateProperties)
                    db.Entry(item).Property(property).IsModified = true;

                return await db.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(List<Terminal> items, params Expression<Func<Terminal, object>>[] updateProperties)
        {
            if (items == null || items.Count == 0)
                return false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in items)
                    {
                        db.Set<Terminal>().Attach(entity);

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

        public async Task<bool> Remove(Terminal item)
        {
            try
            {
                db.Set<Terminal>().Remove(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch { return false; }
        }

        public IQueryable<Terminal> Where(Expression<Func<Terminal, bool>> expression)
        {
            return db.Terminals.AsNoTracking().Where(expression);
        }

        public async Task<List<Terminal>> ToListAsync(Expression<Func<Terminal, bool>> expression = null)
        {
            if (expression is null)
                return await db.Terminals.AsNoTracking()
                                         .Where(x => x.IsDeleted == 0)
                                         .ToListAsync();
            else
                return await db.Terminals.AsNoTracking()
                                         .Where(x => x.IsDeleted == 0)
                                         .Where(expression)
                                         .ToListAsync();
        }

        public Terminal GetIpAddress()
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
                    case KassaOperator.CASPOS:
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
