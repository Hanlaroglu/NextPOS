using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Classes;
using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Barcode_Sales.Forms
{
    public partial class fPriceChange : DevExpress.XtraEditors.XtraForm
    {
        private readonly SaleClasses.PosChangeType _posChangeType;

        public decimal Amount { get; set; }
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
            this.Text = string.IsNullOrWhiteSpace(_posChangeType.ProductName) ? EnumExtensions.GetEnumDescription(_posChangeType.ChangeType) : _posChangeType.ProductName;
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

        private bool _updating = false;
        private bool _enteringDecimals = false;
        private int _decimalCount = 0;
        private decimal _value = 0;
        private void NumberButtons_Click(object sender, EventArgs e)
        {
            string key = ((SimpleButton)sender).Text;

            if (key == "," || key == ".")
            {
                _enteringDecimals = true;
                _decimalCount = 0;
                ShowValue();
                return;
            }

            int digit = int.Parse(key);

            if (!_enteringDecimals)
                _value = _value * 10 + digit;
            else
            {
                if (_decimalCount < 2)
                {
                    decimal factor = _decimalCount == 0 ? 0.1m : 0.01m;
                    _value = Math.Floor(_value) +
                             (_value - Math.Floor(_value)) +
                             digit * factor;
                    _decimalCount++;
                }
            }

            ShowValue();
        }

        private void ShowValue()
        {
            _updating = true;
            tTotal.Text = _value.ToString("N2");
            tTotal.SelectionStart = tTotal.Text.Length;
            _updating = false;
        }

        private void tTotal_TextChanged(object sender, EventArgs e)
        {
            if (_updating) return;

            if (decimal.TryParse(tTotal.Text, out decimal val))
            {
                _value = val;
                _enteringDecimals = tTotal.Text.Contains(",") || tTotal.Text.Contains(".");
            }
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            _value = 0;
            _enteringDecimals = false;
            _decimalCount = 0;
            ShowValue();
        }

        private void bEnter_Click(object sender, EventArgs e)
        {
            switch (_posChangeType.ChangeType)
            {
                case Enums.PosChangeType.Discount:
                    if (chDiscountPercent.Checked)
                    {
                        decimal price = (_posChangeType.Amount * Decimal.Parse(tTotal.Text)) / 100;
                        Amount = price;
                        DialogResult = DialogResult.OK;
                    }
                    else if (chDiscountCash.Checked)
                    {
                        Amount = decimal.Parse(tTotal.Text);
                        DialogResult = DialogResult.OK;
                    }
                    break;
                default:
                    Amount = Decimal.Parse(tTotal.Text);
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