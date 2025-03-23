using Barcode_Sales.Helpers;
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
    public partial class fPriceChange : DevExpress.XtraEditors.XtraForm
    {
        private readonly Enums.PriceChangeOperation _operation;
        public fPriceChange(Enums.PriceChangeOperation operation)
        {
            InitializeComponent();
            _operation = operation;
        }

        private void fPriceChange_Load(object sender, EventArgs e)
        {
            switch (_operation)
            {
                case Enums.PriceChangeOperation.PriceChange:
                    navigationFrame1.SelectedPage = pagePriceChange;
                    chPriceChangeHeader.Checked = true;
                    break;
                case Enums.PriceChangeOperation.Discount:
                    navigationFrame1.SelectedPage = pageDiscount;
                    chDiscountCash.Checked = true;
                    break;
            }
        }

        private void NumberButtons_Click(object sender, EventArgs e)
        {
            SimpleButton b = (SimpleButton)sender;

            // Maskeyi geçici olarak devre dışı bırak
            tTotal.Properties.MaskSettings.Set("MaskManagerType", null);

            // Mevcut değeri al ve yeni metni ekle
            tTotal.Text += b.Text;

            // Maskeyi tekrar etkinleştir
            tTotal.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            tTotal.Properties.MaskSettings.Set("mask", "N2");


            //if (b.Text is ",")
            //{
            //    short vergul = Convert.ToInt16(tTotal.Text.Count(x => x == ','));
            //    if (vergul < 1) { tTotal.Text += b.Text; }
            //}
            //else
            //{
            //    tTotal.Text += b.Text;
            //}
        }

        private void bBackspace_Click(object sender, EventArgs e)
        {

        }

        private void bEnter_Click(object sender, EventArgs e)
        {

        }

        private void chDiscountPercent_CheckedChanged(object sender, EventArgs e)
        {
            tTotal.Properties.Buttons.FirstOrDefault(x => x.Caption == "%").Visible = true;
            tTotal.Properties.Buttons.FirstOrDefault(x => x.Caption == "₼").Visible = false;
        }

        private void chDiscountCash_CheckedChanged(object sender, EventArgs e)
        {
            tTotal.Properties.Buttons.FirstOrDefault(x => x.Caption == "%").Visible = false;
            tTotal.Properties.Buttons.FirstOrDefault(x => x.Caption == "₼").Visible = true;
        }
    }
}