using Barcode_Sales.Barcode.Sales.UI.Kassa;
using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
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
using static Barcode_Sales.Helpers.Enums;

namespace Barcode_Sales.Forms
{
    public partial class fPosSalesControlPanel : DevExpress.XtraEditors.XtraForm
    {
        static ITerminalOperation terminalOperation = new TerminalManager();
        public static readonly Terminals _terminals = terminalOperation.GetIpAddress();
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
                    double _amount = f.Amount;

                    KassaOperator kassa = (KassaOperator)Enum.Parse(typeof(KassaOperator), _terminals.Name);
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
                    ChangeType = Enums.PosChangeType.Withdraw,
                });
                if (f.ShowDialog() is DialogResult.OK)
                {
                    double _amount = f.Amount;

                    KassaOperator kassa = (KassaOperator)Enum.Parse(typeof(KassaOperator), _terminals.Name);
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
                KassaOperator kassa = (KassaOperator)Enum.Parse(typeof(KassaOperator), _terminals.Name);
                switch (kassa)
                {
                    case KassaOperator.CASPOS:
                        NKA.Sunmi.GetShiftStatus(new NKA.DTOs.NkaDto.ShiftDto
                        {
                            IpAddress = _terminals.IpAddress,
                            Cashier = CommonData.CURRENT_USER.NameSurname
                        });
                        break;
                    case KassaOperator.OMNITECH:
                        NKA.Omnitech.GetShiftStatus(new NKA.DTOs.NkaDto.ShiftDto
                        {
                            IpAddress = _terminals.IpAddress
                        });
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

        private void bCloseShift_Click(object sender, EventArgs e)
        {
            if (_terminals != null)
            {
                KassaOperator kassa = (KassaOperator)Enum.Parse(typeof(KassaOperator), _terminals.Name);
                switch (kassa)
                {
                    case KassaOperator.CASPOS:
                        NKA.Sunmi.CloseShift(new NKA.DTOs.NkaDto.ShiftDto
                        {
                            IpAddress = _terminals.IpAddress
                        });
                        break;
                    case KassaOperator.OMNITECH:
                        NKA.Omnitech.CloseShift(new NKA.DTOs.NkaDto.ShiftDto
                        {
                            IpAddress = _terminals.IpAddress,
                            
                        });
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