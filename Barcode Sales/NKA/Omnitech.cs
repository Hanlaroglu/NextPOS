using Barcode_Sales.Forms;
using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Classes;
using Barcode_Sales.NKA.DTOs;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.XtraPrinting.Shape.Native;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Barcode_Sales.NKA.Sunmi;

namespace Barcode_Sales.NKA
{
    public static class Omnitech
    {
        static ISaleDataOperation _saleDataOperation = new SalesDataManager();
        static ISalesDataDetailOperation _salesDataDetailOperation = new SalesDataDetailManager();
        static IReturnPosOperation _returnPosOperation = new ReturnPosManager();
        static IReturnPosDetailOperation _returnPosDetailOperation = new ReturnPosDetailManager();
        static ITerminalIncomeAndExpenseOperation incomeAndExpenseOperation = new IncomeAndExpenseManager();
        static ICloseShiftOperation closeShiftOperation = new CloseShiftManager();
        static fPosSales _form = Application.OpenForms.OfType<fPosSales>().FirstOrDefault();
        static fPosRollbackProduct _rollbackForm = Application.OpenForms.OfType<fPosRollbackProduct>().FirstOrDefault();

        public static string Login(string IpAddress)
        {
            LoginRequest login = new LoginRequest();

            BaseRequest<LoginRequest> request = new BaseRequest<LoginRequest>
            {
                requestData = login,
            };

            string json = FormHelpers.ConvertClassToJson(request);

            var result = FormHelpers.PostRequestJson(IpAddress, json);

            if (result.IsSuccessful)
            {
                LoginResponse response = System.Text.Json.JsonSerializer.Deserialize<LoginResponse>(result.Content);
                if (response.message is "login success")
                {
                    return response.access_token;
                }
                else
                {
                    NotificationHelpers.Messages.ErrorMessage(_form, response.message);
                    return null;
                }
            }
            else
            {
                NotificationHelpers.Messages.ErrorMessage(_form, result.ErrorMessage);
                return null;
            }
        }

        private static void OpenShift(NkaDto.ShiftDto item)
        {
            item.AccessToken = Login(item.IpAddress);

            OpenShiftRequest shiftStatus = new OpenShiftRequest
            {
                access_token = item.AccessToken
            };

            BaseRequest<OpenShiftRequest> request = new BaseRequest<OpenShiftRequest>()
            {
                requestData = shiftStatus,
            };

            string json = FormHelpers.ConvertClassToJson(request);

            var response = FormHelpers.PostRequestJson(CommonData.terminal.IpAddress, json);
            if (response.IsSuccessful)
            {
                BaseResponse responseData = JsonConvert.DeserializeObject<BaseResponse>(response.Content);

                if (responseData.message == "Successful operation")
                {
                    NotificationHelpers.Messages.SuccessMessage(_form, "Növbə uğurla açıldı");
                }
                else
                {
                    NotificationHelpers.Messages.ErrorMessage(_form, responseData.message);
                }
            }
        }

        public static void GetShiftStatus(NkaDto.ShiftDto item)
        {
            item.AccessToken = Login(item.IpAddress);

            ShiftStatus shiftStatus = new ShiftStatus
            {
                access_token = item.AccessToken
            };

            BaseRequest<ShiftStatus> request = new BaseRequest<ShiftStatus>()
            {
                requestData = shiftStatus,
            };

            string json = FormHelpers.ConvertClassToJson(request);

            var response = FormHelpers.PostRequestJson(item.IpAddress, json);
            if (response.IsSuccessful)
            {
                ShiftResponse responseData = System.Text.Json.JsonSerializer.Deserialize<ShiftResponse>(response.Content);

                if (responseData.message == "Successful operation")
                {
                    if (responseData.shiftStatus)
                    {
                        //string open_time = responseData.shift_open_time.ToString("dd.MM.yyyy HH:mm:ss");
                        string open_time = responseData.shift_open_time;
                        NotificationHelpers.Messages.InfoMessage(_form, $"Növbə artıq açıqdır\n\nNövbənin açılma tarixi: {open_time}");
                    }
                    else
                    {
                        OpenShift(new NkaDto.ShiftDto
                        {
                            IpAddress = item.IpAddress,
                            AccessToken = item.AccessToken,
                        });
                    }
                }
                else
                {
                    NotificationHelpers.Messages.ErrorMessage(_form, responseData.message);
                }
            }
        }

