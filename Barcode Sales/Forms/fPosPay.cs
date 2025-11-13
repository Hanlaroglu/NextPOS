using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System;
using System.Windows.Forms;
using static Barcode_Sales.Helpers.Classes.SaleClasses;
using static Barcode_Sales.Helpers.Enums;

namespace Barcode_Sales.Forms
{
    public partial class fPosPay : DevExpress.XtraEditors.XtraForm
    {
        private SaleData _data;
        private readonly Terminals _terminals = CommonData.terminal;
        public fPosPay(SaleData data)
        {
            InitializeComponent();
            _data = data;
          
        }

        private void fPosPay_Load(object sender, EventArgs e)
        {
            tTotal.Text = _data.Total.ToString("N2");
            bCash_Click(sender,null);
        }

        private void bCash_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pageCash;
            this.tCash_Paid.Focus();
            tCash_Paid.Text = _data.Total.ToString("N2");

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
            double Paid = Convert.ToDouble(tCash_Paid.Text);
            double balance = Paid - _data.Total;
            if (balance > 0)
            {
                tCash_Balance.Text = balance.ToString("N2");
            }
            else
            {
                tCash_Balance.Text = 0.ToString("N2");
            }
        }

        private void bPay_Click(object sender, EventArgs e)
        {
            if (navigationFrame1.SelectedPage == pageCash)
            {
                CashPaid();
            }
            else if (navigationFrame1.SelectedPage == pageCard)
            {
                CardPaid();
            }
            else if (navigationFrame1.SelectedPage == pageCashCard)
            {
                CashCardPaid();
            }

        }

        private void CashPaid()
        {
            if (_terminals != null)
            {
                _data.IpAddress = _terminals.IpAddress;
                _data.Cash = _data.Total;
                _data.Card = 0;
                _data.IncomingSum = double.Parse(tCash_Paid.Text);

                if (_data.IncomingSum < _data.Total)
                {
                    NotificationHelpers.Messages.WarningMessage(this, "Ödənilən məbləğ yekun məbləğdən kiçik olabilməz !", nameof(Enums.MessageTitle.Xəbərdarlıq));
                    return;
                }


                KassaOperator kassa = (KassaOperator)Enum.Parse(typeof(KassaOperator), _terminals.Name);
                switch (kassa)
                {
                    case KassaOperator.CASPOS:
                        if (NKA.Sunmi.Sale(_data))
                            DialogResult = DialogResult.OK;
                        break;
                    case KassaOperator.OMNITECH:
                        if (NKA.Omnitech.Sale(_data))
                            DialogResult = DialogResult.OK;
                        break;
                    case KassaOperator.AZSMART:
                        if (NKA.AzSmart.Sale(_data))
                            DialogResult = DialogResult.OK;
                        break;
                    case KassaOperator.NBA:
                        break;
                    case KassaOperator.DATAPAY:
                        break;
                    case KassaOperator.ONECLICK:
                        break;
                }
            }
        }

        private void CardPaid()
        {
            _data.IpAddress = _terminals.IpAddress;
            _data.Card = double.Parse(tTotal.Text);
            _data.Cash = 0;

            if (_terminals != null)
            {
                KassaOperator kassa = (KassaOperator)Enum.Parse(typeof(KassaOperator), _terminals.Name);
                switch (kassa)
                {
                    case KassaOperator.CASPOS:
                        if (NKA.Sunmi.Sale(_data))
                            DialogResult = DialogResult.OK;
                        break;
                    case KassaOperator.OMNITECH:
                        if (NKA.Omnitech.Sale(_data))
                            DialogResult = DialogResult.OK;
                        break;
                    case KassaOperator.AZSMART:
                        if (NKA.AzSmart.Sale(_data))
                            DialogResult = DialogResult.OK;
                        break;
                    case KassaOperator.NBA:
                        break;
                    case KassaOperator.DATAPAY:
                        break;
                    case KassaOperator.ONECLICK:
                        break;
                }
            }
        }

        private void CashCardPaid()
        {
            _data.IpAddress = _terminals.IpAddress;
            _data.Card = double.Parse(tCashCard_Card.Text);
            _data.Cash = _data.Total - _data.Card;
            _data.IncomingSum = double.Parse(tCashCard_Cash.Text);

            if ((_data.IncomingSum + _data.Card) < _data.Total)
            {
                NotificationHelpers.Messages.WarningMessage(this, "Ödənilən məbləğ yekun məbləğdən kiçik olabilməz !", nameof(Enums.MessageTitle.Xəbərdarlıq));
                return;
            }
            else if (_data.Card >= _data.Total)
            {
                NotificationHelpers.Messages.WarningMessage(this, "Ödənilən kart məbləği yekun məbləğdən böyük olabilməz !", nameof(Enums.MessageTitle.Xəbərdarlıq));
                return;
            }
            else if (_data.IncomingSum is 0)
            {
                NotificationHelpers.Messages.WarningMessage(this, "Nağd məbləğ '0' olabilməz !", nameof(Enums.MessageTitle.Xəbərdarlıq));
                return;
            }
            else if (_data.Card is 0)
            {
                NotificationHelpers.Messages.WarningMessage(this, "Kart məbləğ '0' olabilməz !", nameof(Enums.MessageTitle.Xəbərdarlıq));
                return;
            }

            if (_terminals != null)
            {
                KassaOperator kassa = (KassaOperator)Enum.Parse(typeof(KassaOperator), _terminals.Name);
                switch (kassa)
                {
                    case KassaOperator.CASPOS:
                        if (NKA.Sunmi.Sale(_data))
                            DialogResult = DialogResult.OK;
                        break;
                    case KassaOperator.OMNITECH:
                        if (NKA.Omnitech.Sale(_data))
                            DialogResult = DialogResult.OK;
                        break;
                    case KassaOperator.AZSMART:
                        if (NKA.AzSmart.Sale(_data))
                            DialogResult = DialogResult.OK;
                        break;
                    case KassaOperator.NBA:
                        break;
                    case KassaOperator.DATAPAY:
                        break;
                    case KassaOperator.ONECLICK:
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
                NotificationHelpers.Messages.WarningMessage(this, "Kart məbləği yekun məbləğdən böyük olabilməz !", nameof(Enums.MessageTitle.Xəbərdarlıq));
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