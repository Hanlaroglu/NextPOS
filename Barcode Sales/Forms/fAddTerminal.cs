using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Helpers;
using DevExpress.XtraLayout.Utils;
using System.Net;
using Barcode_Sales.Services.CacheServices;
using Barcode_Sales.Validations;
using static Barcode_Sales.Helpers.Enums;

namespace Barcode_Sales.Forms
{
    public partial class fAddTerminal : DevExpress.XtraEditors.XtraForm
    {
        IStoreOperation storeOperation = new StoreManager();
        IUserOperation userOperation = new UserManager();
        ITerminalOperation terminalOperation = new TerminalManager();

        private Enums.Operation _operation { get; }
        private Terminal _terminal { get; set; }
        public fAddTerminal(Enums.Operation operation, Terminal terminal = null)
        {
            InitializeComponent();
            _operation = operation;
            _terminal = terminal;
        }

        /* Fliallarıın əlavəsi - OK
         * Kassirlərin əlavəsi - OK
         * E-Kassa siyahısının əlavəsi - OK
         * Bank əlavəsi üçün db dən bank portu bölməsini əlavə et
         * Bank varsa bank bölməsinin visible true olsun
         * Dashboardda Terminallara daxil olduqda pageNavigationda Terminallar səhifəsinə keçsin. (Digərlərində olduğu kimi)
         */

        private async void fAddTerminal_Shown(object sender, EventArgs e)
        {
            GetTerminals();
            GetBankTerminals();
            await GetUsers();
            await GetStores();
            GetTerminal();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (_operation == Enums.Operation.Add)
                Add();
            else
                Edit();
        }

        private void GetTerminal()
        {
            if (_terminal != null)
            {
                lookStores.EditValue = _terminal.StoreID;
                lookUser.EditValue = _terminal.UserId;
                lookTerminals.Text = _terminal.Name;
                tIpAddress.Text = _terminal.IpAddress.Split(':')[0];
                tTerminalPort.Text = _terminal.IpAddress.Split(':')[1];
                tMerchantId.Text = _terminal.MerchantId;
                lookBanks.Text = _terminal.BankName;
                tBankPort.Text = _terminal.BankPort;
            }
        }

        private void GetTerminals()
        {
            var kassa = Enum.GetValues(typeof(Enums.Terminal))
                .Cast<Enums.Terminal>()
                .ToDictionary(e => e, e => EnumExtensions.GetEnumDescription(e));

            FormHelpers.ControlLoad(new BindingSource(kassa, null), lookTerminals, "Value", "Key");
        }

        private void GetBankTerminals()
        {
            var kassa = Enum.GetValues(typeof(Enums.BankTerminal))
                .Cast<Enums.BankTerminal>()
                .ToDictionary(e => e, e => EnumExtensions.GetEnumDescription(e));

            FormHelpers.ControlLoad(new BindingSource(kassa, null), lookBanks, "Value", "Key");
        }

        private async Task GetUsers()
        {
            var data = await userOperation.Where(x => true)
                .Select(x => new
                {
                    x.NameSurname,
                    x.Id
                })
                .ToListAsync();

            FormHelpers.ControlLoad(data, lookUser, "NameSurname");
        }

        private async Task GetStores()
        {
            var data = await storeOperation.ToListAsync();
            FormHelpers.ControlLoad(data, lookStores);
        }

        private async void Add()
        {
            var ipAdress = $"{tIpAddress.Text.TrimStart().Trim()}:{tTerminalPort.Text.TrimStart().Trim()}";
            var storeId = Convert.ToInt32(lookStores.EditValue.ToString());

            _terminal = new Terminal
            {
                Name = lookTerminals.Text,
                IpAddress = ipAdress,
                MerchantId = tMerchantId.Text.TrimStart().Trim(),
                StoreID = storeId,
                BankName = lookBanks.Text,
                BankPort = tBankPort.Text.Trim(),
                IsStatus = true,
                UserId = UserCacheService.User.Id,
                IsDeleted = false
            };

            var validator = ValidationHelpers.ValidateMessage(_terminal, new TerminalValidation(), this);

            if (!validator.IsValid)
                return;

            if (string.IsNullOrWhiteSpace(tTerminalPort.Text))
            {
                NotificationHelpers.Messages.WarningMessage(this, "Port nömrəsi daxil edilmədi");
                return;
            }

            var result = await terminalOperation.Add(_terminal);
            if (result > 0)
            {
                NotificationHelpers.Messages.SuccessMessage(this, "Terminal uğurla əlavə edildi");
                Clear();
            }
        }

        private async void Edit()
        {
            var ipAdress = $"{tIpAddress.Text.TrimStart().Trim()}:{tTerminalPort.Text.TrimStart().Trim()}";

            _terminal.Name = lookTerminals.Text;
            _terminal.IpAddress = ipAdress;
            _terminal.MerchantId = tMerchantId.Text.Trim();
            _terminal.BankName = lookBanks.Text;
            _terminal.BankPort = tBankPort.Text.Trim();

            var validator = ValidationHelpers.ValidateMessage(_terminal, new TerminalValidation(), this);

            if (!validator.IsValid)
                return;

            if (string.IsNullOrWhiteSpace(tTerminalPort.Text))
            {
                NotificationHelpers.Messages.WarningMessage(this, "Port nömrəsi daxil edilmədi");
                return;
            }


            await terminalOperation.Update(_terminal,
                x => x.Name,
                x => x.IpAddress,
                x => x.MerchantId,
                x => x.BankName,
                x => x.BankPort);

            Close();
        }

        private void Clear()
        {
            lookStores.EditValue = null;
            lookTerminals.EditValue = null;
            lookBanks.EditValue = null;
            lookUser.EditValue = null;
            tIpAddress.Clear();
            tTerminalPort.Clear();
            tBankPort.Clear();
            tMerchantId.Clear();
        }

        private void lookTerminals_TextChanged(object sender, EventArgs e)
        {
            if (lookTerminals.Text == "AZSMART")
            {
                layoutControlMerchantId.Visibility = LayoutVisibility.Always;
                tMerchantId.Clear();
            }
            else
            {
                layoutControlMerchantId.Visibility = LayoutVisibility.Never;
                tMerchantId.Clear();
            }
        }

        private void chBankStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (!chBankStatus.Checked)
            {
                tBankPort.Clear();
                lookBanks.Clear();
                layoutControlGroupBanks.Visibility = LayoutVisibility.Always;
            }
            else
                layoutControlGroupBanks.Visibility = LayoutVisibility.Never;
        }
    }
}