using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NextPOS.UserControls
{
    public partial class userBtnCategory : DevExpress.XtraEditors.XtraUserControl
    {
        public userBtnCategory()
        {
            InitializeComponent();
        }

        public static double GetDouble(string value)
        {
            double netice;
            double.TryParse(value, NumberStyles.Currency, CultureInfo.CurrentUICulture.NumberFormat, out netice);
            return Math.Round(netice, 2);

        }

        public event EventHandler ButtonClick;

        public string MehsulAdi
        {
            get { return bMehsulAdi.Text; }
            set { bMehsulAdi.Text = value; }
        }

        public string ProductGroup { get; set; }

        public string Barcode { get; set; }

        public string ProductPrice
        {
            get { return lPrice.Text + " AZN"; }
            set { lPrice.Text = value + " AZN"; }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            ButtonClick(this, e);
        }
    }
}
