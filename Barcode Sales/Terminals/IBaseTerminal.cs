
using Barcode_Sales.Terminals.DTOs;

namespace Barcode_Sales.Terminals
{
    public interface IBaseTerminal
    {
        string Login(string IpAddress); //AccessToken qaytarır
        bool OpenShift(ShiftDto item);
        void GetShiftStatus(ShiftDto item);
        bool CloseShift(ShiftDto item);
        bool Deposit();
        bool Withdraw();
        bool Sale();
        bool Rollback();
        bool Refund();
        bool CreditSale();
        bool CreditPay();
        //Kredit satış qaytarmalarını və avans qaytarmalarını da əlavə et
        bool PrepaymentPay();
        bool PrepaymentSale();
    }
}
