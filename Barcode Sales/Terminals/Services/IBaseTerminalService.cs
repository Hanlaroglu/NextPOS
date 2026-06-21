using Barcode_Sales.DTOs;
using Barcode_Sales.Terminals.DTOs;
using System.Threading.Tasks;

namespace Barcode_Sales.Terminals.Services
{
    public interface IBaseTerminalService
    {
        TerminalResult GetInfo();
        TerminalResult Login();
        TerminalResult OpenShift();
        TerminalResult GetShiftStatus();
        TerminalResult XReport();
        TerminalResult CloseShift();
        TerminalResult Deposit(decimal amount);
        TerminalResult Withdraw(decimal amount);
        Task<TerminalResult> Sale(PosSaleDto item);
        Task<TerminalResult> Rollback(PosRefundDto item);
        Task<TerminalResult> Refund(PosRefundDto item);
        Task<TerminalResult> ReceiptCopy(string fiscalId);
        bool CreditSale();
        bool CreditPay();
        //Kredit satış qaytarmalarını və avans qaytarmalarını da əlavə et
        bool PrepaymentPay();
        bool PrepaymentSale();
    }
}
