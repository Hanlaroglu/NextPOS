using DevExpress.XtraEditors;
using Licence.Helpers;
using Licence.Helpers.Implementations;
using Licence.Models;
using Licence.Services;
using Licence.Validations;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace Licence.Forms
{
    public partial class fRegister : DevExpress.XtraEditors.XtraForm
    {
        LocalDateTimeService dateTimeService = new LocalDateTimeService();
        GuidGeneratorService guidGenerator = new GuidGeneratorService();
        public fRegister()
        {
            InitializeComponent();
        }

        private void fRegister_Load(object sender, EventArgs e)
        {
            TerminalDataLoad();
            tDate.Text = dateTimeService.CurrentString;
            tLicenceExpireDate.Text = dateTimeService.Current.AddMonths(1).ToString("dd.MM.yyyy");
            tLicenceKey.Text = guidGenerator.CurrentString;
        }

        private void TerminalDataLoad()
        {
            var data = Terminals.SeedTerminalData();
            lookTerminal.Properties.DataSource = data;
            lookTerminal.Properties.DisplayMember = "CompanyModel";
            lookTerminal.Properties.ValueMember = "Id";
            lookTerminal.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Company"));
            lookTerminal.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Model"));
        }

        private void tLicenceKey_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Tag.ToString())
            {
                case "Generate":
                    tLicenceKey.Text = guidGenerator.CurrentString;
                    break;
                case "Copy": Clipboard.SetText(tLicenceKey.Text);
                    break;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Add();
        }

        private async void Add()
        {
            if (!FormHelpers.IsValidDate(tDate.Text))
            {
                XtraMessageBox.Show("Tarix düzgün daxil edilmədi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Client client = new Client
            {
                CustomerName = tCustomerName.Text.Trim(),
                CompanyName = tCompanyName.Text.Trim(),
                Voen = tVoen.Text.Trim(),
                CompanyCode = tCompanyCode.Text.Trim(),
                Address = tAddress.Text.Trim(),
                Phone = tPhone.Text.Trim(),
                RegisterDate = Convert.ToDateTime(tDate.Text),
                TerminalModel = lookTerminal.Text,
                TerminalSerialNumber = tSerialNumber.Text.Trim(),
                IsActive = true,
                LicenceExpireDate = Convert.ToDateTime(tDate.Text).AddMonths(1),
                Version = Application.ProductVersion,
            };

            var validator = new ClientValidation();
            var validateResult = validator.Validate(client);

            if (!validateResult.IsValid)
            {
                foreach (var error in validateResult.Errors)
                {
                    XtraMessageBox.Show(error.ErrorMessage, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string json = JsonConvert.SerializeObject(client, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            bool IsSuccess = await LicenseService.Instance.Create(json, tLicenceKey.Text.Trim());
            if (IsSuccess)
            {
                Registry.CurrentUser.CreateSubKey(LicenseService.path).SetValue("ProductID", tLicenceKey.Text.Trim());
                Registry.CurrentUser.CreateSubKey(LicenseService.path).SetValue("CustomerName", client.CustomerName);
                Registry.CurrentUser.CreateSubKey(LicenseService.path).SetValue("CompanyName", client.CompanyName);
                Registry.CurrentUser.CreateSubKey(LicenseService.path).SetValue("Voen", client.Voen);
                Registry.CurrentUser.CreateSubKey(LicenseService.path).SetValue("Address", client.Address);
                this.Close();
            }
        }
    }
}