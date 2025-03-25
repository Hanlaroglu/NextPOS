using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Microsoft.Win32;
using Newtonsoft.Json;
using RestSharp;
using System;
using static System.Drawing.Brushes;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Windows.Media;
using DevExpress.XtraEditors;
using System.Xml.Linq;

namespace Barcode_Sales.Forms
{
    public partial class fNBAPrint : DevExpress.XtraEditors.XtraForm
    {
        ITerminalOperation terminalOperation = new TerminalManager();

        private readonly string IpAddress;
        private string accessToken;

        public class Data
        {
            public string access_token { get; set; }
            public string company_tax_number { get; set; }
            public string company_name { get; set; }
            public string object_tax_number { get; set; }
            public string object_name { get; set; }
            public string object_address { get; set; }
            public string cashbox_tax_number { get; set; }
            public string cashbox_factory_number { get; set; }
            public string firmware_version { get; set; }
            public string cashregister_factory_number { get; set; }
            public string cashregister_model { get; set; }
            public string qr_code_url { get; set; }
            public DateTime not_before { get; set; }
            public DateTime not_after { get; set; }
            public string state { get; set; }
            public DateTime last_online_time { get; set; }
            public object oldest_document_time { get; set; }
            public int last_doc_number { get; set; }
            public string production_uuid { get; set; }
        }

        public class NbaResponse
        {
            public Data data { get; set; }
            public int code { get; set; }
            public string message { get; set; }
        }

        public fNBAPrint()
        {
            InitializeComponent();
            //IpAddress = terminalOperation.GetIpAddress();
            IpAddress = "";
            CommonData.RegeditControl();
        }

        public void PrintDeposit(object sender, PrintPageEventArgs e)
        {
            Font calibriSize8 = new Font("Calibri", 10, FontStyle.Regular);
            Font calibriSize8Bold = new Font("Calibri", 10, FontStyle.Bold);


            float totalWidth = 1000;
            float fontWidth = e.Graphics.MeasureString("*", calibriSize8Bold).Width;

            int starCount = (int)(totalWidth / fontWidth);

            string stars = new string('*', starCount);
            string line = new string('-', starCount);



            string header = $"TS Adı: {CommonData.TsName}\nTS Ünvanı: {CommonData.Address}\n\nVÖ Adı:{CommonData.CompanyName}\nVÖEN:{CommonData.Voen}\nObyekt kodu: {CommonData.VoenAndCode}";


            e.Graphics.DrawString(header,
                                 calibriSize8,
                                 System.Drawing.Brushes.Black,
                                 new RectangleF(35, 5F, 225F, 150F),
                                 new StringFormat
                                 {
                                     LineAlignment = StringAlignment.Center,
                                     Alignment = StringAlignment.Center
                                 });

            e.Graphics.DrawString("Mədaxil çeki",
                                calibriSize8Bold,
                                System.Drawing.Brushes.Black,
                                new RectangleF(35, 150F, 225F, 20),
                                new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });

            e.Graphics.DrawString($"Çek nömrəsi № {1}",
                    calibriSize8,
                    System.Drawing.Brushes.Black,
                    new RectangleF(35, 180F, 225F, 20),
                    new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });

            e.Graphics.DrawString("Kassir: Həsən Hüseynli Xanlar oğlu",
                   calibriSize8,
                   System.Drawing.Brushes.Black,
                   new RectangleF(3, 220, 150, 30),
                   new StringFormat
                   {
                       LineAlignment = StringAlignment.Center,
                       Alignment = StringAlignment.Near
                   });


            string datetime = $@"Tarix: {DateTime.Now.ToString("dd.MM.yyyy")}
Vaxt:            {DateTime.Now.ToString("HH:mm")}";

            e.Graphics.DrawString(datetime,
                  calibriSize8,
                  System.Drawing.Brushes.Black,
                  new RectangleF(75, 220, 210, 30),
                  new StringFormat
                  {
                      LineAlignment = StringAlignment.Center,
                      Alignment = StringAlignment.Far
                  });

           

