using Barcode_Sales.Helpers;
using System;
using System.Windows.Forms;
using Barcode_Sales.Terminals.Omnitech;
using static Barcode_Sales.Helpers.Enums;
using Enums = Barcode_Sales.Helpers.Enums;

namespace Barcode_Sales.Forms
{
    public partial class fPosSalesControlPanel : DevExpress.XtraEditors.XtraForm
    {

        private static readonly Terminal _terminals = CommonData.terminal;
        KassaOperator kassa = (KassaOperator)Enum.Parse(typeof(KassaOperator), _terminals.Name);

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
            if (_terminals != null)
            {
                this.Close();
                fPriceChange f = new fPriceChange(new Helpers.Classes.SaleClasses.PosChangeType
                {
                    ChangeType = Enums.PosChangeType.Deposit,
                });
                if (f.ShowDialog() is DialogResult.OK)
                {
                    decimal _amount = f.Amount;

                    switch (kassa)
                    {
                        case KassaOperator.CASPOS:
                            NKA.Sunmi.Deposit(new NKA.DTOs.NkaDto.DepositDto
                            {
                                IpAddress = _terminals.IpAddress,
                                Amount = _amount,
                                Cashier = CommonData.CURRENT_USER?.NameSurname,
                            });
                            break;
                        case KassaOperator.OMNITECH:
                            break;
                        case KassaOperator.AZSMART:
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
        }

        private void bWithdraw_Click(object sender, EventArgs e)
        {
            if (_terminals != null)
            {
                this.Close();
                fPriceChange f = new fPriceChange(new Helpers.Classes.SaleClasses.PosChangeType
                {
                    ChangeType = PosChangeType.Withdraw,
                });
                if (f.ShowDialog() is DialogResult.OK)
                {
                    decimal _amount = f.Amount;

                    switch (kassa)
                    {
                        case KassaOperator.CASPOS:
                            NKA.Sunmi.Withdraw(new NKA.DTOs.NkaDto.DepositDto
                            {
                                IpAddress = _terminals.IpAddress,
                                Amount = _amount,
                                Cashier = CommonData.CURRENT_USER?.NameSurname,
                            });
                            break;
                        case KassaOperator.OMNITECH:
                            break;
                        case KassaOperator.AZSMART:
                            break;
                        case KassaOperator.NBA:
                            break;
                        case KassaOperator.DATAPAY:
                            break;
                        case KassaOperator.ONECLICK:
                            break;
                        case KassaOperator.XPRINTER:
                            break;
                    }
                }
            }
        }

        private void bShift_Click(object sender, EventArgs e)
        {
            if (_terminals != null)
            {
                NKA.DTOs.NkaDto.ShiftDto item = new NKA.DTOs.NkaDto.ShiftDto
                {
                    Cashier = CommonData.CURRENT_USER.NameSurname,
                    IpAddress = _terminals.IpAddress,
                    MerchantId = _terminals.MerchantId,
                };

                switch (kassa)
                {
                    case KassaOperator.CASPOS:
                        NKA.Sunmi.GetShiftStatus(item);
                        break;
                    case KassaOperator.OMNITECH:
                        OmnnitechTerminal omnnitech = new OmnnitechTerminal();
                        var result = omnnitech.Login(_terminals.IpAddress);
                        break;
                    case KassaOperator.AZSMART:
                        NKA.AzSmart.GetShiftStatus(item);
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

        private void bCloseShift_Click(object sender, EventArgs e)
        {
            if (_terminals != null)
            {
                NKA.DTOs.NkaDto.ShiftDto item = new NKA.DTOs.NkaDto.ShiftDto
                {
                    Cashier = CommonData.CURRENT_USER.NameSurname,
                    IpAddress = _terminals.IpAddress,
                    MerchantId = _terminals.MerchantId,
                };

                switch (kassa)
                {
                    case KassaOperator.CASPOS:
                        NKA.Sunmi.CloseShift(item);
                        break;
                    case KassaOperator.OMNITECH:
                        //NKA.Omnitech.CloseShift(item);
                        break;
                    case KassaOperator.AZSMART:
                        NKA.AzSmart.CloseShift(item);
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

        private void bReport_Click(object sender, EventArgs e)
        {

        }

        private void bKassaEmeliyyatlari_Click(object sender, EventArgs e)
        {

        }

        private void bCustomer_Click(object sender, EventArgs e)
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
    }
}