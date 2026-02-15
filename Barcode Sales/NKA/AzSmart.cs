using Barcode_Sales.Forms;
using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Classes;
using Barcode_Sales.NKA.DTOs;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Barcode_Sales.Helpers.Classes.RefundClassess;
using static Barcode_Sales.Helpers.Classes.SaleClasses;
using static Barcode_Sales.NKA.Sunmi;

namespace Barcode_Sales.NKA
{
    public class AzSmart
    {
        private static readonly RestClient _restClient = new RestClient();
        static IPosSaleOperation posSaleOperation = new PosSaleManager();
        static IPosSaleItemOperation posSaleItemOperation = new PosSaleItemManager();
        static ISaleDataOperation _saleDataOperation = new SalesDataManager();
        static ISalesDataDetailOperation _salesDataDetailOperation = new SalesDataDetailManager();
        static IReturnPosOperation _returnPosOperation = new ReturnPosManager();
        static IReturnPosDetailOperation _returnPosDetailOperation = new ReturnPosDetailManager();
        static ITerminalIncomeAndExpenseOperation incomeAndExpenseOperation = new IncomeAndExpenseManager();
        static ICloseShiftOperation closeShiftOperation = new CloseShiftManager();
        static fPosSales _form = Application.OpenForms.OfType<fPosSales>().FirstOrDefault();
        static fPosRollbackProduct _rollbackForm = Application.OpenForms.OfType<fPosRollbackProduct>().FirstOrDefault();