        public static void XReport()
        {

        }

        public static bool CloseShift(NkaDto.ShiftDto item)
        {
            item.AccessToken = Login(item.IpAddress);

            CloseShifttRequest closeShiftt = new CloseShifttRequest
            {
                access_token = item.AccessToken
            };

            BaseRequest<CloseShifttRequest> request = new BaseRequest<CloseShifttRequest>()
            {
                requestData = closeShiftt,
            };

            string json = FormHelpers.ConvertClassToJson(request);

            var response = FormHelpers.PostRequestJson(item.IpAddress, json);
            if (response.IsSuccessful)
            {
                CloseShiftResponse responseData = System.Text.Json.JsonSerializer.Deserialize<CloseShiftResponse>(response.Content);

                if (responseData.message == "Successful operation")
                {
                    NotificationHelpers.Messages.SuccessMessage(_form, $"Günsonu (Z) hesabatı uğurla çıxarıldı");
                    CloseShiftReport closeShift = new CloseShiftReport
                    {
                        FiskalID = responseData.data.document_id,
                        JsonResponse = response.Content,
                        UserId = CommonData.CURRENT_USER.Id,
                        OpenShiftDate = responseData.data.shiftOpenAtUtc,
                        CloseShiftDate = responseData.data.createdAtUtc
                    };
                    closeShiftOperation.Add(closeShift);
                    return true;
                }
                else
                {
                    NotificationHelpers.Messages.ErrorMessage(_form, responseData.message, "Gün sonu hesabat xətası");
                    return false;
                }
            }
            else
            {
                NotificationHelpers.Messages.ErrorMessage(_form, response.ErrorMessage);
                return false;
            }
        }

        public static bool Deposit(NkaDto.DepositDto item)
        {
            throw new NotImplementedException();
        }

        public static bool Withdraw(NkaDto.DepositDto item)
        {
            throw new NotImplementedException();
        }

