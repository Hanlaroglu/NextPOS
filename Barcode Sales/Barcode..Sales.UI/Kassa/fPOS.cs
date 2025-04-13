using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Management;
using System.Text.Json;

namespace Barcode_Sales.Barcode.Sales.UI.Kassa
{
    public partial class fPOS : DevExpress.XtraEditors.XtraForm
    {
        public fPOS()
        {
            InitializeComponent();
        }

        private void bOpenPOS_Click(object sender, EventArgs e)
        {
            //Sunmi.OpenShift(Sunmi.TerminalIPAdress());
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
         //   Sunmi.CloseShift(Sunmi.TerminalIPAdress());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           // Sunmi.PrintLast(Sunmi.TerminalIPAdress());
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
           // Sunmi.ShiftStatus(Sunmi.TerminalIPAdress());
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
//Sunmi.PeriodicReport(Sunmi.TerminalIPAdress());
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
          //  Sunmi.XReport(Sunmi.TerminalIPAdress());
        }
    }
}