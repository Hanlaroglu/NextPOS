using Barcode_Sales.UserControls;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales
{
    public partial class fInfo : DevExpress.XtraEditors.XtraForm
    {
        public fInfo()
        {
            InitializeComponent();
            this.Text = "NextPOS / Məlumat";
            lVersion.Text = Application.ProductVersion;
        }

        NextposDBEntities db = new NextposDBEntities();

        private void tabMenu_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            WebClient web = new WebClient();
            if (tabMenu.SelectedPage == pageLicence)
            {
                //Licence
            }
        }



        private void bYenile_Click(object sender, EventArgs e)
        {

        }
    }
}