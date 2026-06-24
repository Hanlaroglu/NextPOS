using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
using System;
using System.Threading.Tasks;

namespace Barcode_Sales.Forms
{
    public partial class fAddUser : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        IStoreOperation storeOperation = new StoreManager();
        IUserOperation userOperation = new UserManager();
        IRoleOperation roleOperation = new RoleManager();

        private Enums.Operation _operation { get; }
        private User _user { get; set; }

        public fAddUser(Enums.Operation operation, User user = null)
        {
            InitializeComponent();
            _user = user;
            _operation = operation;
        }

        private async void fAddUser_Shown(object sender, EventArgs e)
        {
            await GetStores();
            await GetRoles();
            await GetUser();
        }

        private async Task GetUser()
        {
            lookStores.EditValue = _user.StoreId;
            lookStores.Enabled = false;
            lookRole.EditValue = _user.RoleId;
            tUsername.Text = _user.Username;
            
        }

        private async Task GetStores()
        {
            var data = await storeOperation.ToListAsync();
            FormHelpers.ControlLoad(data, lookStores);
        }

        private async Task GetRoles()
        {
            var data = await roleOperation.ToListAsync();
            FormHelpers.ControlLoad(data, lookRole, "RoleName");
        }

        private async void bSave_Click(object sender, EventArgs e)
        {
            if (_operation is Enums.Operation.Add)
                await Add();
            else
                await Edit();
        }

        private async Task Add()
        {
            var storeId = Convert.ToInt32(lookStores.EditValue.ToString());
            var roleId = Convert.ToInt32(lookRole.EditValue.ToString());

            _user = new User
            {
                StoreId = storeId,
                Username = tUsername.Text.Trim(),
                Password = tPassword.Text.Trim(),
                NameSurname = tNameSurname.Text.Trim(),
                Email = tEmail.Text.Trim(),
                Phone = tPhone.Text.Trim(),
                IsActive = chIsStatus.Checked,
                RoleId = roleId,
                IsDeleted = 0
            };

            var exists = await userOperation.Get(x => x.Username == tUsername.Text.Trim());
            if (exists != null)
            {
                NotificationHelpers.Messages.WarningMessage(this, UserValidation.ExistingUsername);
                return;
            }

            var validator = ValidationHelpers.ValidateMessage(_user, new UserValidation(), this);
            if (!validator.IsValid)
                return;

            var result = await userOperation.Add(_user);
            if (result > 0)
            {
                NotificationHelpers.Messages.SuccessMessage(this,"İstifadəçi uğurla yaradıldı");
                Clear();
            }
        }

        private async Task Edit()
        {
            _user.Password = tPassword.Text.Trim();
            _user.NameSurname = tNameSurname.Text.Trim();
            _user.Email = tEmail.Text.Trim();
            _user.Phone = tPhone.Text.Trim();
            _user.IsActive = chIsStatus.Checked;

            var validator = ValidationHelpers.ValidateMessage(_user, new UserValidation(), this);
            if (!validator.IsValid)
                return;

            var result = await userOperation.Update(_user,
                x => x.Password,
                x => x.NameSurname,
                x => x.Email,
                x => x.Phone,
                x => x.IsActive);

            if (result)
                Clear();
        }

        private void Clear()
        {
            tUsername.Clear();
            tPassword.Clear();
            tNameSurname.Clear();
            tEmail.Clear();
            tPhone.Clear();
        }

        private void tPassword_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tPassword.Text))
                tPassword.Properties.UseSystemPasswordChar = !tPassword.Properties.UseSystemPasswordChar;
        }

        private void itemAddRole_Click(object sender, EventArgs e)
        {
            fAddRole f = new fAddRole();
            f.FormClosed += async (s, x) =>
            {
                await GetRoles();
            };
            f.Show();
        }
    }
}