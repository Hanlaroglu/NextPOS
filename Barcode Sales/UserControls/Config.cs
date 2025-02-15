using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.UserControls
{
    public class Config
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]

        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32.dll")]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        public  string Read(string SectionName, string KeyName, string INIPath)
        {
            StringBuilder sb = new StringBuilder(5000);
            GetPrivateProfileString(SectionName, KeyName, "", sb, sb.Capacity, INIPath); 
            string okunan_veri = sb.ToString();
            sb.Clear();
            return okunan_veri;
        } //Oxuma

        public  void Write(string SectionName, string KeyName, object Value, string INIPath)
        {
            WritePrivateProfileString(SectionName, KeyName, Value.ToString(), INIPath);
        } //Yazma
    }
}
