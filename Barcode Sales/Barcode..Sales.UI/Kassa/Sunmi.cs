using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace Barcode_Sales.Barcode.Sales.UI.Kassa
{
    public static class Sunmi
    {
        public class WeatherForecast
        {
            public string code { get; set; }
            public string message { get; set; }
            public string documentid { get; set; }
        }

        public class StatusTest
        {
            public string code { get; set; }
            public DateTime shift_open_time { get; set; }
            public bool shift_open { get; set; }
            public string message { get; set; }
        }


        #region [...] Növbə aç
        public static void OpenShift(string ip)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(ip);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json;charset=utf-8";
            httpRequest.ContentType = "application/json;charset=utf-8";

            var data = @"{
                   ""operation"": ""openShift"",
                   ""cashierName"": ""{}""
                   //""username"":""Həsən"",
                   //""password"": ""Hüseynli""
                          }";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(result);

                if ($"{weatherForecast.message}" == "Success operation" || $"{weatherForecast.message}" == "Successful operation")
                {
                    XtraMessageBox.Show("UĞURLA AÇILDI");
                }
                else
                {
                    XtraMessageBox.Show(weatherForecast.message);
                }
            }
        }
        #endregion


        #region [...] Növbəni bağla
        public static void CloseShift(string ip)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(ip);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json;charset=utf-8";
            httpRequest.ContentType = "application/json;charset=utf-8";

            var data = @"{
                   ""operation"": ""closeShift"",
                   ""cashierName"": ""Həsən Hüseynli"",
                   ""username"":""admin"",
                   ""password"": ""admin""
                          }";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                WeatherForecast weatherForecast = System.Text.Json.JsonSerializer.Deserialize<WeatherForecast>(result);

                if ($"{weatherForecast.message}" == "Success operation" || $"{weatherForecast.message}" == "Successful operation")
                {
                    XtraMessageBox.Show("GÜNLÜK Z HESABATI UĞURLA ÇIXARILDI");
                }
            }
        }
        #endregion


        #region [...] Növbə statusunun yoxlanılması
        public static void ShiftStatus(string ip)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(ip);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json;charset=utf-8";
            httpRequest.ContentType = "application/json;charset=utf-8";

            var data = @"{
                   ""operation"": ""getShiftStatus"",
                   ""username"":""admin"",
                   ""password"": ""admin""
                          }";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                StatusTest weatherForecast = JsonSerializer.Deserialize<StatusTest>(result);

                if ($"{weatherForecast.message}" == "Success operation" || $"{weatherForecast.message}" == "Successful operation")
                {
                    XtraMessageBox.Show(result);
                    XtraMessageBox.Show(weatherForecast.shift_open.ToString());
                    XtraMessageBox.Show(weatherForecast.shift_open_time.ToString());
                }
                else
                {
                    XtraMessageBox.Show(weatherForecast.message);
                }
            }
        }
        #endregion


        #region [...] Təkrar qəbz
        public static void PrintLast(string ip)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(ip);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json;charset=utf-8";
            httpRequest.ContentType = "application/json;charset=utf-8";

            var data = @"{
                   ""operation"": ""printLastCheque"",      
                   ""username"":""admin"",
                   ""password"": ""admin""}";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                WeatherForecast weatherForecast = System.Text.Json.JsonSerializer.Deserialize<WeatherForecast>(result);

                if ($"{weatherForecast.message}" == "Success operation" || $"{weatherForecast.message}" == "Successful operation")
                {
                    XtraMessageBox.Show("TƏKRAR QƏBZ UĞURLA ÇIXARILDI");
                }
            }
        }
        #endregion


        #region [...] İP Adresi al
        public static string TerminalIPAdress()
        {
            using (var db = new NextposDBEntities())
            {
                var userID = db.Users.AsNoTracking().Where(x => x.Id == Properties.Settings.Default.UserID).FirstOrDefault();
                //return "http://" + userID.Terminals.IpAddress + ":5544";
                return null;
            }
        }
        #endregion


        #region [...] Aylıq Hesabat
        public static void PeriodicReport(string ip)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(ip);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json;charset=utf-8";
            httpRequest.ContentType = "application/json;charset=utf-8";

            var data = @"{
                   ""operation"": ""getPeriodicZReport"",
                   ""username"":""admin"",
                   ""password"": ""admin"",
                    ""data"":{""startDate"":""28.07.2021 00:00:00"",
                    ""endDate"": ""29.07.2021 23:59:59""}}";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(result);

                if ($"{weatherForecast.message}" == "Success operation" || $"{weatherForecast.message}" == "Successful operation")
                {
                    XtraMessageBox.Show("Aylıq hesabat çıxartıldı");
                }
                else
                {
                    XtraMessageBox.Show(weatherForecast.message);
                }
            }
        }
        #endregion


        #region [...] X Hesabat
        public static void XReport(string ip)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(ip);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json;charset=utf-8";
            httpRequest.ContentType = "application/json;charset=utf-8";

            var data = @"{
                    ""data"":{""cashierName"":""Həsən Hüseynli""},
                   ""operation"": ""getXReport"",
                   ""username"":""admin"",
                   ""password"": ""admin""}";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                //MessageBox.Show(result.ToString());

                WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(result);

                //MessageBox.Show($"{weatherForecast.message}");

                if ($"{weatherForecast.message}" == "Success operation" || $"{weatherForecast.message}" == "Successful operation")
                {
                    XtraMessageBox.Show("X hesabat çıxartıldı");
                }
                else
                {
                    XtraMessageBox.Show(weatherForecast.message);
                }
            }
        }
        #endregion


        #region [...] Satıs
        public static void Sales(string ip, string jsonData, int userID, string ProccesNo, Decimal Cash, Decimal Card, Decimal Total)
        {
            //var url = ip;

            //var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            //httpRequest.Method = "POST";

            //httpRequest.Accept = "application/json;charset=utf-8";
            //httpRequest.ContentType = "application/json;charset=utf-8";

            ////var data = st.returnjson();


            //var data = @"{
            //       ""operation"": ""printLastCheque"",      
            //       ""username"":""admin"",
            //       ""password"": ""admin""}";




            //using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            //{
            //    streamWriter.Write(data);
            //}

            //var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            //using (
            //    var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    var result = streamReader.ReadToEnd();

            //    WeatherForecast weatherForecast =
            //    System.Text.Json.JsonSerializer.Deserialize<WeatherForecast>(result);

            //    if ($"{weatherForecast.message}" == "Success operation" || $"{weatherForecast.message}" == "Successful operation")
            //    {
            //        XtraMessageBox.Show("SATIŞ UĞURLA TAMAMLANDI");

            //        string a = $"{weatherForecast.documentid}";
            //        textEdit3.Text = a;
            //        st.insert_chec_pos_main(result, p_id, textEdit1.Text.ToString(), cash_, card_, umumi_mebleg_);

            //    }
            //    else
            //    {
            //        XtraMessageBox.Show($"{weatherForecast.message}");
            //    }

            //}
        }
        #endregion
    }
}