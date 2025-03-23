using Barcode_Sales.Helpers;
using DevExpress.XtraBars.Navigation;
using System;
using System.Windows.Forms;
using static Barcode_Sales.Helpers.Classes.SaleClasses;

namespace Barcode_Sales.Forms
{
    public partial class fPosPay : DevExpress.XtraEditors.XtraForm
    {
        private SaleData _data;
        public fPosPay(SaleData data)
        {
            InitializeComponent();
            _data = data;
            tTotal.Text = _data.Total.ToString("N2");
            accordionControl1.SelectedElement = bCash;
        }

        private void bCash_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pageCash;
            tCash_Paid.Focus();
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
            _data.IncomingSum = double.Parse(tCash_Paid.Text);

            if (_data.IncomingSum < _data.Total)
            {
                NoticationHelpers.Messages.WarningMessage(this, "Ödənilən məbləğ yekun məbləğdən kiçik olabilməz !", nameof(Enums.MessageTitle.Xəbərdarlıq));
                return;
            }

            if (NKA.Sunmi.Sale(_data))
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void CardPaid()
        {
            _data.Card = double.Parse(tTotal.Text);


            if (NKA.Sunmi.Sale(_data))
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void CashCardPaid()
        {

            _data.Card = double.Parse(tCashCard_Card.Text);
            _data.Cash = _data.Total - _data.Card;
            _data.IncomingSum = double.Parse(tCashCard_Cash.Text);

            if ((_data.IncomingSum + _data.Card) < _data.Total)
            {
                NoticationHelpers.Messages.WarningMessage(this, "Ödənilən məbləğ yekun məbləğdən kiçik olabilməz !", nameof(Enums.MessageTitle.Xəbərdarlıq));
                return;
            }
            else if (_data.Card >= _data.Total)
            {
                NoticationHelpers.Messages.WarningMessage(this, "Ödənilən kart məbləği yekun məbləğdən böyük olabilməz !", nameof(Enums.MessageTitle.Xəbərdarlıq));
                return;
            }
            else if (_data.IncomingSum is 0)
            {
                NoticationHelpers.Messages.WarningMessage(this, "Nağd məbləğ '0' olabilməz !", nameof(Enums.MessageTitle.Xəbərdarlıq));
                return;
            }
            else if (_data.Card is 0)
            {
                NoticationHelpers.Messages.WarningMessage(this, "Kart məbləğ '0' olabilməz !", nameof(Enums.MessageTitle.Xəbərdarlıq));
                return;
            }

            if (NKA.Sunmi.Sale(_data))
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                return;
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
            if (cashTotal <0)
            {
                NoticationHelpers.Messages.WarningMessage(this, "Kart məbləği yekun məbləğdən böyük olabilməz !", nameof(Enums.MessageTitle.Xəbərdarlıq));
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