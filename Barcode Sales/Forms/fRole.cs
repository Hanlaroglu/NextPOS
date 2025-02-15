using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using System;
using System.Linq;

namespace Barcode_Sales.Forms
{
    public partial class fRole : FormBase
    {
        IRoleOperation roleOperation = new RoleManager();
        private Enums.Operation Operation { get; }
        private Roles Role { get; set; }

        public fRole(Enums.Operation _operation, Roles _roles)
        {
            InitializeComponent();
            Operation = _operation;
            Role = _roles;
        }

        private void fRole_Load(object sender, EventArgs e)
        {
            if (Operation is Enums.Operation.Edit)
            {
                RoleDataLoad();
                tRoleName.ReadOnly = true;
                userSaveFooter1.SaveButtonText = Enums.GetEnumDescription(Operation);
            }
        }

        void Clear()
        {
            tRoleName.Text = null;
            chPosSales.Checked = false;
            chPosReturn.Checked = false;
            chBank.Checked = false;
            chReport.Checked = false;
            chSettings.Checked = false;
            chUsers.Checked = false;
            chCredit.Checked = false;
            chMoneyBox.Checked = false;
            tRoleName.Focus();
        }

        void RoleDataLoad()
        {
            tRoleName.Text = Role.RoleName;
            chPosSales.Checked = (bool)Role.PosSales;
            chPosReturn.Checked = (bool)Role.PosReturn;
            chBank.Checked = (bool)Role.Bank;
            chReport.Checked = (bool)Role.Reports;
            chSettings.Checked = (bool)Role.Settings;
            chUsers.Checked = (bool)Role.User;
            chCredit.Checked = (bool)Role.Credit;
            chMoneyBox.Checked = (bool)Role.MoneyBox;
        }

        void RoleAdd()
        {
            bool uniqueData = roleOperation.Where(x=> x.RoleName.ToLower() == tRoleName.Text.Trim().ToLower()).Any();
            if (!uniqueData)
            {
                Message(RoleValidation.ExistingRole, NextPOS.UserControls.fMessage.enmType.Warning);
                return;
            }

            Role = new Roles();
            Role.RoleName = tRoleName.Text;
            Role.PosSales = chPosSales.Checked;
            Role.PosReturn = chPosReturn.Checked;
            Role.Bank = chBank.Checked;
            Role.Reports = chReport.Checked;
            Role.Settings = chSettings.Checked;
            Role.User = chUsers.Checked;
            Role.Credit = chCredit.Checked;
            Role.MoneyBox = chMoneyBox.Checked;
            Role.Admin = xtraTabControl1.SelectedTabPage.Name == "tabAdmin";
            Role.Cashier = xtraTabControl1.SelectedTabPage.Name == "tabCashier";

            var validator = ValidationHelpers.ValidateMessage(Role, new RoleValidation(), this);

            if (!validator.IsValid)
            {
                return;
            }

            roleOperation.Add(Role);
            Clear();
        }

        void RoleEdit()
        {
            Role.PosSales = chPosSales.Checked;
            Role.PosReturn = chPosReturn.Checked;
            Role.Bank = chBank.Checked;
            Role.Reports = chReport.Checked;
            Role.Settings = chSettings.Checked;
            Role.User = chUsers.Checked;
            Role.Credit = chCredit.Checked;
            Role.MoneyBox = chMoneyBox.Checked;

            var validator = ValidationHelpers.ValidateMessage(Role, new RoleValidation(), this);

            if (!validator.IsValid)
            {
                return;
            }

            roleOperation.Update(Role);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void userSaveFooter1_SaveClick(object sender, EventArgs e)
        {
            if (Operation is Enums.Operation.Add)
            {
                RoleAdd();
            }
            else if (Operation is Enums.Operation.Edit)
            {
                RoleEdit();
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tabAdmin)
            {
                chPosSales.Checked = false;
                chPosReturn.Checked = false;
                chMoneyBox.Checked = false;
            }
            if (e.Page == tabCashier)
            {
                chBank.Checked = false;
                chReport.Checked = false;
                chUsers.Checked = false;
                chSettings.Checked = false;
                chCredit.Checked = false;
            }
        }
    }
}