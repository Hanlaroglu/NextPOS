using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Services.CacheServices;
using Barcode_Sales.Services.Interfaces;
using Barcode_Sales.Terminals.DTOs;
using System.Linq;
using System.Threading.Tasks;

namespace Barcode_Sales.Services
{
    public class PosSaleService : IPosSaleService
    {
        private readonly IPosSaleOperation saleOperation;
        private readonly IPosSaleItemOperation saleItemOperation;

        public PosSaleService()
        {
            saleOperation = new PosSaleManager();
            saleItemOperation = new PosSaleItemManager();
        }

        public async Task<int> CompleteSaleAsync(PosSaleDto sale, TerminalSaleResultDto terminal)
        {
            int saleId = await saleOperation.Add(new PosSale
            {
                UserId = UserCacheService.User.Id,
                ReceiptNo = terminal?.ReceiptNo,
                LongFiscalId = terminal?.LongFiscalId,
                ShortFiscalId = terminal?.ShortFiscalId,
                BankRrn = string.IsNullOrWhiteSpace(terminal?.Rrn) ? terminal?.Rrn : sale.Rrn,
                SaleDate = DatetimeService.CurrentDateTime,
                SaleDatetime = DatetimeService.CurrentDateTime,
                Total = sale.Items.Sum(x => x.Total),
                Cash = sale.Cash,
                Card = sale.Card,
                IncomingSum = sale.IncomingSum,
                Residue = sale.IncomingSum - sale.Cash,
                CustomerId = sale.Customer?.Id,
                Note = sale.Note,
            });

            if (saleId == -1)
                return -1;

           var items = sale.Items.Select(x => new PosSaleItem
            {
                PosSaleId = saleId,
                ProductId = x.Id,
                Quantity = x.Quantity,
                SalePrice = x.SalePrice,
                Discount = x.Discount
            }).ToList();

            var itemResult = await saleItemOperation.Add(items);

            return saleId;
        }
    }
}
