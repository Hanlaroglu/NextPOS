using Barcode_Sales.Forms;
using DevExpress.XtraGrid.Localization;
using Licence;
using Licence.Forms;
using Licence.Services;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using static Barcode_Sales.Helpers.FormHelpers;

namespace Barcode_Sales
{
    static class Program
    {
        private static readonly string _licenceKey = LicenseService.Instance.GetLicenceKey();
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        
        const int SW_RESTORE = 9;
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GridLocalizer.Active = new MyGridLocalizer();

            string appName = Assembly.GetExecutingAssembly().GetName().Name;
            bool createdNew;
            Licence.Services.AppService.mutex = new Mutex(true, appName, out createdNew);
            if (!createdNew)
            {
                Process current = Process.GetCurrentProcess();
                Process[] processes = Process.GetProcessesByName(current.ProcessName);

                foreach (var process in processes)
                {
                    if (process.Id != current.Id)
                    {
                        IntPtr handle = process.MainWindowHandle;
                        if (handle != IntPtr.Zero)
                        {
                            ShowWindow(handle, SW_RESTORE);
                            SetForegroundWindow(handle);
                        }
                        break;
                    }
                }
                return;
            }

            #region [..Licence..]

            //if (string.IsNullOrWhiteSpace(_licenceKey) || _licenceKey is "Yoxdur")
            //{
            //    var result = new fRegister().ShowDialog();

            //    if (result == DialogResult.OK)
            //    {
            //        Application.Restart();
            //    }
            //    return;
            //}


            //if (Licence.Helpers.FormHelpers.HasInternetConnection())
            //{
            //    var user = LicenseService.Instance.GetKeyControl(_licenceKey).Result;
            //    if (user == null || !user.IsActive || !LicenseService.Instance.LicenceExpireDateControl(user))
            //    {
            //        Application.Run(new fDeactive(user));
            //        return;
            //    }
            //}
            //else
            //{
            //    //NotificationHelpers.Messages.WarningMessage(,"İnternet bağlantınız yoxdur",);
            //}

            #endregion [..Licence..]

            CultureInfoData();
            Application.Run(new fLoginDemo());

        }

        static void CultureInfoData()
        {
            var culture = new CultureInfo("az-AZ");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator = ",";
            CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ".";
            CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol = "₼"; //₼
        }
    }
}
