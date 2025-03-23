using Barcode_Sales.Barcode.Sales.UI.Kassa;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fPosSalesControlPanel : DevExpress.XtraEditors.XtraForm
    {
        static ITerminalOperation terminalOperation = new TerminalManager();
        public static readonly string _IpAddress = terminalOperation.GetIpAddress();
        public fPosSalesControlPanel()
        {
            InitializeComponent();
        }

        private void bShift_Click(object sender, EventArgs e)
        {
            Sunmi.ShiftStatus(_IpAddress);
        }

        private void bCloseShift_Click(object sender, EventArgs e)
        {
            Sunmi.CloseShift(_IpAddress);
        }
    }
}