            e.Graphics.DrawString(stars,
                calibriSize8,
                System.Drawing.Brushes.Black,
                new RectangleF(3, 260, 300, 10),
                new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                });


            e.Graphics.DrawString("Mədaxil məbləği:",
                  calibriSize8,
                  System.Drawing.Brushes.Black,
                  new RectangleF(3, 275, 200, 30),
                  new StringFormat
                  {
                      LineAlignment = StringAlignment.Center,
                      Alignment = StringAlignment.Near
                  });


            e.Graphics.DrawString("1517.80",
                  calibriSize8,
                  System.Drawing.Brushes.Black,
                  new RectangleF(90, 275, 190, 30),
                  new StringFormat
                  {
                      LineAlignment = StringAlignment.Center,
                      Alignment = StringAlignment.Far
                  });


            e.Graphics.DrawString(line,
                calibriSize8Bold,
                System.Drawing.Brushes.Black,
                new RectangleF(3, 305, 300, 10),
                new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                });


            e.Graphics.DrawString("YEKUN MƏBLƏĞ",
                calibriSize8Bold,
                System.Drawing.Brushes.Black,
                new RectangleF(3, 320, 200, 20),
                new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                });


            e.Graphics.DrawString("1517.80",
                calibriSize8Bold,
                System.Drawing.Brushes.Black,
                new RectangleF(80, 320, 200, 20),
                new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Far
                });


            e.Graphics.DrawString(stars,
               calibriSize8,
               System.Drawing.Brushes.Black,
               new RectangleF(3, 345, 300, 10),
               new StringFormat
               {
                   LineAlignment = StringAlignment.Center,
                   Alignment = StringAlignment.Near
               });
        }

        private void bGetInfo_Click(object sender, EventArgs e)
        {
            var root = new
            {
                operationId = "getInfo",
                version = 1
            };

            string json = JsonConvert.SerializeObject(root, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });


            RestClient rest = new RestClient();
            RestRequest request = new RestRequest(IpAddress, Method.Post);
            request.AddHeader("Content-Type", "application/json;charset=utf-8");
            request.AddStringBody(json, DataFormat.Json);
            RestResponse response = rest.Execute(request);


            if (response.IsSuccessful)
            {
                NbaResponse responseData = System.Text.Json.JsonSerializer.Deserialize<NbaResponse>(response.Content);

                if (responseData.message is "Successful operation")
                {
                    Registry.CurrentUser.CreateSubKey("NGT").SetValue("TsName", responseData.data.object_name);
                    Registry.CurrentUser.CreateSubKey("NGT").SetValue("Address", responseData.data.object_address);
                    Registry.CurrentUser.CreateSubKey("NGT").SetValue("CompanyName", responseData.data.company_name);
                    Registry.CurrentUser.CreateSubKey("NGT").SetValue("Voen", responseData.data.company_tax_number);
                    Registry.CurrentUser.CreateSubKey("NGT").SetValue("ObjectTaxNumber", responseData.data.object_tax_number);
                    Registry.CurrentUser.CreateSubKey("NGT").SetValue("NKAModel", responseData.data.cashregister_model);
                    Registry.CurrentUser.CreateSubKey("NGT").SetValue("NKASerialNumber", responseData.data.cashregister_factory_number);
                    Registry.CurrentUser.CreateSubKey("NGT").SetValue("NMQRegistrationNumber", responseData.data.cashbox_tax_number);
                    Registry.CurrentUser.CreateSubKey("NGT").SetValue("QRCodeUrl", responseData.data.qr_code_url);
                }
                else
                {
                    CommonMessageBox.ErrorMessageBox($"Xəta mesajı: {responseData.message}", $"Xəta kodu: {responseData.code}");
                }
            }
            else
            {
                CommonMessageBox.ErrorMessageBox($"Xəta mesajı: {response.ErrorMessage}", $"Xəta kodu: {response.StatusCode}");
            }



        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var parametr = new
            {
                pin = "12348765",
                role = "user",
                cashregister_factory_number = Registry.CurrentUser.OpenSubKey("NGT").GetValue("NKASerialNumber").ToString()
            };

            var root = new
            {
                parameters = parametr,
                operationId = "toLogin",
                version = 1
            };

            string json = JsonConvert.SerializeObject(root, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });


            RestClient rest = new RestClient();
            RestRequest request = new RestRequest(IpAddress, Method.Post);
            request.AddHeader("Content-Type", "application/json;charset=utf-8");
            request.AddStringBody(json, DataFormat.Json);
            RestResponse response = rest.Execute(request);


            if (response.IsSuccessful)
            {
                NbaResponse responseData = System.Text.Json.JsonSerializer.Deserialize<NbaResponse>(response.Content);

                if (responseData.message is "Successful operation")
                {
                    accessToken = responseData.data.access_token;
                    labelControl1.Text = "Token:" + accessToken;
                }
                else
                {
                    CommonMessageBox.ErrorMessageBox($"Xəta mesajı: {responseData.message}", $"Xəta kodu: {responseData.code}");
                }
            }
            else
            {
                CommonMessageBox.ErrorMessageBox($"Xəta mesajı: {response.ErrorMessage}", $"Xəta kodu: {response.StatusCode}");
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var parametr = new
            {
                access_token = accessToken,
            };

            var root = new
            {
                parameters = parametr,
                operationId = "openShift",
                version = 1
            };

            string json = JsonConvert.SerializeObject(root, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });


            RestClient rest = new RestClient();
            RestRequest request = new RestRequest(IpAddress, Method.Post);
            request.AddHeader("Content-Type", "application/json;charset=utf-8");
            request.AddStringBody(json, DataFormat.Json);
            RestResponse response = rest.Execute(request);


            if (response.IsSuccessful)
            {
                NbaResponse responseData = System.Text.Json.JsonSerializer.Deserialize<NbaResponse>(response.Content);

                if (responseData.message is "Successful operation")
                {
                    MessageBox.Show(responseData.message);
                }
                else
                {
                    CommonMessageBox.ErrorMessageBox($"Xəta mesajı: {responseData.message}", $"Xəta kodu: {responseData.code}");
                }
            }
            else
            {
                CommonMessageBox.ErrorMessageBox($"Xəta mesajı: {response.ErrorMessage}", $"Xəta kodu: {response.StatusCode}");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var data = new
            {
                cashier = "Həsən",
                currency = "AZN",
                sum = 10
            };

            var parametr = new
            {
                doc_type = "deposit",
                access_token = accessToken,
                data = data
            };

            var root = new
            {
                parameters = parametr,
                operationId = "createDocument",
                version = 1
            };

            string json = JsonConvert.SerializeObject(root, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });


            RestClient rest = new RestClient();
            RestRequest request = new RestRequest(IpAddress, Method.Post);
            request.AddHeader("Content-Type", "application/json;charset=utf-8");
            request.AddStringBody(json, DataFormat.Json);
            RestResponse response = rest.Execute(request);


            if (response.IsSuccessful)
            {
                NbaResponse responseData = System.Text.Json.JsonSerializer.Deserialize<NbaResponse>(response.Content);

                if (responseData.message is "Successful operation")
                {
                    PrintDocument pd = new PrintDocument();
                    pd.DefaultPageSettings = new PageSettings
                    {
                        PaperSize = new PrinterSettings().DefaultPageSettings.PaperSize
                    };

                    pd.PrintPage += new PrintPageEventHandler(PrintDeposit);



                    PrintDialog PrintDialog1 = new PrintDialog
                    {
                        Document = pd
                    };

                    pd.Print();
                }
                else
                {
                    CommonMessageBox.ErrorMessageBox($"Xəta mesajı: {responseData.message}", $"Xəta kodu: {responseData.code}");
                }
            }
            else
            {
                CommonMessageBox.ErrorMessageBox($"Xəta mesajı: {response.ErrorMessage}", $"Xəta kodu: {response.StatusCode}");
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            var parametr = new
            {
                access_token = accessToken,
            };

            var root = new
            {
                parameters = parametr,
                operationId = "closeShift",
                version = 1
            };

            string json = JsonConvert.SerializeObject(root, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });


            RestClient rest = new RestClient();
            RestRequest request = new RestRequest(IpAddress, Method.Post);
            request.AddHeader("Content-Type", "application/json;charset=utf-8");
            request.AddStringBody(json, DataFormat.Json);
            RestResponse response = rest.Execute(request);


            if (response.IsSuccessful)
            {
                NbaResponse responseData = System.Text.Json.JsonSerializer.Deserialize<NbaResponse>(response.Content);

                if (responseData.message is "Successful operation")
                {
                    MessageBox.Show(responseData.message);
                }
                else
                {
                    CommonMessageBox.ErrorMessageBox($"Xəta mesajı: {responseData.message}", $"Xəta kodu: {responseData.code}");
                }
            }
            else
            {
                CommonMessageBox.ErrorMessageBox($"Xəta mesajı: {response.ErrorMessage}", $"Xəta kodu: {response.StatusCode}");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var data = new
            {
                cashier = "Həsən",
                currency = "AZN",
                sum = 0.01
            };

            var parametr = new
            {
                doc_type = "deposit",
                access_token = accessToken,
                data = data
            };

            var root = new
            {
                parameters = parametr,
                operationId = "createDocument",
                version = 1
            };

            string json = JsonConvert.SerializeObject(root, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });


            RestClient rest = new RestClient();
            RestRequest request = new RestRequest(IpAddress, Method.Post);
            request.AddHeader("Content-Type", "application/json;charset=utf-8");
            request.AddStringBody(json, DataFormat.Json);
            RestResponse response = rest.Execute(request);


            if (response.IsSuccessful)
            {
                NbaResponse responseData = System.Text.Json.JsonSerializer.Deserialize<NbaResponse>(response.Content);

                if (responseData.message is "Successful operation")
                {
                    PrintDocument pd = new PrintDocument();
                    pd.DefaultPageSettings = new PageSettings
                    {
                        PaperSize = new PrinterSettings().DefaultPageSettings.PaperSize
                    };

                    pd.PrintPage += new PrintPageEventHandler(PrintSales);



                    PrintDialog PrintDialog1 = new PrintDialog
                    {
                        Document = pd
                    };

                    pd.Print();
                }
                else
                {
                    CommonMessageBox.ErrorMessageBox($"Xəta mesajı: {responseData.message}", $"Xəta kodu: {responseData.code}");
                }
            }
            else
            {
                CommonMessageBox.ErrorMessageBox($"Xəta mesajı: {response.ErrorMessage}", $"Xəta kodu: {response.StatusCode}");
            }
        }

        private void PrintSales(object sender, PrintPageEventArgs e)
        {
            Font calibriSize8 = new Font("Calibri", 9, FontStyle.Regular);
            Font calibriSize8Bold = new Font("Calibri", 9, FontStyle.Bold);
            Font productHeaderFont = new Font("Calibri", 8.5F, FontStyle.Regular);


            float totalWidth = 1000;
            float fontWidth = e.Graphics.MeasureString("*", calibriSize8Bold).Width;

            int starCount = (int)(totalWidth / fontWidth);

            string stars = new string('*', starCount);
            string line = new string('-', starCount);



            string header = $"TS Adı: {CommonData.TsName}\nTS Ünvanı: {CommonData.Address}\n\nVÖ Adı:{CommonData.CompanyName}\nVÖEN:{CommonData.Voen}\nObyekt kodu: {CommonData.VoenAndCode}";


            e.Graphics.DrawString(header,
                                 calibriSize8,
                                 System.Drawing.Brushes.Black,
                                 new RectangleF(35, 5F, 230F, 150F),
                                 new StringFormat
                                 {
                                     LineAlignment = StringAlignment.Center,
                                     Alignment = StringAlignment.Center
                                 });

            e.Graphics.DrawString("Satış",
                                calibriSize8Bold,
                                System.Drawing.Brushes.Black,
                                new RectangleF(35, 150F, 230F, 20),
                                new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });

            e.Graphics.DrawString($"Çek nömrəsi № {1}",
                    calibriSize8,
                    System.Drawing.Brushes.Black,
                    new RectangleF(35, 180F, 230F, 20),
                    new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });

            e.Graphics.DrawString("Kassir: Həsən Hüseynli Xanlar oğlu",
                   calibriSize8,
                   System.Drawing.Brushes.Black,
                   new RectangleF(3, 220, 150, 30),
                   new StringFormat
                   {
                       LineAlignment = StringAlignment.Center,
                       Alignment = StringAlignment.Near
                   });


            string datetime = $@"Tarix: {DateTime.Now.ToString("dd.MM.yyyy")}