        private static RestResponse RequestPOST(string ipAddress, string json)
        {
            string data = GetJsonToBase64Encode(json, CommonData.terminal.MerchantId);

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (string.IsNullOrWhiteSpace(ipAddress))
                {
                    XtraMessageBox.Show("Kassa ip adresi daxil edilməmiştir", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                RestRequest request = new RestRequest(ipAddress, Method.Post);
                request.AddParameter("text/plain", data, ParameterType.RequestBody);
                request.AddHeader("Content-Type", "application/json;charset=utf-8");
                request.AddStringBody(json, DataFormat.Json);
                RestResponse response = _restClient.Execute(request);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
            finally { Cursor.Current = Cursors.Default; }
        }

        public static void GetShiftStatus(NkaDto.ShiftDto item)
        {
            var root = new
            {
                employeeName = item.Cashier,
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(root, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var response = RequestPOST($"{item.IpAddress}/check_shift", json);
            if (response.IsSuccessful)
            {
                ResponseCheckShift responseData = System.Text.Json.JsonSerializer.Deserialize<ResponseCheckShift>(response.Content);
                if (responseData.isShiftOpen is "true")
                {
                    string open_time = Convert.ToDateTime(responseData.shiftOpenAt).ToString("dd.MM.yyyy HH:mm:ss");
                    NotificationHelpers.Messages.InfoMessage(_form, $"Növbənin açılma tarixi: {open_time}", "Növbə artıq açıqdır");
                }
                else if (responseData.isShiftOpen is "false") { OpenShift(item); }
                else
                    NotificationHelpers.Messages.ErrorMessage(_form, responseData.message);
            }
            else
                NotificationHelpers.Messages.ErrorMessage(_form, response.ErrorMessage);
        }

        private static void OpenShift(NkaDto.ShiftDto item)
        {
            var root = new
            {
                employeeName = item.Cashier,
            };

            string json = FormHelpers.ConvertClassToJson(root);


            var response = RequestPOST($"{item.IpAddress}/open_shift", json);
            if (response.IsSuccessful)
            {
                ResponseOpenShift responseData = System.Text.Json.JsonSerializer.Deserialize<ResponseOpenShift>(response.Content);
                if (responseData.status is "success")
                {
                    NotificationHelpers.Messages.SuccessMessage(_form, "Növbə uğurla açıldı");
                }
                else
                {
                    NotificationHelpers.Messages.ErrorMessage(_form, responseData.message);
                }
            }

        }

        public static bool CloseShift(NkaDto.ShiftDto item)
        {
            var root = new
            {
                employeeName = item.Cashier
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(root, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var response = RequestPOST($"{item.IpAddress}/close_shift", json);
            if (response.IsSuccessful)
            {
                ResponseCloseShift responseData = System.Text.Json.JsonSerializer.Deserialize<ResponseCloseShift>(response.Content);
                if (responseData?.status is "success")
                {
                    NotificationHelpers.Messages.SuccessMessage(_form, $"Günsonu (Z) hesabatı uğurla çıxarıldı");
                    CloseShiftReport closeShift = new CloseShiftReport
                    {
                        UserId = CommonData.CURRENT_USER.Id,
                        JsonResponse = response.Content,
                        FiskalID = responseData.document_id,
                        OpenShiftDate = Convert.ToDateTime(responseData.shiftOpenAt),
                        CloseShiftDate = Convert.ToDateTime(responseData.shiftCloseAt)
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
            NotificationHelpers.Messages.ErrorMessage(_form, response.ErrorMessage);
            return false;
        }

        public static async bool Sale(SaleClasses.SaleData _data)
        {
            List<RequestSale.Item> items = new List<RequestSale.Item>();
            foreach (var _item in _data.Items)
            {

                int? purchasePrice = Convert.ToInt32(_item.PurchasePrice * 100);
                int? purchasePriceSum = Convert.ToInt32(_item.PurchasePrice * _item.Amount * 100);

                if (_item.TaxId != 2)
                {
                    purchasePriceSum = null;
                    purchasePrice = null;
                }

                var taxes = new List<RequestSale.itemTaxes>
                {
                    new RequestSale.itemTaxes
                    {
                        //fullName = _item.TaxName,
                        taxName = _item.TaxName,
                        taxPrc = GetTaxPrc(_item.TaxId),
                        calcType = 1
                    }
                };

                RequestSale.Item item = new RequestSale.Item
                {
                    itemName = _item.ProductName,
                    itemBarcode = _item.Barcode,
                    itemQty = Convert.ToInt32(_item.Amount * 1000),
                    itemAmount = Convert.ToInt32(_item.SalePrice * _item.Amount * 100),
                    itemMarginPrice = purchasePrice,
                    itemMarginSum = purchasePriceSum,
                    itemTaxes = taxes
                };
                items.Add(item);
            }

            int cash = Convert.ToInt32(_data.IncomingSum * 100);
            int card = Convert.ToInt32(_data.Card * 100);
            int total = Convert.ToInt32(_data.Total * 100);

            RequestSale.Payments payments = new RequestSale.Payments
            {
                cashAmount = cash,
                cashlessAmount = card,
                rrn = string.IsNullOrWhiteSpace(_data.RRN) ? null : _data.RRN,
            };

            RequestSale.Root root = new RequestSale.Root
            {
                employeeName = _data.Cashier,
                items = items,
                payments = payments,
                amount = total,
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(root, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });


            var response = RequestPOST($"{_data.IpAddress}/sale", json);
            if (response != null)
            {
                ResponseSale responseData = System.Text.Json.JsonSerializer.Deserialize<ResponseSale>(response.Content);
                if (responseData.status is "success")
                {
                    NotificationHelpers.Messages.SuccessMessage(_form, $"Satış uğurla tamamlandı");

                    int SaleId = await posSaleOperation.Add(new PosSale
                    {
                        UserId = CommonData.CURRENT_USER.Id,
                        ReceiptNo = responseData.fiscalNum,
                        LongFiscalId = responseData.fiscalID,
                        ShortFiscalId = responseData.fiscalID.Substring(0, 12) ?? null,
                        SaleDate = DateTime.Now,
                        SaleDatetime = DateTime.Now,
                        Total = _data.Total,
                        Cash = _data.Cash,
                        Card = _data.Card,
                        IncomingSum = _data.IncomingSum,
                        CustomerId = _data.Customer?.Id ?? null,
                        Note = _data.Note ?? null,
                    });

                    if (SaleId != -1)
                    {
                        List<PosSaleItem> dataDetails = new List<PosSaleItem>();

                        dataDetails.AddRange(_data.Items.Select(x => new PosSaleItem
                        {
                            ProductId = x.Id,
                            Quantity = x.Amount,
                            SalePrice = x.SalePrice,
                            Discount = x.Discount,
                            PosSaleId = SaleId,
                        }));

                        if (await posSaleItemOperation.Add(dataDetails))
                            return true;
                    }
                    return false;
                }
                else
                {
                    NotificationHelpers.Messages.ErrorMessage(_form, responseData.message, "Uğursuz satış");
                    return false;
                }
            }
            NotificationHelpers.Messages.ErrorMessage(_form, response.ErrorMessage);
            return false;
        }

        public static bool Refund(RefundClassess.Data _data)
        {
            List<RequestRefund.Item> items = new List<RequestRefund.Item>();
            foreach (var _item in _data.Items)
            {
                int? purchasePrice = Convert.ToInt32(_item.PurchasePrice * 100);
                int? purchasePriceSum = Convert.ToInt32(_item.PurchasePrice * _item.Amount * 100);

                if (_item.TaxId != 2)
                {
                    purchasePriceSum = null;
                    purchasePrice = null;
                }

                var taxes = new List<RequestRefund.itemTaxes>
                {
                    new RequestRefund.itemTaxes
                    {
                        //fullName = _item.TaxName,
                        taxName = _item.TaxName,
                        taxPrc = GetTaxPrc(_item.TaxId),
                        calcType = 1
                    }
                };

                RequestRefund.Item item = new RequestRefund.Item
                {
                    itemName = _item.ProductName,
                    itemBarcode = _item.Barcode,
                    itemQty = Convert.ToInt32(_item.Amount * 1000),
                    itemAmount = Convert.ToInt32(_item.SalePrice * _item.Amount * 100),
                    itemMarginPrice = purchasePrice,
                    itemMarginSum = purchasePriceSum,
                    itemTaxes = taxes
                };
                items.Add(item);
            }

            int cash = Convert.ToInt32(_data.Cash * 100);
            int card = Convert.ToInt32(_data.Card * 100);
            int total = Convert.ToInt32(_data.Total * 100);

            RequestRefund.Payments payments = new RequestRefund.Payments
            {
                cashAmount = cash,
                cashlessAmount = card,
                rrn = string.IsNullOrWhiteSpace(_data.RRN) ? null : _data.RRN,
            };

            RequestRefund.RootRefund root = new RequestRefund.RootRefund
            {
                employeeName = _data.Cashier,
                items = items,
                payments = payments,
                amount = total,
                parentDocID = _data.LongFiskalId,
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(root, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });


            var result = RequestPOST($"{_data.IpAddress}/refund", json);
            if (result != null)
            {
                ResponseRefund response = System.Text.Json.JsonSerializer.Deserialize<ResponseRefund>(result.Content);
                if (response.status is "success")
                {
                    NotificationHelpers.Messages.SuccessMessage(_form, $"{response.fiscalNum} №-li çek uğurla geri qaytarıldı");


                    int refundId = _returnPosOperation.InsertReturnData(new ReturnPos
                    {
                        SaleDataId = _data.SaleDataId,
                        LongFiscalId = response.fiscalID,
                        ShortFiscalId = response.fiscalID.Substring(0, 12),
                        ReceiptNo = response.fiscalNum.ToString(),
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
                    return true;
                }
                else
                {
                    NotificationHelpers.Messages.ErrorMessage(_form, response.message, "Uğursuz satış");
                    return false;
                }
            }
            NotificationHelpers.Messages.ErrorMessage(_form, result.ErrorMessage);
            return false;
        }






        private static int GetTaxPrc(int taxId)
        {
            switch (taxId)
            {
                case 1:
                case 2:
                    return 1800;
                case 3:
                    return 0;
                case 4:
                    return 200;
                case 5:
                    return 800;
                default:
                    return 1800;
            }
        }

        private static string GetBase64Encode(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            string base64Data = System.Convert.ToBase64String(bytes);
            return base64Data;
        }

        private static string GetSha1Encode(string input)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha1.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                return hash.ToLower();
            }
        }

        private static string GetJsonToBase64Encode(string json, string merchantId)
        {
            string base64Data = GetBase64Encode(json);
            string sha1Hash = GetSha1Encode(base64Data + merchantId);
            string base64Sign = GetBase64Encode(sha1Hash);
            return $"data={base64Data.Replace("=", "%3D")}&sign={base64Sign.Replace("=", "%3D")}";
        }





        #region Request Classess

        private class RequestSale
        {
            public class ExtraPayment
            {
                public string code { get; set; }
                public int amount { get; set; }
                public string trxParams { get; set; }
            }

            public class Item
            {
                public string itemId { get; set; }
                public string itemCodeType { get; set; } = null;
                public string itemName { get; set; }
                public int? itemAttr { get; set; } = null;
                public string itemQRCode { get; set; } = null;
                public string itemCode { get; set; } = null;
                public string itemUnitCode { get; set; } = null;
                public string itemUnit { get; set; } = null;
                public string itemBarcode { get; set; } = null;
                public int itemQty { get; set; }
                public int itemAmount { get; set; }
                public int discount { get; set; }
                public int? discountPrc { get; set; } = null;
                public string extraData { get; set; } = null;
                public string textToPrint { get; set; } = null;
                public List<itemTaxes> itemTaxes { get; set; }
                public int? itemMarginSum { get; set; } = null;
                public int? itemMarginPrice { get; set; } = null;
            }

            public class itemTaxes
            {
                public string taxName { get; set; }
                public string fullName { get; set; }
                public int taxPrc { get; set; }
                public int? taxCode { get; set; } = null;
                public int calcType { get; set; } = 1;
            }

            public class Payments
            {
                public int cashAmount { get; set; }
                public int cashlessAmount { get; set; }
                public int creditAmount { get; set; }
                public int bonusesAmount { get; set; }
                public int prepaymentAmount { get; set; }
                public int prepaymentCashlessAmount { get; set; }
                public int installmentAmount { get; set; }
                public int invoiceAmount { get; set; }
                public string rrn { get; set; } = null;
                public string cardNumber { get; set; } = null;
                public string bankName { get; set; } = null;
            }

            public class Root
            {
                public string documentID { get; set; } = null;
                public int? documentExtID { get; set; } = null;
                public string docTime { get; set; } = null;
                public string docNumber { get; set; }
                public string wsName { get; set; } = null;
                public string departmentName { get; set; } = null;
                public string departmentCode { get; set; } = null;
                public string employeeName { get; set; }
                public int amount { get; set; }
                public string currency { get; set; } = "AZN";
                public List<Item> items { get; set; }
                public Payments payments { get; set; }
                public string fiscalID { get; set; } = null;
                public string printFooter { get; set; } = null;
                public string creditContract { get; set; } = null;
                public string prepayDocID { get; set; } = null;
                public string prepayDocNum { get; set; } = null;
                public string clientPhone { get; set; } = null;
                public string clientName { get; set; } = null;
                public int? tips { get; set; } = null;
                public int? cashback { get; set; } = null;
                public bool? skipReceiptPrint { get; set; } = null;
            }
        }

        private class RequestRefund : RequestSale
        {
            public class RootRefund : Root
            {
                public string parentDocID { get; set; } = null;
            }
        }

        #endregion Request Classess


        #region Response Classess

        public abstract class BaseResponse
        {
            public string status { get; set; }
            public int code { get; set; }
            public string message { get; set; }
        }

        private class ResponseCheckShift : BaseResponse
        {
            public string isShiftOpen { get; set; }
            public string shiftOpenAt { get; set; }
        }

        private class ResponseOpenShift : BaseResponse
        {
            public int fiscalID { get; set; }
            public int shiftID { get; set; }
            public string shiftOpenAt { get; set; }
        }

        private class ResponseCloseShift : BaseResponse
        {
            public string document_id { get; set; }
            public string fiscalID { get; set; }
            public string shiftCloseAt { get; set; }
            public string shiftOpenAt { get; set; }
        }

        private class ResponseSale : BaseResponse
        {
            public string auth { get; set; }
            public string card_num { get; set; }
            public string checkNum { get; set; }
            public int docStatus { get; set; }
            public int documentExtID { get; set; }
            public int documentID { get; set; }
            public string fiscalID { get; set; }
            public string fiscalNum { get; set; }
            public string preview_data { get; set; }
            public int printError { get; set; }
            public string printTime { get; set; }
            public string rrn { get; set; }
            public int shiftOrdersCnt { get; set; }
            public List<TotalPayment> totalPayments { get; set; }
            public class TotalPayment
            {
                public int amount { get; set; }
                public string auth { get; set; }
                public string card_num { get; set; }
                public int change { get; set; }
                public string checkNum { get; set; }
                public string extraParams { get; set; }
                public int id { get; set; }
                public string name { get; set; }
                public string notes { get; set; }
                public string rrn { get; set; }
                public string type { get; set; }
            }
        }

        private class ResponseRefund : BaseResponse
        {
            public string fiscalID { get; set; }
            public string fiscalNum { get; set; }
            public string printTime { get; set; }
            public int shiftOrdersCnt { get; set; }
            public List<TotalPayment> totalPayments { get; set; }
            public class TotalPayment
            {
                public int amount { get; set; }
                public string auth { get; set; }
                public string card_num { get; set; }
                public int change { get; set; }
                public string checkNum { get; set; }
                public string extraParams { get; set; }
                public int id { get; set; }
                public string name { get; set; }
                public string notes { get; set; }
                public string rrn { get; set; }
                public string type { get; set; }
            }
        }
        #endregion Response Classess
    }
}
