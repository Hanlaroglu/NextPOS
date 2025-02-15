using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
            expression = expression ?? (x => x.IsDeleted == CommonData.DEFAULT_INT);

            return await db.Terminals.AsNoTracking()
                                     .Where(expression)
                                     .ToListAsync()
                                     .ConfigureAwait(false);
        }

        public string GetIpAddress()
        {
            var terminal = Where(x => x.UserId == CommonData.USER_ID).FirstOrDefault();


            KassaOperator kassa = (KassaOperator)Enum.Parse(typeof(KassaOperator), terminal.Name);

            switch (kassa)
            {
                case KassaOperator.SUNMI:
                    return $"http://{terminal.IpAddress}";
                case KassaOperator.OMNITECH:
                    return $"http://{terminal.IpAddress}/v2";
                case KassaOperator.AZSMART:
                    return $"http://{terminal.IpAddress}";
                case KassaOperator.NBA:
                    return $"http://{terminal.IpAddress}/api/v1";
                case KassaOperator.TIANYU:
                    return $"http://{terminal.IpAddress}";
                case KassaOperator.DATAPAY:
                    return $"http://{terminal.IpAddress}";
                default:
                    return $"Yoxdur";
            }

        }
    }
}
