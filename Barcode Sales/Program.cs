using System;
using System.Globalization;
using System.Windows.Forms;
using Barcode_Sales.Forms;
using Barcode_Sales.Helpers;
using DevExpress.XtraGrid.Localization;
using static Barcode_Sales.Helpers.FormHelpers;
using fDashboard = Barcode_Sales.Barcode.Sales.Admin.fDashboard;

namespace Barcode_Sales
{
    static class Program
    {
        [STAThread]

        static void Main()
        {
            var culture = new CultureInfo("az-AZ");
            GridLocalizer.Active = new MyGridLocalizer();
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator = ",";
            CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ".";
            CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol = "AZN"; //₼
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fLogin());
           // Application.Run(new fInvoiceRollbackProduct());






            //Application.Run(new fSupplierPay(Helpers.Enums.Operation.Pay));
            //if (!File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\{Application.CompanyName}\\Config.dat"))
            //{
            //    Application.Run(new fConnection());
            //    //OperationsControl.CreateDB();
            //    //OperationsControl.AdminExists();
            //    //OperationsControl.SqlQuery();
            //}
            //else
            //{
            //    if (NetworkInterface.GetIsNetworkAvailable())
            //    {
            //        switch (LicenceControl.LicControl(Registry.CurrentUser.OpenSubKey("NGT").OpenSubKey("Next Market").OpenSubKey("Settings").GetValue("ProductID").ToString()))
            //        {
            //            case true:
            //                //Application.Run(new Barcode.Sales.Admin.fDashboard());
            //                Application.Run(new fBarcodeSalesUI());
            //                break;
            //            case false:
            //                //Application.Run(new fDeactive());
            //                break;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("İnternet bağlantınız yoxdur !", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
        }


    }
}