        public static bool Sale(SaleClasses.SaleData _data)
        {
            if (string.IsNullOrWhiteSpace(_data.AccessToken))
            {
                _data.AccessToken = Login(_data.IpAddress);
                if (string.IsNullOrWhiteSpace(_data.AccessToken))
                    return false;
            }

            List<SaleRequest.Item> items = new List<SaleRequest.Item>();
            foreach (var _item in _data.Items)
            {
                int taxType = ConvertTaxType(_item.TaxName);
                SaleRequest.Item item = new SaleRequest.Item
                {
                    itemName = _item.ProductName,
                    itemPrice = _item.SalePrice,
                    itemSum = _item.SalePrice * _item.Amount,
                    itemCode = _item.Barcode,
                    itemCodeType = 0,
                    discount = _item.Discount,
                    itemQuantity = _item.Amount,
                    itemQuantityType = _item.UnitId,
                    itemVatPercent = taxType,
                    itemMarginPrice = _item.PurchasePrice,
                    itemMarginSum = _item.PurchaseSum,
                };

                if (taxType != 18)
                {
                    item.itemMarginPrice = null;
                    item.itemMarginSum = null;
                }
                items.Add(item);
            }

            List<SaleRequest.VatAmount> vatAmounts = items.GroupBy(x => x.itemVatPercent)
                .Select(c => new SaleRequest.VatAmount
                {
                    vatPercent = c.Key,
                    vatSum = c.Sum(x => x.itemSum)
                }).ToList();

            SaleRequest.Data data = new SaleRequest.Data
            {
                sum = _data.Total,
                cashSum = _data.Cash,
                cashlessSum = _data.Card,
                incomingSum = _data.IncomingSum,
                cashier = _data.Cashier,
                items = items,
                vatAmounts = vatAmounts,
            };

            SaleRequest.Parameters parameters = new SaleRequest.Parameters
            {
                data = data,
            };

            SaleRequest.TokenData tokenData = new SaleRequest.TokenData
            {
                parameters = parameters
            };

            SaleRequest sale = new SaleRequest
            {
                access_token = _data.AccessToken,
                tokenData = tokenData
            };

            BaseRequest<SaleRequest> request = new BaseRequest<SaleRequest>
            {
                requestData = sale
            };

            string json = FormHelpers.ConvertClassToJson(request);

            var result = FormHelpers.PostRequestJson(_data.IpAddress, json);

            if (result.IsSuccessful)
            {
                SaleResponse response = JsonConvert.DeserializeObject<SaleResponse>(result.Content);
                if (response.message is "Successful operation")
                {
                    NotificationHelpers.Messages.SuccessMessage(_form, $"Satış uğurla tamamlandı");

                    int SaleId = _saleDataOperation.InsertSaleData(new SalesData
                    {
                        UserId = CommonData.CURRENT_USER.Id,
                        ReceiptNo = response.document_number.ToString(),
                        LongFiscalId = response.long_id,
                        ShortFiscalId = response.short_id,
                        SaleDate = DateTime.Now,
                        SaleDatetime = DateTime.Now,
                        Total = _data.Total,
                        Cash = _data.Cash,
                        Card = _data.Card,
                        IncomingSum = _data.IncomingSum,
                        CustomerId = _data.Customer?.Id,
                        Note = _data.Note,
                    });

                    if (SaleId != -1)
                    {
                        List<SalesDataDetail> dataDetails = new List<SalesDataDetail>();

                        dataDetails.AddRange(_data.Items.Select(x => new SalesDataDetail
                        {
                            ProductId = x.Id,
                            Quantity = x.Amount,
                            SalePrice = x.SalePrice,
                            Discount = x.Discount,
                            SaleDataId = SaleId,
                        }));
                        _salesDataDetailOperation.InsertRangeSalesDataDetail(dataDetails);
                    }
                    return true;
                }
                else
                {
                    NotificationHelpers.Messages.ErrorMessage(_form, response.message, "Uğursuz satış");
                    return false;
                }
            }
            else
            {
                NotificationHelpers.Messages.ErrorMessage(_form, result.ErrorMessage);
                return false;
            }
        }

