using Barcode_Sales.Services.CacheServices;
using Barcode_Sales.Terminals.DTOs;
using Barcode_Sales.Terminals.Omnitech;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fPosPay : DevExpress.XtraEditors.XtraForm
    {
        private PosSaleDto _data;
        public fPosPay(PosSaleDto data)
        {
            InitializeComponent();
            _data = data;

        }

        private void fPosPay_Load(object sender, EventArgs e)
        {
            tTotal.Text = _data.Items.Sum(x=> x.Sum).ToString("F2");
            bCash_Click(sender, e);
            this.tCash_Paid.SelectAll();
            this.tCash_Paid.Focus();
        }

        private void bCash_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pageCash;
            tCash_Paid.Text = _data.Items.Sum(x => x.Sum).ToString("N2");
        }

        private void bCard_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pageCard;
        }

        private void bCashCard_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pageCashCard;
        }

        private void bAdvance_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pageAdvance;
        }

        private void bFree_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pageFree;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tCash_Paid_EditValueChanged(object sender, EventArgs e)
        {
            decimal Paid = Convert.ToDecimal(tCash_Paid.Text);
            decimal Total = Convert.ToDecimal(tTotal.Text);
            decimal balance = Paid - Total;
            if (balance > 0)
                tCash_Balance.Text = balance.ToString("N2");
            else
                tCash_Balance.Text = 0.ToString("N2");
        }

        private void bPay_Click(object sender, EventArgs e)
        {
            if (navigationFrame1.SelectedPage == pageCash)
                CashPaid();
            else if (navigationFrame1.SelectedPage == pageCard)
                CardPaid();
            else if (navigationFrame1.SelectedPage == pageCashCard)
                CashCardPaid();
        }

        private async void CashPaid()
        {
            if (TerminalCacheService.Terminal != null)
            {
                _data.Cash = _data.Items.Sum(x=> x.Sum);
                _data.Card = 0;
                _data.IncomingSum = decimal.Parse(tCash_Paid.Text);

                if (_data.IncomingSum < _data.Items.Sum(x => x.Sum))
                {
                    NotificationHelpers.Messages.WarningMessage(this, "Ödənilən məbləğ yekun məbləğdən kiçik olabilməz !", nameof(Helpers.Enums.MessageTitle.Xəbərdarlıq));
                    return;
                }

                var terminal = (Helpers.Enums.Terminal)Enum.Parse(typeof(Helpers.Enums.Terminal), TerminalCacheService.Terminal.Name);
                switch (terminal)
                {
                    case Helpers.Enums.Terminal.Caspos:
                        //if (NKA.Sunmi.Sale(_data))
                        //    DialogResult = DialogResult.OK;
                        break;
                    case Helpers.Enums.Terminal.Omnitech:
                        OmnnitechTerminal omnitech = new OmnnitechTerminal(TerminalCacheService.Terminal.IpAddress);

                        var result = await omnitech.Sale(_data);
                        fPosSales _form = Application.OpenForms.OfType<fPosSales>().FirstOrDefault();
                        if (result.Success)
                        {
                            NotificationHelpers.Messages.SuccessMessage(_form, result.Message);
                            DialogResult = DialogResult.OK;
                        }
                        else
                            NotificationHelpers.Messages.ErrorMessage(_form, result.Message);
                        break;
                    case Helpers.Enums.Terminal.AzSmart:
                        //if (NKA.AzSmart.Sale(_data))
                        //    DialogResult = DialogResult.OK;
                        break;
                    case Helpers.Enums.Terminal.Nba:
                        break;
                    case Helpers.Enums.Terminal.DataPay:
                        break;
                    case Helpers.Enums.Terminal.OneClick:
                        break;
                }
            }
        }

        private async void CardPaid()
        {
            _data.Card = _data.Items.Sum(x => x.Sum);
            _data.Cash = 0;

            if (TerminalCacheService.Terminal != null)
            {
                var kassa = (Helpers.Enums.Terminal)Enum.Parse(typeof(Helpers.Enums.Terminal), TerminalCacheService.Terminal.Name);
                switch (kassa)
                {
                    case Helpers.Enums.Terminal.Caspos:
                        //if (NKA.Sunmi.Sale(_data))
                        //    DialogResult = DialogResult.OK;
                        break;
                    case Helpers.Enums.Terminal.Omnitech:
                        OmnnitechTerminal omnitech = new OmnnitechTerminal(TerminalCacheService.Terminal.IpAddress);

                        var result = await omnitech.Sale(_data);
                        fPosSales _form = Application.OpenForms.OfType<fPosSales>().FirstOrDefault();
                        if (result.Success)
                        {
                            NotificationHelpers.Messages.SuccessMessage(_form, result.Message);
                            DialogResult = DialogResult.OK;
                        }
                        else
                            NotificationHelpers.Messages.ErrorMessage(_form, result.Message);
                        break;
                    case Helpers.Enums.Terminal.AzSmart:
                        //if (NKA.AzSmart.Sale(_data))
                        //    DialogResult = DialogResult.OK;
                        break;
                    case Helpers.Enums.Terminal.Nba:
                        break;
                    case Helpers.Enums.Terminal.DataPay:
                        break;
                    case Helpers.Enums.Terminal.OneClick:
                        break;
                }
            }
        }

        private async void CashCardPaid()
        {
            decimal total = _data.Items.Sum(x => x.Sum);
            _data.Card = decimal.Parse(tCashCard_Card.Text);
            _data.Cash = total - _data.Card;
            _data.IncomingSum = decimal.Parse(tCashCard_Cash.Text);

            string warning = (_data.Card == 0) ? "Kart məbləğ '0' olabilməz !"
                : (_data.Card > _data.Total) ? "Ödənilən kart məbləği yekun məbləğdən böyük olabilməz !"
                : (_data.IncomingSum == 0) ? "Nağd məbləğ '0' olabilməz !"
                : (_data.IncomingSum + _data.Card < total) ? "Ödənilən məbləğ yekun məbləğdən kiçik olabilməz !"
                : null;

            if (warning != null)
            {
                NotificationHelpers.Messages.WarningMessage(this, warning, nameof(Helpers.Enums.MessageTitle.Xəbərdarlıq));
                return;
            }


            if (TerminalCacheService.Terminal != null)
            {
               var kassa = (Helpers.Enums.Terminal)Enum.Parse(typeof(Helpers.Enums.Terminal), TerminalCacheService.Terminal.Name);
                switch (kassa)
                {
                    case Helpers.Enums.Terminal.Caspos:
                        //if (NKA.Sunmi.Sale(_data))
                        //    DialogResult = DialogResult.OK;
                        break;
                    case Helpers.Enums.Terminal.Omnitech:
                        OmnnitechTerminal omnitech = new OmnnitechTerminal(TerminalCacheService.Terminal.IpAddress);

                        var result = await omnitech.Sale(_data);
                        fPosSales _form = Application.OpenForms.OfType<fPosSales>().FirstOrDefault();
                        if (result.Success)
                        {
                            NotificationHelpers.Messages.SuccessMessage(_form, result.Message);
                            DialogResult = DialogResult.OK;
                        }
                        else
                            NotificationHelpers.Messages.ErrorMessage(_form, result.Message);
                        break;
                    case Helpers.Enums.Terminal.AzSmart:
                        //if (NKA.AzSmart.Sale(_data))
                        //    DialogResult = DialogResult.OK;
                        break;
                    case Helpers.Enums.Terminal.Nba:
                        break;
                    case Helpers.Enums.Terminal.DataPay:
                        break;
                    case Helpers.Enums.Terminal.OneClick:
                        break;
                }
            }
        }

        private void navigationFrame1_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (e.Page == pageCash)
            {
                tCash_Paid.Focus();
            }
        }

        private void tCashCard_Card_EditValueChanged(object sender, EventArgs e)
        {
            double total = double.Parse(tTotal.Text);
            double card = double.Parse(tCashCard_Card.Text);
            if (card < total)
            {
                tCashCard_Cash.EditValue = total - card;
            }
            else
            {
                tCashCard_Cash.EditValue = 0;
            }
        }

        private void tCashCard_Cash_EditValueChanged(object sender, EventArgs e)
        {
            double total = double.Parse(tTotal.Text);
            double card = double.Parse(tCashCard_Card.Text);
            double cash = double.Parse(tCashCard_Cash.Text);

            double cashTotal = total - card;
            if (cashTotal < 0)
            {
                NotificationHelpers.Messages.WarningMessage(this, "Kart məbləği yekun məbləğdən böyük olabilməz !", nameof(Helpers.Enums.MessageTitle.Xəbərdarlıq));
                return;
            }
            if (cash >= cashTotal)
            {
                tCashCard_Balance.EditValue = cash - cashTotal;
            }
            else
            {
                tCashCard_Balance.EditValue = 0.ToString();
            }
        }

        private void fPosPay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                if (navigationFrame1.SelectedPage == pageCash)
                {
                    CashPaid();
                }
            }
        }

        private void tCash_Paid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                CashPaid();
            }
        }
    }
}