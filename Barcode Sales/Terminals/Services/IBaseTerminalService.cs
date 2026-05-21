using Barcode_Sales.Terminals.DTOs;
using System.Threading.Tasks;

namespace Barcode_Sales.Terminals.Services
{
    public interface IBaseTerminalService
    {
        TerminalResult Login();
        TerminalResult OpenShift();
        TerminalResult GetShiftStatus();
        TerminalResult XReport();
        TerminalResult CloseShift();
        TerminalResult Deposit(decimal amount);
        TerminalResult Withdraw(decimal amount);
        Task<TerminalResult> Sale(PosSaleDto item);
        bool Rollback();
        bool Refund();
        bool CreditSale();
        bool CreditPay();
        //Kredit satış qaytarmalarını və avans qaytarmalarını da əlavə et
        bool PrepaymentPay();
        bool PrepaymentSale();
    }
}
