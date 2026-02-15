using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.Helpers
{
    public static class CommonData
    {
        public static Terminal terminal;

        public static readonly string DEFAULT_INT_TOSTRING = 0.ToString();
        public static readonly string TODAY_DATE = DateTime.Now.ToString("dd.MM.yyyy");
        public static readonly string DATE_AND_TIME = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        public static User CURRENT_USER;
        public static readonly string TsName = Registry.CurrentUser.OpenSubKey("NGT").GetValue("NKASerialNumber").ToString();
        public static readonly string Address = Registry.CurrentUser.OpenSubKey("NGT").GetValue("Address").ToString();
        public static readonly string CompanyName = Registry.CurrentUser.OpenSubKey("NGT").GetValue("CompanyName").ToString();
        public static readonly string Voen = Registry.CurrentUser.OpenSubKey("NGT").GetValue("Voen").ToString();
        public static readonly string VoenAndCode = Registry.CurrentUser.OpenSubKey("NGT").GetValue("ObjectTaxNumber").ToString();
        public static readonly string NMQRegistrationNumber = Registry.CurrentUser.OpenSubKey("NGT").GetValue("NMQRegistrationNumber").ToString();
        public static readonly string QRCodeUrl = Registry.CurrentUser.OpenSubKey("NGT").GetValue("QRCodeUrl").ToString();
        public static readonly string NKAModel = Registry.CurrentUser.OpenSubKey("NGT").GetValue("NKAModel").ToString();
        public static readonly string NKASerialNumber = Registry.CurrentUser.OpenSubKey("NGT").GetValue("NKASerialNumber").ToString();

        public static void RegeditControl()
        {
            //ProductID Default
            if (Registry.GetValue(@"HKEY_CURRENT_USER\NGT\Next Market\Settings", "ProductID", null) == null)
            {
                Registry.CurrentUser.CreateSubKey("NGT").CreateSubKey("Next Market").CreateSubKey("Settings").SetValue("ProductID", "N/A");
            }

            // Backup alınma tarixi
            if (Registry.GetValue(@"HKEY_CURRENT_USER\NGT\Next Market\Settings\Backup", "History", null) == null)
            {
                Registry.CurrentUser.CreateSubKey("NGT").CreateSubKey("Next Market").CreateSubKey("Settings").CreateSubKey("Backup").SetValue("History", "Yoxdur");
            }

            // Bağlanışta backup
            if (Registry.GetValue(@"HKEY_CURRENT_USER\NGT\Next Market\Settings\Backup", "Shutdown", null) == null)
            {
                Registry.CurrentUser.CreateSubKey("NGT").CreateSubKey("Next Market").CreateSubKey("Settings").CreateSubKey("Backup").SetValue("Shutdown", false);
            }

            // Açılışta Backup
            if (Registry.GetValue(@"HKEY_CURRENT_USER\NGT\Next Market\Settings\Backup", "Boot", null) == null)
            {
                Registry.CurrentUser.CreateSubKey("NGT").CreateSubKey("Next Market").CreateSubKey("Settings").CreateSubKey("Backup").SetValue("Boot", false);
            }

            //Ticarət subyektinin adı - object_name
            if (Registry.GetValue(@"HKEY_CURRENT_USER\NGT\", "TsName", null) == null)
            {
                Registry.CurrentUser.CreateSubKey("NGT").SetValue("TsName", "");
            }

            //Ünvan - object_address
            if (Registry.GetValue(@"HKEY_CURRENT_USER\NGT\", "Address", null) == null)
            {
                Registry.CurrentUser.CreateSubKey("NGT").SetValue("Address", "");
            }

            //VÖ Adı - company_name
            if (Registry.GetValue(@"HKEY_CURRENT_USER\NGT\", "CompanyName", null) == null)
            {
                Registry.CurrentUser.CreateSubKey("NGT").SetValue("CompanyName", "");
            }

            //Vöen - company_tax_number
            if (Registry.GetValue(@"HKEY_CURRENT_USER\NGT\", "Voen", null) == null)
            {
                Registry.CurrentUser.CreateSubKey("NGT").SetValue("Voen", "");
            }

            //Vöen & obyekt kodu - object_tax_number
            if (Registry.GetValue(@"HKEY_CURRENT_USER\NGT\", "ObjectTaxNumber", null) == null)
            {
                Registry.CurrentUser.CreateSubKey("NGT").SetValue("ObjectTaxNumber", "");
            }

            //Nka Modeli - cashregister_model
            if (Registry.GetValue(@"HKEY_CURRENT_USER\NGT\", "NKAModel", null) == null)
            {
                Registry.CurrentUser.CreateSubKey("NGT").SetValue("NKAModel", "");
            }

            //NKA zavod nömresi - cashregister_factory_number
            if (Registry.GetValue(@"HKEY_CURRENT_USER\NGT\", "NKASerialNumber", null) == null)
            {
                Registry.CurrentUser.CreateSubKey("NGT").SetValue("NKASerialNumber", "");
            }

            //NMQ-nın qeydiyyat nömrəsi - cashbox_tax_number
            if (Registry.GetValue(@"HKEY_CURRENT_USER\NGT\", "NMQRegistrationNumber", null) == null)
            {
                Registry.CurrentUser.CreateSubKey("NGT").SetValue("NMQRegistrationNumber", "");
            }

            //QR kod url - qr_code_url
            if (Registry.GetValue(@"HKEY_CURRENT_USER\NGT\", "QRCodeUrl", null) == null)
            {
                Registry.CurrentUser.CreateSubKey("NGT").SetValue("QRCodeUrl", "");
            }
        }
    }
}