        public static bool Rollback(RefundClassess.Data _data)
        {
            if (string.IsNullOrWhiteSpace(_data.AccessToken))
            {
                _data.AccessToken = Login(_data.IpAddress);
                if (string.IsNullOrWhiteSpace(_data.AccessToken))
                    return false;
            }

            RollbackRequest rollback = new RollbackRequest
            {
                AccessToken = _data.AccessToken,
                fiscalId = _data.LongFiskalId
            };

            BaseRequest<RollbackRequest> request = new BaseRequest<RollbackRequest>
            {
                requestData = rollback
            };

            if (_data.Cash > 0 && _data.Card is 0)
            {
                _data.Cash = _data.Total;
            }
            else if (_data.Cash is 0 && _data.Card > 0)
            {
                _data.Card = _data.Total;
            }
            else
            {
                _data.Cash = _data.Total;
            }

            string json = FormHelpers.ConvertClassToJson(request);

            var result = FormHelpers.PostRequestJson(_data.IpAddress, json);

            if (result != null)
            {
                RefundResponse response = JsonConvert.DeserializeObject<RefundResponse>(result.Content);
                if (response.message is "Successful operation" || response.code is 0)
                {
                    NotificationHelpers.Messages.SuccessMessage(_form, $"{response.document_number} №-li çek ləğv edildi");

                    int refundId = _returnPosOperation.InsertReturnData(new ReturnPos
                    {
                        SaleDataId = _data.SaleDataId,
                        LongFiscalId = response.long_id,
                        ShortFiscalId = response.short_id,
                        ReceiptNo = response.document_number.ToString(),
                        Note = _data.Note,
                        ReturnDate = DateTime.Now,
                        ReturnDatetime = DateTime.Now,
                        UserId = CommonData.CURRENT_USER.Id,
                        CustomerId = _data.Customer?.Id,
                        Cash = _data.Cash,
                        Card = _data.Card,
                        Total = _data.Total
                    });


                    if (refundId != -1)
                    {
                        List<ReturnPosDetail> dataDetails = new List<ReturnPosDetail>();

                        dataDetails.AddRange(_data.Items.Select(x => new ReturnPosDetail
                        {
                            ProductId = x.Id,
                            Quantity = x.Amount,
                            SalePrice = x.SalePrice,
                            Discount = x.Discount,
                            ReturnDataId = refundId,
                        }));
                        _returnPosDetailOperation.InsertRangeReturnDataDetail(dataDetails);
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    NotificationHelpers.Messages.ErrorMessage(_form, response.message);
                    return false;
                }
            }
            else
            {
                NotificationHelpers.Messages.ErrorMessage(_form, result.ErrorMessage);
                return false;
            }

           
        }

        public static bool Refund(RefundClassess.Data _data)
        {
            if (string.IsNullOrWhiteSpace(_data.AccessToken))
            {
                _data.AccessToken = Login(_data.IpAddress);
                if (string.IsNullOrWhiteSpace(_data.AccessToken))
                    return false;
            }

            List<RefundRequest.Item> items = new List<RefundRequest.Item>();
            foreach (var _item in _data.Items)
            {
                int taxType = ConvertTaxType(_item.TaxName);
                RefundRequest.Item item = new RefundRequest.Item
                {
                    itemName = _item.ProductName,
                    itemPrice = _item.SalePrice,
                    itemSum = _item.Total,
                    itemCode = _item.Barcode,
                    itemCodeType = 0,
                    discount = _item.Discount,
                    itemQuantity = _item.Amount,
                    itemQuantityType = _item.UnitId,
                    itemVatPercent = taxType,
                    itemMarginPrice = _item.PurchasePrice,
                    itemMarginSum = _item.PurchaseSum,
                };

                if (taxType != 18)
                {
                    item.itemMarginPrice = null;
                    item.itemMarginSum = null;
                }
                items.Add(item);
            }

            List<RefundRequest.VatAmount> vatAmounts = items.GroupBy(x => x.itemVatPercent)
                .Select(c => new RefundRequest.VatAmount
                {
                    vatPercent = c.Key,
                    vatSum = c.Sum(x => x.itemSum)
                }).ToList();

            RefundRequest.Data data = new RefundRequest.Data
            {
                sum = _data.Total,
                cashier = _data.Cashier,
                items = items,
                vatAmounts = vatAmounts,
                refund_document_number = _data.document_number,
                parentDocument = _data.LongFiskalId,
                refund_short_document_id = _data.ShortFiskalId,
            };

            if (_data.Cash > 0 && _data.Card is 0)
            {
                data.cashSum = _data.Total;
            }
            else if (_data.Cash is 0 && _data.Card > 0)
            {
                data.cashlessSum = _data.Total;
            }
            else
            {
                data.cashSum = _data.Total;
            }

            RefundRequest.Parameters parameters = new RefundRequest.Parameters
            {
                data = data,
            };

            RefundRequest.TokenData tokenData = new RefundRequest.TokenData
            {
                parameters = parameters
            };

            RefundRequest refund = new RefundRequest
            {
                access_token = _data.AccessToken,
                tokenData = tokenData
            };

            BaseRequest<RefundRequest> request = new BaseRequest<RefundRequest>
            {
                requestData = refund
            };

            string json = FormHelpers.ConvertClassToJson(request);

            var result = FormHelpers.PostRequestJson(_data.IpAddress, json);

            if (result != null)
            {
                RefundResponse response = JsonConvert.DeserializeObject<RefundResponse>(result.Content);
                if (response.message is "Successful operation" || response.code is 0)
                {
                    NotificationHelpers.Messages.SuccessMessage(_form, $"{response.document_number} №-li çek uğurla geri qaytarıldı");

                    int refundId = _returnPosOperation.InsertReturnData(new ReturnPos
                    {
                        SaleDataId = _data.SaleDataId,
                        LongFiscalId = response.long_id,
                        ShortFiscalId = response.short_id,
                        ReceiptNo = response.document_number.ToString(),
                        Note = _data.Note,
                        ReturnDate = DateTime.Now, //Udemydəki kimi et clasddan current alsın
                        ReturnDatetime = DateTime.Now,
                        UserId = CommonData.CURRENT_USER.Id,
                        CustomerId = _data.Customer?.Id,
                        Cash = data.cashSum,
                        Card = data.cashlessSum,
                        Total = data.sum
                    });


                    if (refundId != -1)
                    {
                        List<ReturnPosDetail> dataDetails = new List<ReturnPosDetail>();

                        dataDetails.AddRange(_data.Items.Select(x => new ReturnPosDetail
                        {
                            ProductId = x.Id,
                            Quantity = x.Amount,
                            SalePrice = x.SalePrice,
                            Discount = x.Discount,
                            ReturnDataId = refundId,
                        }));
                        _returnPosDetailOperation.InsertRangeReturnDataDetail(dataDetails);
                        return true;
                    }
                    else
                        return false;
                }
            }

            return false;
        }

        public static bool CreditSale()
        {
            throw new NotImplementedException();
        }

        public static bool CreditPay()
        {
            throw new NotImplementedException();
        }

        public static bool PrepaymentPay()
        {
            throw new NotImplementedException();
        }

        public static bool PrepaymentSale()
        {
            throw new NotImplementedException();
        }

        private static int ConvertTaxType(string taxName)
        {
            switch (taxName)
            {
                case "18% ƏDV":
                case "TİCARƏT ƏLAVƏSİ":
                    return 18;
                case "0% - ( ƏDV-DƏN AZAD )":
                    return 0;
                case "2% ƏDV":
                    return 2;
                case "8% ƏDV":
                    return 8;
                default:
                    return 18;
            }
        }

        #region [.. Request Classess..]

        private class BaseRequest<T> where T : class
        {
            public T requestData { get; set; }
        }

        private class CheckData
        {
            public int check_type { get; set; }
        }

        private class LoginRequest
        {
            public CheckData checkData { get; set; } = new CheckData { check_type = 40 };
            public string name { get; set; } = "SuperApi";
            public string password { get; set; } = "123";
        }

        private class ShiftStatus
        {
            public CheckData checkData { get; set; } = new CheckData { check_type = 14 };
            public string access_token { get; set; }
        }

        private class OpenShiftRequest
        {
            public CheckData checkData { get; set; } = new CheckData { check_type = 15 };
            public string access_token { get; set; }
        }

        private class CloseShifttRequest
        {
            public CheckData checkData { get; set; } = new CheckData { check_type = 13 };
            public string access_token { get; set; }
        }

        private class SaleRequest
        {
            public string access_token { get; set; }
            public string int_ref { get; set; } = "123456";
            public TokenData tokenData { get; set; }
            public CheckData checkData { get; set; } = new CheckData { check_type = 1 };
            public class Item
            {
                public string itemName { get; set; }
                public int itemCodeType { get; set; }
                public string itemCode { get; set; }
                public int itemQuantityType { get; set; }
                public double itemQuantity { get; set; }
                public double itemPrice { get; set; }
                public double itemSum { get; set; }
                public double itemVatPercent { get; set; }
                public double discount { get; set; }
                public double? itemMarginPrice { get; set; } = null;
                public double? itemMarginSum { get; set; } = null;
            }
            public class Data
            {
                public string cashier { get; set; }
                public string currency { get; set; } = "AZN";
                public List<Item> items { get; set; }
                public double sum { get; set; }
                public double cashSum { get; set; }
                public double cashlessSum { get; set; }
                public double prepaymentSum { get; set; }
                public double creditSum { get; set; }
                public double bonusSum { get; set; }
                public double incomingSum { get; set; }
                public List<VatAmount> vatAmounts { get; set; }
            }
            public class Parameters
            {
                public string doc_type { get; set; } = "sale";
                public Data data { get; set; }
            }
            public class TokenData
            {
                public Parameters parameters { get; set; }
                public string operationId { get; set; } = "createDocument";
                public int version { get; set; } = 1;
            }
            public class VatAmount
            {
                public double vatSum { get; set; }
                public double vatPercent { get; set; }
            }
        }

        private class WithdrawRequest
        {
            public CheckData checkData { get; set; } = new CheckData { check_type = 8 };
            public class Parameters
            {
                public Data data { get; set; }
            }
            public class Data
            {
                public double cashSum { get; set; }
            }
            public class TokenData
            {
                public Parameters parameters { get; set; }
            }
            public string access_token { get; set; }
        }

        private class RefundRequest
        {
            public string access_token { get; set; }
            public TokenData tokenData { get; set; }
            public CheckData checkData { get; set; } = new CheckData { check_type = 100 };
            public class Item
            {
                public string itemName { get; set; }
                public int itemCodeType { get; set; }
                public string itemCode { get; set; }
                public int itemQuantityType { get; set; }
                public double itemQuantity { get; set; }
                public double itemPrice { get; set; }
                public double itemSum { get; set; }
                public double itemVatPercent { get; set; }
                public double discount { get; set; }
                public double? itemMarginPrice { get; set; } = null;
                public double? itemMarginSum { get; set; } = null;
            }
            public class Data
            {
                public string cashier { get; set; }
                public string currency { get; set; } = "AZN";
                public List<Item> items { get; set; }
                public double sum { get; set; }
                public double cashSum { get; set; }
                public double cashlessSum { get; set; }
                public double prepaymentSum { get; set; }
                public string parentDocument { get; set; }
                public string refund_document_number { get; set; }
                public string refund_short_document_id { get; set; }
                public double creditSum { get; set; }
                public double bonusSum { get; set; }
                public List<VatAmount> vatAmounts { get; set; }
            }
            public class Parameters
            {
                public string doc_type { get; set; } = "money_back";
                public Data data { get; set; }
            }
            public class TokenData
            {
                public Parameters parameters { get; set; }
                public string operationId { get; set; } = "createDocument";
                public int version { get; set; } = 1;
            }
            public class VatAmount
            {
                public double vatSum { get; set; }
                public double vatPercent { get; set; }
            }
        }

        private class RollbackRequest
        {
            public string AccessToken { get; set; }
            public CheckData checkData { get; set; } = new CheckData { check_type = 10 };
            public string fiscalId { get; set; }
        }

        #endregion [.. Request Classess..]


        #region [.. Response Classess..]

        private class BaseResponse
        {
            public int code { get; set; }
            public string message { get; set; }
        }

        private class LoginResponse : BaseResponse
        {
            public string access_token { get; set; }
        }

        private class ShiftResponse : BaseResponse
        {
            public string desc { get; set; }
            public string serial { get; set; }
            public bool shiftStatus { get; set; }
            public string shift_open_time { get; set; }
        }

        private class CloseShiftResponse : BaseResponse
        {
            public Data data { get; set; }
            public class Data
            {
                public string document_id { get; set; }
                public DateTime createdAtUtc { get; set; }
                public DateTime shiftOpenAtUtc { get; set; }
            }
        }

        private class SaleResponse : BaseResponse
        {
            public int document_number { get; set; }
            public string long_id { get; set; }
            public int shift_document_number { get; set; }
            public string short_id { get; set; }
        }

        private class WithdrawResponse
        {

        }

        private class RefundResponse
        {
            public int code { get; set; }
            public int document_number { get; set; }
            public string long_id { get; set; }
            public string message { get; set; }
            public int shift_document_number { get; set; }
            public string short_id { get; set; }
        }
        #endregion [.. Response Classess..]
    }
}
