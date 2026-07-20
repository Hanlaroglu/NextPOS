using Barcode_Sales.DTOs;
using Barcode_Sales.Services;
using Barcode_Sales.Services.Interfaces;
using Barcode_Sales.Terminals.Caspos.Requests;
using Barcode_Sales.Terminals.Caspos.Responses;
using Barcode_Sales.Terminals.DTOs;
using Barcode_Sales.Terminals.Services;
using System;
using System.Threading.Tasks;

namespace Barcode_Sales.Terminals.Caspos
{
    public class CasposTerminal : IBaseTerminalService
    {
        private string _ipAddress { get; }

        private readonly IPosSaleService _saleService;

        public CasposTerminal(string ipAddress)
        {
            _ipAddress = ipAddress;
            _saleService = new PosSaleService();
        }

        public TerminalResult Login()
        {
            throw new NotImplementedException();
        }

        public TerminalResult GetInfo()
        {
            var info = new GetInfoRequest();

            var request = BaseRequest<GetInfoRequest>.Create(info);

            var result = TerminalHttpHelper.Post<BaseRequest<GetInfoRequest>, GetInfoResponse>(_ipAddress, request);

            if (!result.Success)
                return result;

            var response = result.GetData<GetInfoResponse>();

            if (response.message == "Successful operation")
                return TerminalResult.Ok();

            return TerminalResult.Fail($"Token məlumatları alınarkən xəta yarandı.\n{response.message}");
        }

        public TerminalResult OpenShift()
        {
            var data = new OpenShiftRequest();

            var request = BaseRequest<OpenShiftRequest>.Create(data);

            var result = TerminalHttpHelper.Post<BaseRequest<OpenShiftRequest>, OpenShiftResponse>(_ipAddress, request);

            if (!result.Success)
                return result;

            var response = result.GetData<OpenShiftResponse>();

            if (response.message == "Successful operation")
                return TerminalResult.Ok("Növbə uğurla açıldı");

            return TerminalResult.Fail($"Növbə açma zamanı xəta yarandı.\n{response.message}");
        }

        public TerminalResult GetShiftStatus()
        {
            var data = new GetShiftStatusRequest();

            var request = BaseRequest<GetShiftStatusRequest>.Create(data);

            var result = TerminalHttpHelper.Post<BaseRequest<GetShiftStatusRequest>, GetShiftStatusResponse>(_ipAddress, request);

            if (!result.Success)
                return result;

            var response = result.GetData<GetShiftStatusResponse>();
            if (response.data.ShiftOpen)
            {
                string openTime = response.data.ShiftOpenTime;
                return TerminalResult.Ok($"Növbə artıq açıqdır: {openTime}");
            }

            return OpenShift();
        }

        public TerminalResult XReport()
        {
            throw new NotImplementedException();
        }

        public TerminalResult CloseShift()
        {
            throw new NotImplementedException();
        }

        public TerminalResult Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public TerminalResult Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<TerminalResult> Sale(PosSaleDto item)
        {
            throw new NotImplementedException();
        }

        public Task<TerminalResult> Rollback(PosRefundDto item)
        {
            throw new NotImplementedException();
        }

        public Task<TerminalResult> Refund(PosRefundDto item)
        {
            throw new NotImplementedException();
        }

        public Task<TerminalResult> ReceiptCopy(string fiscalId)
        {
            throw new NotImplementedException();
        }

        public bool CreditSale()
        {
            throw new NotImplementedException();
        }

        public bool CreditPay()
        {
            throw new NotImplementedException();
        }

        public bool PrepaymentPay()
        {
            throw new NotImplementedException();
        }

        public bool PrepaymentSale()
        {
            throw new NotImplementedException();
        }
    }
}