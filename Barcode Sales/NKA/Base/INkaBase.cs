using static Barcode_Sales.NKA.DTOs.NkaDto;

namespace Barcode_Sales.NKA.Base
{
    public interface INkaBase
    {
        string Login(LoginDto item); //AccessToken qaytarır
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