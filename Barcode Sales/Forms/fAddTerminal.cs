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
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;

namespace Barcode_Sales.Forms
{
    public partial class fAddTerminal : DevExpress.XtraEditors.XtraForm
    {
        ITerminalOperation terminalOperation = new TerminalManager();
        public fAddTerminal()
        {
            InitializeComponent();
        }

        /* Fliallarıın əlavəsi
         * Kassirlərin əlavəsi
         * E-Kassa siyahısının əlavəsi
         * Terminal əlavəsi
         * Bank əlavəsi üçün db dən bank portu bölməsini əlavə et
         * Bank varsa bank bölməsinin visible true olsun
         * Dashboardda Terminallara daxil olduqda pageNavigationda Terminallar səhifəsinə keçsin. (Digərlərində olduğu kimi)
         */

        private void fAddTerminal_Shown(object sender, EventArgs e)
        {

        }

        private void GetTerminals()
        {

        }

        private void Save()
        {

        }
    }
}