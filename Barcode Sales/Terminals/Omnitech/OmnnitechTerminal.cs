using Barcode_Sales.Terminals.DTOs;
using Barcode_Sales.Terminals.Omnitech.Requests;
using Barcode_Sales.Terminals.Omnitech.Responses;

namespace Barcode_Sales.Terminals.Omnitech
{
    public class OmnnitechTerminal : IBaseTerminal
    {
        public string Login(string IpAddress)
        {
            var login = new LoginRequest();

            var request = BaseRequest<LoginRequest>.Create(login);

            var response = TerminalHttpHelper.Post<
                BaseRequest<LoginRequest>,
                LoginResponse>(IpAddress, request);

            return response.access_token;
        }

        public bool OpenShift(ShiftDto item)
        {
            throw new System.NotImplementedException();
        }

        public void GetShiftStatus(ShiftDto item)
        {
            throw new System.NotImplementedException();
        }

        public bool CloseShift(ShiftDto item)
        {
            throw new System.NotImplementedException();
        }

        public bool Deposit()
        {
            throw new System.NotImplementedException();
        }

        public bool Withdraw()
        {
            throw new System.NotImplementedException();
        }

        public bool Sale()
        {
            throw new System.NotImplementedException();
        }

        public bool Rollback()
        {
            throw new System.NotImplementedException();
        }

        public bool Refund()
        {
            throw new System.NotImplementedException();
        }

        public bool CreditSale()
        {
            throw new System.NotImplementedException();
        }

        public bool CreditPay()
        {
            throw new System.NotImplementedException();
        }

        public bool PrepaymentPay()
        {
            throw new System.NotImplementedException();
        }

        public bool PrepaymentSale()
        {
            throw new System.NotImplementedException();
        }
    }
}
