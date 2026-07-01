using Barcode_Sales.Services.CacheServices;
using Barcode_Sales.Terminals.DTOs;
using Barcode_Sales.Terminals.Omnitech;
using System;
using System.Linq;
using System.Windows.Forms;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Barcode_Sales.Services.Interfaces;
using Barcode_Sales.Services;
using Barcode_Sales.Terminals;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using DevExpress.XtraLayout.Utils;

namespace Barcode_Sales.Forms
{
    public partial class fPosPay : DevExpress.XtraEditors.XtraForm
    {
        IProductOperation productOperation = new ProductManager();

        private readonly IPosSaleService _saleService;
        private PosSaleDto _data;

        public fPosPay(PosSaleDto data)
        {
            InitializeComponent();
            _data = data;
            _saleService = new PosSaleService();
        }

        private void fPosPay_Load(object sender, EventArgs e)
        {
            tTotal.Text = _data.Items.Sum(x => x.Sum).ToString("F2");
            accordionControl1.SelectedElement = bCash;
            bCash_Click(sender, e);
            this.tCash_Paid.SelectAll();
            this.tCash_Paid.Focus();
        }

        private void bCash_Click(object sender, EventArgs e)
        {
            tCash_Paid.Text = _data.Items.Sum(x => x.Sum).ToString("N2");
            layoutItemBalance.Visibility = LayoutVisibility.Always;
            layoutItemCashPaid.Visibility = LayoutVisibility.Always;
            layoutItemCashCard_Card.Visibility = LayoutVisibility.Never;
            layoutItemCashCard_Cash.Visibility = LayoutVisibility.Never;
        }

        private void bCard_Click(object sender, EventArgs e)
        {
            layoutItemBalance.Visibility = LayoutVisibility.Never;
            layoutItemCashPaid.Visibility = LayoutVisibility.Never;
            layoutItemCashCard_Card.Visibility = LayoutVisibility.Never;
            layoutItemCashCard_Cash.Visibility = LayoutVisibility.Never;
        }

        private void bCashCard_Click(object sender, EventArgs e)
        {
            layoutItemCashCard_Card.Visibility = LayoutVisibility.Always;
            layoutItemCashCard_Cash.Visibility = LayoutVisibility.Always;
            layoutItemBalance.Visibility = LayoutVisibility.Always;

            layoutItemCashPaid.Visibility = LayoutVisibility.Never;
        }

        private void bAdvance_Click(object sender, EventArgs e)
        {

        }

        private void bFree_Click(object sender, EventArgs e)
        {

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
                tBalance.Text = balance.ToString("N2");
            else
                tBalance.Text = 0.ToString("N2");
        }

        private void bPay_Click(object sender, EventArgs e)
        {
            if (accordionControl1.SelectedElement == bCash)
                CashPaid();
            else if (accordionControl1.SelectedElement == bCard)
                CardPaid();
            else if (accordionControl1.SelectedElement == bCashCard)
                CashCardPaid();
        }

        private async void CashPaid()
        {
            fPosSales _form = Application.OpenForms.OfType<fPosSales>().FirstOrDefault();

            if (TerminalCacheService.Terminal != null)
            {
                _data.Cash = _data.Items.Sum(x => x.Sum);
                _data.Card = 0;
                _data.IncomingSum = decimal.Parse(tCash_Paid.Text);

                if (_data.IncomingSum < _data.Items.Sum(x => x.Sum))
                {
                    NotificationHelpers.Messages.WarningMessage(this, "Ödənilən məbləğ yekun məbləğdən kiçik olabilməz !", nameof(Helpers.Enums.MessageTitle.Xəbərdarlıq));
                    return;
                }

                if (!chCashTaxPrint.Checked)
                {
                    int saleId = await _saleService.CompleteSaleAsync(_data, null);

                    if (saleId == -1)
                    {
                        NotificationHelpers.Messages.ErrorMessage(this, "Satış bazaya əlavə edilərkən xəta yarandı.");
                        return;
                    }

                    UpdateProducts(_data.Items);
                    NotificationHelpers.Messages.SuccessMessage(_form, "Satış uğurla tamamlandı");
                    DialogResult = DialogResult.OK;
                    return;
                }

                var terminal = (Helpers.Enums.Terminal)Enum.Parse(typeof(Helpers.Enums.Terminal), TerminalCacheService.Terminal.Name);
                switch (terminal)
                {
                    case Helpers.Enums.Terminal.OMNİTECH:
                        OmnnitechTerminal omnitech = new OmnnitechTerminal(TerminalCacheService.Terminal.IpAddress);

                        var result = await omnitech.Sale(_data);
                        if (result.Success)
                        {
                            UpdateProducts(_data.Items);
                            NotificationHelpers.Messages.SuccessMessage(_form, result.Message);
                            DialogResult = DialogResult.OK;
                        }
                        else
                            NotificationHelpers.Messages.ErrorMessage(_form, result.Message);
                        break;
                }
            }
        }

        private async void UpdateProducts(BindingList<PosSaleItemDto> items)
        {
            List<Products> products = new List<Products>();
            foreach (var item in items)
            {
                var product = await productOperation.Get(x => x.Id == item.Id);
                product.Quantity -= item.Quantity;
                products.Add(product);
            }

            var result = await productOperation.Update(products, x => x.Quantity);
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
                    case Helpers.Enums.Terminal.CASPOS:
                        //if (NKA.Sunmi.Sale(_data))
                        //    DialogResult = DialogResult.OK;
                        break;
                    case Helpers.Enums.Terminal.OMNİTECH:
                        OmnnitechTerminal omnitech = new OmnnitechTerminal(TerminalCacheService.Terminal.IpAddress);

                        var result = await omnitech.Sale(_data);
                        fPosSales _form = Application.OpenForms.OfType<fPosSales>().FirstOrDefault();
                        if (result.Success)
                        {
                            UpdateProducts(_data.Items);
                            NotificationHelpers.Messages.SuccessMessage(_form, result.Message);
                            DialogResult = DialogResult.OK;
                        }
                        else
                            NotificationHelpers.Messages.ErrorMessage(_form, result.Message);
                        break;
                    case Helpers.Enums.Terminal.AZSMART:
                        //if (NKA.AzSmart.Sale(_data))
                        //    DialogResult = DialogResult.OK;
                        break;
                    case Helpers.Enums.Terminal.NBA:
                        break;
                    case Helpers.Enums.Terminal.DATAPAY:
                        break;
                    case Helpers.Enums.Terminal.ONECLICK:
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
                    case Helpers.Enums.Terminal.OMNİTECH:
                        OmnnitechTerminal omnitech = new OmnnitechTerminal(TerminalCacheService.Terminal.IpAddress);

                        var result = await omnitech.Sale(_data);
                        fPosSales _form = Application.OpenForms.OfType<fPosSales>().FirstOrDefault();
                        if (result.Success)
                        {
                            UpdateProducts(_data.Items);
                            NotificationHelpers.Messages.SuccessMessage(_form, result.Message);
                            DialogResult = DialogResult.OK;
                        }
                        else
                            NotificationHelpers.Messages.ErrorMessage(_form, result.Message);
                        break;
                }
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
                if (accordionControl1.SelectedElement == bCash)
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