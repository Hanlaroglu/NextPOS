using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Barcode_Sales.Barcode.Sales.UI
{
    public partial class fRelacementPage : DevExpress.XtraEditors.XtraForm
    {
        public string Amount { get; set; }
        public string Price { get; set; }
        public string Barcode { get; set; }
        public string Operations { get; set; }
        public DataGridViewRow selectedRow { get; set; }

        public fRelacementPage(/*DataGridViewRow selectedRow*/)
        {
            InitializeComponent();
            switch (Operations)
            {
                case "Amount":
                    tTotal.Text = selectedRow.Cells[3].Value.ToString();
                    break;
                case "Price":
                    tTotal.Text = selectedRow.Cells[5].Value.ToString();
                    break;
                default:
                    break;
            }
        }

        private void bEnter_Click(object sender, EventArgs e)
        {
            ResultOk();
        }

        private void ResultOk()
        {
            switch (Operations)
            {
                case "Amount":
                    Amount = tTotal.Text;
                    DialogResult = DialogResult.OK;
                    break;
                case "Price":
                    Price = tTotal.Text;
                    DialogResult = DialogResult.OK;
                    break;
                case "Barcode":
                    Barcode = tTotal.Text;
                    DialogResult = DialogResult.OK;
                    break;
                default:
                    break;
            }
        }

        private void NumberButtons_Click(object sender, EventArgs e)
        {
            SimpleButton b = (SimpleButton)sender;
            if (b.Text is ",")
            {
                short vergul = Convert.ToInt16(tTotal.Text.Count(x => x == ','));
                if (vergul < 1) { tTotal.Text += b.Text; }
            }
            else { tTotal.Text += b.Text; }
        }

        private void bBackspace_Click(object sender, EventArgs e)
        {
            if (tTotal.Text.Length > 0) { tTotal.Text = tTotal.Text.Substring(0, tTotal.Text.Length - 1); }
        }

        private void fRelacementPage_Load(object sender, EventArgs e)
        {
            switch (Operations)
            {
                case "Amount":
                    lHeader.Text = "Miqdarı daxil edin";
                    break;
                case "Price":
                    lHeader.Text = "Satış qiymətini daxil edin";
                    break;
                case "Barcode":
                    lHeader.Text = "Barkodu daxil edin";
                    break;
                default:
                    break;
            }
        }

        private void tTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(tTotal.Text))
                if (e.KeyCode is Keys.Enter) { ResultOk(); }
        }
    }
}