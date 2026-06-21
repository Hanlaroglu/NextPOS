using Barcode_Sales.Helpers;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using Barcode_Sales.DTOs;

namespace Barcode_Sales.Forms
{
    public partial class fPriceChange : DevExpress.XtraEditors.XtraForm
    {
        private readonly PosChangeType _changeType;

        public decimal Amount { get; set; }

        public fPriceChange(PosChangeType changeType)
        {
            InitializeComponent();
            _changeType = changeType;
        }

        private void fPriceChange_Load(object sender, EventArgs e)
        {
            this.Text = EnumExtensions.GetEnumDescription(_changeType.ChangeType);
            switch (_changeType.ChangeType)
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
                    if (_changeType.UnitName is "Ədəd")
                    {
                        tTotal.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
                        tTotal.Properties.MaskSettings.Set("mask", "F0");
                    }
                    else
                    {
                        tTotal.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
                        tTotal.Properties.MaskSettings.Set("mask", "F3");
                    }
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

            bool isIntegerOnly = _changeType.ChangeType == Enums.PosChangeType.Quantity
                                 && _changeType.UnitName == "Ədəd";
            int maxDecimals = isIntegerOnly ? 0
                : (_changeType.ChangeType == Enums.PosChangeType.Quantity ? 3 : 2);

            if (key == "," || key == ".")
            {
                if (maxDecimals == 0) return;
                _enteringDecimals = true;
                _decimalCount = 0;
                ShowValue();
                return;
            }

            int digit = int.Parse(key);
            if (!_enteringDecimals)
            {
                _value = _value * 10 + digit;
            }
            else if (_decimalCount < maxDecimals)
            {
                decimal factor = (decimal)Math.Pow(10, -(_decimalCount + 1)); // 0.1, 0.01, 0.001...
                _value = Math.Floor(_value) + (_value - Math.Floor(_value)) + digit * factor;
                _decimalCount++;
            }

            ShowValue();
        }

        private void ShowValue()
        {
            _updating = true;

            bool isIntegerOnly = _changeType.ChangeType == Enums.PosChangeType.Quantity
                                 && _changeType.UnitName == "Ədəd";
            string format = isIntegerOnly ? "F0"
                : (_changeType.ChangeType == Enums.PosChangeType.Quantity ? "F3" : "F2");

            tTotal.Text = _value.ToString(format);
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
            decimal total = decimal.Parse(tTotal.Text);
            switch (_changeType.ChangeType)
            {
                case Enums.PosChangeType.Discount:
                    if (chDiscountPercent.Checked)
                    {
                        decimal price = (_changeType.Amount * total) / 100;

                        if (price > _changeType.Amount)
                        {
                            NotificationHelpers.Messages.WarningMessage(this, "Endirim faizi endirim 100%-dən çox ola bilməz !");
                            return;
                        }
                        Amount = price;
                        DialogResult = DialogResult.OK;
                    }
                    else if (chDiscountCash.Checked)
                    {
                        if (total > _changeType.Amount)
                        {
                            NotificationHelpers.Messages.WarningMessage(this, "Endirim məbləği satış qiymətindən çox ola bilməz !");
                            return;
                        }

                        Amount = total;
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