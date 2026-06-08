using Barcode_Sales.DTOs;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Services.CacheServices;
using Barcode_Sales.Terminals.DTOs;
using Barcode_Sales.Terminals.Omnitech.Models;
using Barcode_Sales.Terminals.Omnitech.Requests;
using Barcode_Sales.Terminals.Omnitech.Responses;
using Barcode_Sales.Terminals.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barcode_Sales.Terminals.Omnitech
{
    public class OmnnitechTerminal : IBaseTerminalService
    {
        private string _accessToken;
        private readonly string _ipAddress;
        IPosSaleOperation posSaleOperation = new PosSaleManager();
        IPosSaleItemOperation posSaleItemOperation = new PosSaleItemManager();
        IPosRefundOperation posRefundOperation = new PosRefundManager();
        IPosRefundItemOperation posRefundItemOperation = new PosRefundItemManager();

        private TerminalResult RefreshToken()
        {
            if (string.IsNullOrWhiteSpace(_accessToken))
                return Login();

            return TerminalResult.Ok();
        }

        private bool IsTokenExpired(TerminalResult result)
        {
            return result.Code == 401;
        }

        public OmnnitechTerminal(string ipAddress)
        {
            _ipAddress = ipAddress;
        }

        public TerminalResult Login()
        {
            var login = new LoginRequest();

            var request = BaseRequest<LoginRequest>.Create(login);

            var result = TerminalHttpHelper.Post<BaseRequest<LoginRequest>, LoginResponse>(_ipAddress, request);

            if (!result.Success)
                return result;

            var response = result.GetData<LoginResponse>();

            if (string.IsNullOrWhiteSpace(response?.access_token))
                return TerminalResult.Fail(response.message, response);

            _accessToken = response.access_token;
            return TerminalResult.Ok(response.message, response);
        }

        public TerminalResult OpenShift()
        {
            var data = new OpenShiftRequest { access_token = _accessToken };

            var request = BaseRequest<OpenShiftRequest>.Create(data);

            var result = TerminalHttpHelper.Post<BaseRequest<OpenShiftRequest>, OpenShiftResponse>(_ipAddress, request);

            if (!result.Success)
                return result;

            if (!result.Success && IsTokenExpired(result))
                return TerminalResult.Fail(result.Message, result);

            var response = result.GetData<OpenShiftResponse>();

            if (response.message == "Successful operation")
                return TerminalResult.Ok("Növbə uğurla açıldı");

            return TerminalResult.Fail($"Növbə açma zamanı xəta yarandı.\n{response.message}");
        }

        public TerminalResult GetShiftStatus()
        {
            var tokenResult = RefreshToken();
            if (!tokenResult.Success)
                return tokenResult;

            var data = new ShiftStatusRequest { access_token = _accessToken };

            var request = BaseRequest<ShiftStatusRequest>.Create(data);

            var result = TerminalHttpHelper.Post<BaseRequest<ShiftStatusRequest>, ShiftStatusResponse>(_ipAddress, request);

            if (!result.Success && IsTokenExpired(result))
            {
                _accessToken = null;
                var retryLogin = Login();
                if (!retryLogin.Success)
                    return TerminalResult.Fail("Yeni token əldə etmək uğursuz oldu", result);

                GetShiftStatus();
            }

            if (!result.Success)
                return result;

            var response = result.GetData<ShiftStatusResponse>();
            if (response.ShiftStatus)
            {
                string openTime = response.ShiftOpenTime.Value.ToString("dd.MM.yyyy HH:mm:ss");
                return TerminalResult.Ok($"Növbə artıq açıqdır: {openTime}");
            }

            return OpenShift();
        }

        public TerminalResult XReport()
        {
            var tokenResult = RefreshToken();
            if (!tokenResult.Success)
                return tokenResult;

            var data = new XReportRequest() { access_token = _accessToken };

            var request = BaseRequest<XReportRequest>.Create(data);

            var result = TerminalHttpHelper.Post<BaseRequest<XReportRequest>, XReportResponse>(_ipAddress, request);

            if (!result.Success && IsTokenExpired(result))
            {
                _accessToken = null;
                var retryLogin = Login();
                if (!retryLogin.Success)
                    return TerminalResult.Fail("Yeni token əldə etmək uğursuz oldu", result);

                XReport();
            }

            if (!result.Success)
                return result;

            var response = result.GetData<XReportResponse>();

            if (response.message == "Successful operation")
                return TerminalResult.Ok("X - Hesabat uğurla çap edildi");

            return TerminalResult.Fail($"X - Hesabatı çıxarılarkən xəta yarandı.\n{response.message}");
        }

        public TerminalResult CloseShift()
        {
            var tokenResult = RefreshToken();
            if (!tokenResult.Success)
                return tokenResult;

            var data = new CloseShiftRequest() { access_token = _accessToken };

            var request = BaseRequest<CloseShiftRequest>.Create(data);

            var result = TerminalHttpHelper.Post<BaseRequest<CloseShiftRequest>, CloseShiftResponse>(_ipAddress, request);

            if (!result.Success && IsTokenExpired(result))
            {
                _accessToken = null;
                var retryLogin = Login();
                if (!retryLogin.Success)
                    return TerminalResult.Fail("Yeni token əldə etmək uğursuz oldu", result);

                CloseShift();
            }

            if (!result.Success)
                return result;

            var response = result.GetData<CloseShiftResponse>();
            if (response.IsSuccess)
                return TerminalResult.Ok("Günsonu (Z) hesabatı uğurla çıxarıldı", response);

            return TerminalResult.Fail(response.message, response);
        }

        public TerminalResult Deposit(decimal amount)
        {
            var ensure = RefreshToken();
            if (!ensure.Success)
                return ensure;

            var data = new DepositRequest
            {
                AccessToken = _accessToken,
                tokenData = new TokenData
                {
                    parameters = new Parameters
                    {
                        data = new CashOperationData { cashSum = amount }
                    }
                }
            };

            var request = BaseRequest<DepositRequest>.Create(data);
            var result = TerminalHttpHelper.Post<BaseRequest<DepositRequest>, DepositResponse>(_ipAddress, request);

            if (!result.Success && IsTokenExpired(result))
            {
                _accessToken = null;
                var retryLogin = Login();
                if (!retryLogin.Success)
                    return TerminalResult.Fail("Yeni token əldə etmək uğursuz oldu");

                return Deposit(amount);
            }

            if (!result.Success)
                return result;

            var response = result.GetData<DepositResponse>();
            if (response.IsSuccess)
                return TerminalResult.Ok($"{amount} AZN uğurla mədaxil edildi", response);

            return TerminalResult.Fail(response.message, response);
        }

        public TerminalResult Withdraw(decimal amount)
        {
            var ensure = RefreshToken();
            if (!ensure.Success)
                return ensure;

            var data = new WithdrawRequest
            {
                access_token = _accessToken,
                tokenData = new TokenData
                {
                    parameters = new Parameters
                    {
                        data = new CashOperationData { cashSum = amount }
                    }
                }
            };

            var request = BaseRequest<WithdrawRequest>.Create(data);
            var result = TerminalHttpHelper.Post<BaseRequest<WithdrawRequest>, WithdrawResponse>(_ipAddress, request);

            if (!result.Success && IsTokenExpired(result))
            {
                _accessToken = null;
                var retryLogin = Login();
                if (!retryLogin.Success)
                    return TerminalResult.Fail("Yeni token əldə etmək uğursuz oldu");

                return Withdraw(amount);
            }

            if (!result.Success)
                return result;

            var response = result.GetData<WithdrawResponse>();
            if (response.IsSuccess)
                return TerminalResult.Ok($"{amount} AZN uğurla məxaric edildi", response);

            return TerminalResult.Fail(response.message, response);
        }

        public async Task<TerminalResult> Sale(PosSaleDto item)
        {
            var ensure = RefreshToken();
            if (!ensure.Success)
                return ensure;

            var saleData = new Models.SaleData
            {
                Cashier = item.Cashier,
                Sum = item.Total,
                CashSum = item.Cash,
                CashlessSum = item.Card,
                IncomingSum = item.IncomingSum,
                PrepaymentSum = 0, /*item.PrepaymentSum,*/
                CreditSum = 0, /*item.CreditSum,*/
                BonusSum = item.Bonus,
                Items = item.Items.Select(i => new Item
                {
                    ItemName = i.ProductName,
                    ItemCode = i.Barcode,
                    ItemCodeType = 0,
                    ItemQuantity = i.Quantity,
                    ItemQuantityType = i.UnitId,
                    ItemPrice = i.SalePrice,
                    ItemSum = i.Total,
                    ItemVatPercent = i.TaxPercent,
                    Discount = i.Discount
                }).ToList(),
                VatAmounts = item.Items
                    .GroupBy(x => x.TaxPercent)
                    .Select(g => new VatAmount
                    {
                        VatPercent = g.Key,
                        VatSum = g.Sum(x => x.Total)
                    }).ToList()
            };

            var data = new SaleRequest
            {
                AccessToken = _accessToken,
                TokenData = new TokenData
                {
                    operationId = "createDocument",
                    version = 1,
                    parameters = new Parameters
                    {
                        DocType = "sale",
                        data = saleData
                    }
                }
            };

            var request = BaseRequest<SaleRequest>.Create(data);
            var result = TerminalHttpHelper.Post<BaseRequest<SaleRequest>, SaleResponse>(_ipAddress, request);

            if (!result.Success && IsTokenExpired(result))
            {
                _accessToken = null;
                var retryLogin = Login();
                if (!retryLogin.Success)
                    return TerminalResult.Fail("Yeni token əldə etmək uğursuz oldu");

                return await Sale(item);
            }

            if (!result.Success)
                return result;

            var response = result.GetData<SaleResponse>();
            if (response.IsSuccess)
            {
                int SaleId = await posSaleOperation.Add(new PosSale
                {
                    UserId = UserCacheService.User.Id,
                    ReceiptNo = response.DocumentNumber,
                    LongFiscalId = response.LongId,
                    ShortFiscalId = response.ShortId,
                    BankRrn = string.IsNullOrWhiteSpace(item.Rrn) ? response.Rrn : item.Rrn,
                    SaleDate = DatetimeService.CurrentDateTime,
                    SaleDatetime = DatetimeService.CurrentDateTime,
                    Total = item.Total,
                    Cash = item.Cash,
                    Card = item.Card,
                    IncomingSum = item.IncomingSum,
                    CustomerId = item.Customer?.Id,
                    Note = item.Note,
                });

                if (SaleId != -1)
                {
                    List<PosSaleItem> dataDetails = new List<PosSaleItem>();

                    dataDetails.AddRange(item.Items.Select(x => new PosSaleItem
                    {
                        PosSaleId = SaleId,
                        ProductId = x.Id,
                        Quantity = x.Quantity,
                        SalePrice = x.SalePrice,
                        Discount = x.Discount
                    }));

                    await posSaleItemOperation.Add(dataDetails);
                }
                return TerminalResult.Ok("Satış uğurla tamamlandı");
            }

            return TerminalResult.Fail("Satış uğursuz oldu");
        }

        public async Task<TerminalResult> Rollback(PosRefundDto item)
        {
            var ensure = RefreshToken();
            if (!ensure.Success)
                return ensure;

            var data = new RollbackRequest
            {
                AccessToken = _accessToken,
                FiscalId = item.LongFiscalId
            };

            var request = BaseRequest<RollbackRequest>.Create(data);
            var result = TerminalHttpHelper.Post<BaseRequest<RollbackRequest>, MoneyBackResponse>(_ipAddress, request);

            if (!result.Success && IsTokenExpired(result))
            {
                _accessToken = null;
                var retryLogin = Login();
                if (!retryLogin.Success)
                    return TerminalResult.Fail("Yeni token əldə etmək uğursuz oldu");

                return await Rollback(item);
            }

            if (!result.Success)
                return result;

            var response = result.GetData<MoneyBackResponse>();
            if (response.IsSuccess)
            {
                var refundId = await posRefundOperation.Add(new PosRefund
                {
                    OperationType = (int)Enums.OperationType.Rollback,
                    PosSaleId = item.PosSaleId,
                    ReceiptNo = response.DocumentNumber,
                    LongFiscalId = response.LongId,
                    ShortFiscalId = response.ShortId,
                    BankRrn = string.IsNullOrWhiteSpace(item.BankRrn) ? response.Rrn : item.BankRrn,
                    OperationDate = DatetimeService.CurrentDateTime,
                    Cash = item.Cash,
                    Card = item.Card,
                    Total = item.Total,
                    IncomingSum = item.Total,
                    CustomerId = item.Customer?.Id,
                    Note = item.Note,
                    UserId = UserCacheService.User.Id,
                });

                if (refundId != -1)
                {
                    List<PosRefundItem> dataDetails = new List<PosRefundItem>();

                    dataDetails.AddRange(item.Items.Select(x => new PosRefundItem
                    {
                        PosRefundId = refundId,
                        PosSaleItemId = x.Id,
                        ProductId = x.ProductId,
                        Quantity = x.RefundQuantity,
                        SalePrice = x.SalePrice,
                        Discount = x.DiscountAmount
                    }));

                    await posRefundItemOperation.Add(dataDetails);
                }
                return TerminalResult.Ok("Ləğv etmə uğurla tamamlandı");
            }

            return TerminalResult.Fail("Ləğv etmə uğursuz oldu");
        }

        public async Task<TerminalResult> Refund(PosRefundDto item)
        {
            var ensure = RefreshToken();
            if (!ensure.Success)
                return ensure;

            var refundData = new Models.RefundData
            {
                ParentDocument = item.LongFiscalId,
                RefundShortDocumentId = item.ShortFiscalId,
                RefundDocumentNumber = item.ReceiptNo,
                Cashier = item.Cashier,
                Sum = item.Total,
                CashSum = item.Items.Sum(x=> x.SalePrice * x.RefundQuantity - x.DiscountAmount),
                CashlessSum = 0,
                IncomingSum = item.Total,
                PrepaymentSum = 0,
                CreditSum = 0,
                BonusSum = item.Bonus,
                Items = item.Items.Select(i => new Item
                {
                    ItemName = i.ProductName,
                    ItemCode = i.Barcode,
                    ItemCodeType = 0,
                    ItemQuantity = i.RefundQuantity,
                    ItemQuantityType = i.UnitId,
                    ItemPrice = i.SalePrice,
                    ItemSum = i.TotalAmount,
                    ItemVatPercent = i.TaxPercent,
                    Discount = i.DiscountAmount
                }).ToList(),
                VatAmounts = item.Items
                    .GroupBy(x => x.TaxPercent)
                    .Select(g => new VatAmount
                    {
                        VatPercent = g.Key,
                        VatSum = g.Sum(x => x.TotalAmount)
                    }).ToList()
            };

            var data = new MoneyBackRequest
            {
                AccessToken = _accessToken,
                TokenData = new TokenData
                {
                    operationId = "createDocument",
                    version = 1,
                    parameters = new Parameters
                    {
                        DocType = "money_back",
                        data = refundData
                    }
                }
            };

            var request = BaseRequest<MoneyBackRequest>.Create(data);
            var result = TerminalHttpHelper.Post<BaseRequest<MoneyBackRequest>, MoneyBackResponse>(_ipAddress, request);

            if (!result.Success && IsTokenExpired(result))
            {
                _accessToken = null;
                var retryLogin = Login();
                if (!retryLogin.Success)
                    return TerminalResult.Fail("Yeni token əldə etmək uğursuz oldu");

                return await Refund(item);
            }

            if (!result.Success)
                return result;

            var response = result.GetData<MoneyBackResponse>();
            if (response.IsSuccess)
            {
                var refundId = await posRefundOperation.Add(new PosRefund
                {
                    OperationType = (int)Enums.OperationType.Refund,
                    PosSaleId = item.PosSaleId,
                    ReceiptNo = response.DocumentNumber,
                    LongFiscalId = response.LongId,
                    ShortFiscalId = response.ShortId,
                    BankRrn = string.IsNullOrWhiteSpace(item.BankRrn) ? response.Rrn : item.BankRrn,
                    OperationDate = DatetimeService.CurrentDateTime,
                    Cash = item.Cash,
                    Card = item.Card,
                    Total = item.Total,
                    IncomingSum = item.Total,
                    CustomerId = item.Customer?.Id,
                    Note = item.Note,
                    UserId = UserCacheService.User.Id,
                });

                if (refundId != -1)
                {
                    List<PosRefundItem> dataDetails = new List<PosRefundItem>();

                    dataDetails.AddRange(item.Items.Select(x => new PosRefundItem
                    {
                        PosRefundId = refundId,
                        PosSaleItemId = x.Id,
                        ProductId = x.ProductId,
                        Quantity = x.RefundQuantity,
                        SalePrice = x.SalePrice,
                        Discount = x.DiscountAmount
                    }));

                    await posRefundItemOperation.Add(dataDetails);
                }
                return TerminalResult.Ok("Geri qaytarma uğurla tamamlandı");
            }

            return TerminalResult.Fail("Geri qaytarma uğursuz oldu");
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
