using Barcode_Sales.Barcode.Sales.Admin;
using Barcode_Sales.Forms;
using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Classes;
using Barcode_Sales.NKA.Base;
using Barcode_Sales.NKA.DTOs;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales.NKA
{
    public class Sunmi
    {
        static ITerminalOperation terminalOperation = new TerminalManager();
        static ISaleDataOperation _saleDataOperation = new SalesDataManager();
        static ISalesDataDetailOperation _salesDataDetailOperation = new SalesDataDetailManager();
        public static readonly string _IpAddress = terminalOperation.GetIpAddress();
        static fPosSales _form = Application.OpenForms.OfType<fPosSales>().FirstOrDefault();


        public string Login(NkaDto.LoginDto item)
        {
            throw new NotImplementedException();
        }

        public bool OpenShift(NkaDto.ShiftDto item)
        {
            OpenShiftRequest requestData = new OpenShiftRequest
            {
                cashierName = item.Cashier,
                data = new OpenShiftRequest.Data
                {
                    sum = 0
                }
            };

            SunmiBaseRequest<OpenShiftRequest> request = new SunmiBaseRequest<OpenShiftRequest>
            {
                data = requestData,
                operation = "openShift"
            };

            string json = FormHelpers.ConvertClassToJson(request);

            var response = FormHelpers.PostRequestJson(_IpAddress, json);
            if (response.IsSuccessful)
            {
                OpenShiftResponse responseData = System.Text.Json.JsonSerializer.Deserialize<OpenShiftResponse>(response.Content);

                if ($"{responseData.message}" == "Success operation" || $"{responseData.message}" == "Successful operation")
                {
                    NoticationHelpers.Messages.SuccessMessage(_form, $"Növbə uğurla açıldı");
                    return true;
                }
                else if (responseData.message is "Növbə artıq açıqdır")
                {
                    NoticationHelpers.Messages.InfoMessage(_form, responseData.message);
                    return false;
                }
                else
                {
                    NoticationHelpers.Messages.ErrorMessage(_form, responseData.message);
                    return false;
                }
            }
            else
            {
                NoticationHelpers.Messages.ErrorMessage(_form, response.ErrorMessage);
                return false;
            }
        }

        public void GetShiftStatus(NkaDto.ShiftDto item)
        {
            var request = new SunmiBaseRequest<object>
            {
                operation = "getShiftStatus"
            };

            string json = FormHelpers.ConvertClassToJson(request);

            var response = FormHelpers.PostRequestJson(_IpAddress, json);
            if (response.IsSuccessful)
            {
                ShiftStatusResponse responseData = System.Text.Json.JsonSerializer.Deserialize<ShiftStatusResponse>(response.Content);

                if ($"{responseData.message}" == "Success operation" || $"{responseData.message}" == "Successful operation")
                {
                    if (responseData.data.shift_open)
                    {
                        string open_time = responseData.data.shift_open_time.ToString("dd.MM.yyyy HH:mm:ss");
                        NoticationHelpers.Messages.InfoMessage(_form, $"Növbə artıq açıqdır\n\nNövbənin açılma tarixi: {open_time}");
                    }
                    else
                    {
                        OpenShift(new NkaDto.ShiftDto
                        {
                            IpAddress = item.IpAddress,
                            Cashier = item.Cashier
                        });
                    }
                }
                else
                {
                    NoticationHelpers.Messages.ErrorMessage(_form, responseData.message);
                }
            }
        }

        public bool CloseShift(NkaDto.ShiftDto item)
        {
            CloseShiftRequest data = new CloseShiftRequest
            {
                data = new CloseShiftRequest.Data
                {
                    documentUUID = Guid.NewGuid().ToString(),
                    cashierName = item.Cashier,
                }
            };

            SunmiBaseRequest<CloseShiftRequest> request = new SunmiBaseRequest<CloseShiftRequest>
            {
                data = data,
                operation = "closeShift"
            };

            string json = FormHelpers.ConvertClassToJson(request);

            var response = FormHelpers.PostRequestJson(_IpAddress, json);

            if (response.IsSuccessful)
            {
                SunmiBaseResponse responseData = System.Text.Json.JsonSerializer.Deserialize<SunmiBaseResponse>(response.Content);
                if ($"{responseData.message}" == "Success operation" || $"{responseData.message}" == "Successful operation")
                {
                    NoticationHelpers.Messages.SuccessMessage(_form, $"Günsonu (Z) hesabatı uğurla çıxarıldı");
                    return true;
                }
                else
                {
                    NoticationHelpers.Messages.ErrorMessage(_form, responseData.message, "Gün sonu hesabatı");
                    return false;
                }
            }
            else
            {
                NoticationHelpers.Messages.ErrorMessage(_form, response.ErrorMessage);
                return false;
            }
        }

        public static bool Deposit(NkaDto.DepositDto item)
        {
            DepositRequest depositRequest = new DepositRequest
            {
                cashierName = item.Cashier,
                sum = item.Amount
            };

            SunmiBaseRequest<DepositRequest> request = new NKA.SunmiBaseRequest<DepositRequest>
            {
                data = depositRequest,
                operation = "deposit"
            };

            string json = FormHelpers.ConvertClassToJson(request);

            var response = FormHelpers.PostRequestJson(_IpAddress, json);

            if (response.IsSuccessful)
            {
                DepositResponse responseData = System.Text.Json.JsonSerializer.Deserialize<DepositResponse>(response.Content);
                if (responseData.message == "Success operation" || responseData.message == "Successful operation" || responseData.message == "Successoperation")
                {
                    NoticationHelpers.Messages.SuccessMessage(_form, $"Kassaya {item.Amount.ToString("C2")} mədaxil edildi");
                    return true;
                }
                else
                {
                    NoticationHelpers.Messages.ErrorMessage(_form, responseData.message);
                    return false;
                }
            }
            else
            {
                NoticationHelpers.Messages.ErrorMessage(_form, response.ErrorMessage);
                return false;
            }
        }

        public static bool Withdraw()
        {
            throw new NotImplementedException();
        }

        public static bool Sale(SaleClasses.SaleData data)
        {
            List<SaleRequest.Item> items = new List<SaleRequest.Item>();
            foreach (var _item in data.Items)
            {
                SaleRequest.Item item = new SaleRequest.Item
                {
                    name = _item.ProductName,
                    salePrice = _item.SalePrice,
                    code = _item.Barcode,
                    codeType = 1,
                    discountAmount = _item.Discount,
                    quantity = _item.Amount,
                    quantityType = _item.QuantityType,
                    vatType = _item.TaxType
                };
                items.Add(item);
            }



            SaleRequest saledata = new SaleRequest()
            {
                cashierName = data.Cashier,
                cashPayment = data.IncomingSum,
                cardPayment = data.Card,
                depositPayment = data.Deposit,
                creditPayment = data.Credit,
                bonusPayment = data.Bonus,
                items = items,
                clientName = data.Customer?.NameSurname,
                note = string.IsNullOrWhiteSpace(data.Note) ? null : data.Note,
                rrn = data.RRN,
            };

            SunmiBaseRequest<SaleRequest> request = new SunmiBaseRequest<SaleRequest>
            {
                data = saledata,
                operation = "sale"
            };

            string json = FormHelpers.ConvertClassToJson(request);

            var response = FormHelpers.PostRequestJson(_IpAddress, json);

            if (response.IsSuccessful)
            {
                SaleResponse responseData = System.Text.Json.JsonSerializer.Deserialize<SaleResponse>(response.Content);
                if ($"{responseData.message}" == "Success operation" || $"{responseData.message}" == "Successful operation")
                {
                    NoticationHelpers.Messages.SuccessMessage(_form, $"Satış uğurla tamamlandı");

                    int SaleId = _saleDataOperation.InsertSaleData(new SalesData
                    {
                        UserId = Properties.Settings.Default.UserID,
                        ReceiptNo = responseData.data.number,
                        LongFiscalId = responseData.data.document_id,
                        ShortFiscalId = responseData.data.short_document_id,
                        Rrn = string.IsNullOrWhiteSpace(data.RRN) ? responseData.data.rrn : data.RRN,
                        SaleDate = DateTime.Now,
                        SaleDatetime = DateTime.Now,
                        Total = data.Total,
                        Cash = data.Cash,
                        Card = data.Card,
                        IncomingSum = data.IncomingSum,
                        CustomerId = data.Customer?.Id,
                        Note = data.Note,
                    });

                    if (SaleId != -1)
                    {
                        List<SalesDataDetail> dataDetails = new List<SalesDataDetail>();

                        dataDetails.AddRange(data.Items.Select(x => new SalesDataDetail
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
                    NoticationHelpers.Messages.ErrorMessage(_form, responseData.message, "Uğursuz satış");
                    return false;
                }
            }
            else
            {
                NoticationHelpers.Messages.ErrorMessage(_form, response.ErrorMessage);
                return false;
            }
        }

        public bool Rollback()
        {
            throw new NotImplementedException();
        }

        public bool Refund()
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


    #region [.. Request Classess..]

    public class SunmiBaseRequest<T> where T : class
    {
        public T data { get; set; } = null;
        public string operation { get; set; }
        public string username { get; set; } = "username";
        public string password { get; set; } = "password";
    }

    public class OpenShiftRequest
    {
        public class Data
        {
            public double sum { get; set; } = 0;
        }
        public Data data { get; set; }
        public string cashierName { get; set; }
    }

    public class CloseShiftRequest
    {
        public class Data
        {
            public string documentUUID { get; set; }
            public string cashierName { get; set; }
        }
        public Data data { get; set; }
    }

    public class DepositRequest
    {
        public string documentUUID { get; set; } = Guid.NewGuid().ToString();
        public double sum { get; set; }
        public string cashierName { get; set; }
        public string currency { get; set; } = "AZN";
    }

    public class SaleRequest
    {
        public string documentUUID { get; set; } = Guid.NewGuid().ToString();
        public double cashPayment { get; set; }
        public double creditPayment { get; set; }
        public double depositPayment { get; set; }
        public double cardPayment { get; set; }
        public double bonusPayment { get; set; }
        public List<Item> items { get; set; }
        public string clientName { get; set; }
        public double clientTotalBonus { get; set; }
        public double clientEarnedBonus { get; set; }
        public string clientBonusCardNumber { get; set; }
        public string cashierName { get; set; }
        public string note { get; set; } = null;
        public string rrn { get; set; } = null;
        public string currency { get; set; } = "AZN";
        public class Item
        {
            public string name { get; set; }
            public string code { get; set; }
            public double quantity { get; set; }
            public double salePrice { get; set; }
            public double purchasePrice { get; set; }
            public int codeType { get; set; }
            public int quantityType { get; set; }
            public int vatType { get; set; }
            public string itemUuid { get; set; }
            public double discountAmount { get; set; }
            public List<string> markingCodes { get; set; }
        }
    }


    #endregion [.. Request Classess..]


    #region [.. Response Classess..]

    public abstract class SunmiBaseResponse
    {
        public string code { get; set; }
        public string message { get; set; }
    }

    public class LoginResponse : SunmiBaseResponse
    {
        public class Data
        {
            public string access_token { get; set; }
        }

        public Data data { get; set; }
    }

    public class LogoutResponse : SunmiBaseResponse
    {

    }

    public class OpenShiftResponse : SunmiBaseResponse
    {

    }

    public class ShiftStatusResponse : SunmiBaseResponse
    {
        public class Data
        {
            public bool shift_open { get; set; }
            public DateTime shift_open_time { get; set; }
        }
        public Data data { get; set; }
    }

    public class DepositResponse : SunmiBaseResponse
    {
        public Data data { get; set; }
        public class Data
        {
            public string document_id { get; set; }
            public string document_number { get; set; }
            public string shift_document_number { get; set; }
            public string short_document_id { get; set; }
            //public double totalSum { get; set; }
        }
    }

    public class SaleResponse : SunmiBaseResponse
    {
        public Data data { get; set; }
        public class Data
        {
            public string approval_code { get; set; }
            public string document_id { get; set; }
            public int document_number { get; set; }
            public string number { get; set; }
            public string rrn { get; set; }
            public int shift_document_number { get; set; }
            public string short_document_id { get; set; }
            public double totalSum { get; set; }
            public string transaction_id { get; set; }
            public string transaction_number { get; set; }
        }
    }

    #endregion [.. Response Classess..]
}
