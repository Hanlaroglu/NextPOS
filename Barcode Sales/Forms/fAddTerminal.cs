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

namespace Barcode_Sales.Forms
{
    public partial class fAddTerminal : DevExpress.XtraEditors.XtraForm
    {
        IStoreOperation storeOperation = new StoreManager();
        IUserOperation userOperation = new UserManager();
        ITerminalOperation terminalOperation = new TerminalManager();
        public fAddTerminal()
        {
            InitializeComponent();
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
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Save();
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

        private async void Save()
        {
            var ipAdress = $"{tIpAddress.Text.TrimStart().Trim()}:{tTerminalPort.Text.TrimStart().Trim()}";
            var storeId = Convert.ToInt32(lookStores.EditValue.ToString());

            var terminal = new Terminal
            {
                Name = lookTerminals.Text,
                IpAddress = ipAdress,
                MerchantId = tMerchantId.Text.TrimStart().Trim(),
                StoreID = storeId,
                Status = true,
                UserId = UserCacheService.User.Id,
            };

            var validator = ValidationHelpers.ValidateMessage(terminal, new TerminalValidation(), this);

            if (!validator.IsValid)
                return;

            if (string.IsNullOrWhiteSpace(tTerminalPort.Text))
            {
                NotificationHelpers.Messages.WarningMessage(this, "Port nömrəsi daxil edilmədi");
                return;
            }

            var result = await terminalOperation.Add(terminal);
            if (result > 0)
            {
                NotificationHelpers.Messages.SuccessMessage(this,"Terminal uğurla əlavə edildi");
                Close();
            }
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