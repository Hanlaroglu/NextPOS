using Barcode_Sales.Services.CacheServices;
using Barcode_Sales.Terminals.Omnitech;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using System;
using System.Windows.Forms;
using static Barcode_Sales.Helpers.Enums;
using Enums = Barcode_Sales.Helpers.Enums;

namespace Barcode_Sales.Forms
{
    public partial class fPosSalesControlPanel : DevExpress.XtraEditors.XtraForm
    {
        Enums.Terminal terminal = (Enums.Terminal)Enum.Parse(typeof(Enums.Terminal), TerminalCacheService.Terminal.Name);

        public fPosSalesControlPanel()
        {
            InitializeComponent();
        }

        private void bRefund_Click(object sender, EventArgs e)
        {
            fPosRollback f = new fPosRollback();
            this.Close();
            if (f.ShowDialog() is DialogResult.OK)
            {
                Close();
            }
        }

        private void bDeposit_Click(object sender, EventArgs e)
        {
            if (TerminalCacheService.Terminal != null)
            {
                fPriceChange f = new fPriceChange(new DTOs.PosChangeType
                {
                    ChangeType = Enums.PosChangeType.Deposit,
                });
                if (f.ShowDialog() is DialogResult.OK)
                {
                    decimal _amount = f.Amount;

                    switch (terminal)
                    {
                        case Enums.Terminal.OMNİTECH:
                            OmnnitechTerminal omnnitech = new OmnnitechTerminal(TerminalCacheService.Terminal.IpAddress);

                            var result = omnnitech.Deposit(_amount);
                            if (result.Success)
                                NotificationHelpers.Messages.SuccessMessage(this, result.Message);
                            else
                                NotificationHelpers.Messages.ErrorMessage(this, result.Message);
                            break;
                    }
                }
            }
        }

        private void bWithdraw_Click(object sender, EventArgs e)
        {
            if (TerminalCacheService.Terminal != null)
            {
                fPriceChange f = new fPriceChange(new DTOs.PosChangeType
                {
                    ChangeType = PosChangeType.Withdraw,
                });
                if (f.ShowDialog() is DialogResult.OK)
                {
                    decimal _amount = f.Amount;

                    switch (terminal)
                    {
                        case Enums.Terminal.OMNİTECH:
                            OmnnitechTerminal omnnitech = new OmnnitechTerminal(TerminalCacheService.Terminal.IpAddress);

                            var result = omnnitech.Withdraw(_amount);
                            if (result.Success)
                                NotificationHelpers.Messages.SuccessMessage(this, result.Message);
                            else
                                NotificationHelpers.Messages.ErrorMessage(this, result.Message);
                            break;
                    }
                }
            }
        }

        private void bShift_Click(object sender, EventArgs e)
        {
            if (TerminalCacheService.Terminal != null)
            {
                NKA.DTOs.NkaDto.ShiftDto item = new NKA.DTOs.NkaDto.ShiftDto
                {
                    Cashier = UserCacheService.User.NameSurname,
                    IpAddress = TerminalCacheService.Terminal.IpAddress,
                    MerchantId = TerminalCacheService.Terminal.MerchantId,
                };

                switch (terminal)
                {
                    case Enums.Terminal.OMNİTECH:
                        OmnnitechTerminal omnnitech = new OmnnitechTerminal(TerminalCacheService.Terminal.IpAddress);

                        var result = omnnitech.GetShiftStatus();
                        if (result.Success)
                            NotificationHelpers.Messages.InfoMessage(this, result.Message);
                        else
                            NotificationHelpers.Messages.ErrorMessage(this, result.Message);
                        break;
                }
            }
         }

        private void bCloseShift_Click(object sender, EventArgs e)
        {
            if (TerminalCacheService.Terminal != null)
            {
                NKA.DTOs.NkaDto.ShiftDto item = new NKA.DTOs.NkaDto.ShiftDto
                {
                    Cashier = UserCacheService.User.NameSurname,
                    IpAddress = TerminalCacheService.Terminal.IpAddress,
                    MerchantId = TerminalCacheService.Terminal.MerchantId,
                };

                switch (terminal)
                {
                    case Enums.Terminal.OMNİTECH:
                        OmnnitechTerminal omnnitech = new OmnnitechTerminal(TerminalCacheService.Terminal.IpAddress);

                        var result = omnnitech.CloseShift();
                        if (result.Success)
                            NotificationHelpers.Messages.SuccessMessage(this, result.Message);
                        else
                            NotificationHelpers.Messages.ErrorMessage(this, result.Message);
                        break;
                }
            }
        }

        private void bReport_Click(object sender, EventArgs e)
        {

        }

        private void bKassaEmeliyyatlari_Click(object sender, EventArgs e)
        {

        }

        private void bDevices_Click(object sender, EventArgs e)
        {

        }

        private void bCashDrawerOpen_Click(object sender, EventArgs e)
        {

        }

        private void bSupport_Click(object sender, EventArgs e)
        {

        }

        private void bXReport_Click(object sender, EventArgs e)
        {
            if (TerminalCacheService.Terminal != null)
            {
                NKA.DTOs.NkaDto.ShiftDto item = new NKA.DTOs.NkaDto.ShiftDto
                {
                    Cashier = UserCacheService.User.NameSurname,
                    IpAddress = TerminalCacheService.Terminal.IpAddress,
                    MerchantId = TerminalCacheService.Terminal.MerchantId,
                };

                switch (terminal)
                {
                    case Enums.Terminal.OMNİTECH:
                        OmnnitechTerminal omnnitech = new OmnnitechTerminal(TerminalCacheService.Terminal.IpAddress);

                        var result = omnnitech.XReport();
                        if (result.Success)
                            NotificationHelpers.Messages.SuccessMessage(this, result.Message);
                        else
                            NotificationHelpers.Messages.ErrorMessage(this, result.Message);
                        break;
                }
            }
        }

        private void bAnydesk_Click(object sender, EventArgs e)
        {

        }
    }
}