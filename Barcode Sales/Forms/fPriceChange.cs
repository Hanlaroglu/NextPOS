using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Classes;
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
        private readonly SaleClasses.PosChangeType _posChangeType;

        public double Amount { get; set; }
        //public double SalePrice { get; set; }
        //public double DiscountPrice { get; set; }
        //public double Quantity { get; set; }
        public fPriceChange(SaleClasses.PosChangeType changeType)
        {
            InitializeComponent();
            _posChangeType = changeType;
        }

        private void fPriceChange_Load(object sender, EventArgs e)
        {
            this.Text = string.IsNullOrWhiteSpace(_posChangeType.ProductName) ? Enums.GetEnumDescription(_posChangeType.ChangeType) : _posChangeType.ProductName;
            switch (_posChangeType.ChangeType)
            {
                case Enums.PosChangeType.PriceChange:
                    navigationFrame1.SelectedPage = pagePriceChange;
                    chPriceChangeHeader.Checked = true;
                    break;
                case Enums.PosChangeType.Discount:
                    navigationFrame1.SelectedPage = pageDiscount;
                    chDiscountCash.Checked = true;
                    break;
                case Enums.PosChangeType.Quantity:
                    navigationFrame1.SelectedPage = pageQuantity;
                    tTotal.Properties.Buttons.FirstOrDefault(x => x.Caption == "₼").Visible = false;
                    tTotal.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
                    tTotal.Properties.MaskSettings.Set("mask", "N3");
                    chQuantity.Checked = true;
                    break;
                case Enums.PosChangeType.Deposit:
                    navigationFrame1.SelectedPage = pageDeposit;
                    chDeposit.Checked = true;
                    break;
                case Enums.PosChangeType.Withdraw:
                    navigationFrame1.SelectedPage = pageWithdraw;
                    chWithdraw.Checked = true;
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
            switch (_posChangeType.ChangeType)
            {
                case Enums.PosChangeType.Discount:
                    if (chDiscountPercent.Checked)
                    {
                        double price = (_posChangeType.Amount * Double.Parse(tTotal.Text)) / 100;
                        Amount = price;
                        DialogResult = DialogResult.OK;
                    }
                    else if (chDiscountCash.Checked)
                    {
                        Amount = Double.Parse(tTotal.Text);
                        DialogResult = DialogResult.OK;
                    }
                    break;
                default:
                    Amount = Double.Parse(tTotal.Text);
                    DialogResult = DialogResult.OK;
                    break;
            }
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