Vaxt:          {DateTime.Now.ToString("HH:mm")}";

            e.Graphics.DrawString(datetime,
                  calibriSize8,
                  System.Drawing.Brushes.Black,
                  new RectangleF(78, 220, 210, 30),
                  new StringFormat
                  {
                      LineAlignment = StringAlignment.Center,
                      Alignment = StringAlignment.Far
                  });



            e.Graphics.DrawString(stars,
                calibriSize8,
                System.Drawing.Brushes.Black,
                new RectangleF(3, 260, 300, 10),
                new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                });


            e.Graphics.DrawString("Malın adı", productHeaderFont, Black, 3, 265);
            e.Graphics.DrawString("Miqdar", productHeaderFont, System.Drawing.Brushes.Black, 130, 265);
            e.Graphics.DrawString("Qiymət", productHeaderFont, System.Drawing.Brushes.Black, 185, 265);
            e.Graphics.DrawString("Toplam", productHeaderFont, System.Drawing.Brushes.Black, 240, 265);


            e.Graphics.DrawString(line,
                calibriSize8Bold,
                System.Drawing.Brushes.Black,
                new RectangleF(3, 280, 300, 10),
                new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                });

            //Produtcs
            e.Graphics.DrawString($"{4540270633844}\nBeloçka qara tum 25Q\n18% ƏDV", productHeaderFont, Black, new Point(3, 295));
            e.Graphics.DrawString($"{5}", productHeaderFont, Black, new Point(130, 295));
            e.Graphics.DrawString($"{0.20}", productHeaderFont, Black, new Point(185, 295));
            e.Graphics.DrawString($"{1.0}", productHeaderFont, Black, new Point(240, 295));
        }
    }
}