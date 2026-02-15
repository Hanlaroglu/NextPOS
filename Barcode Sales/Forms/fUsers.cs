using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
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

namespace Barcode_Sales.Forms
{
    public partial class fUsers : FormBase
    {
        IUserOperation userOperation = new UserManager();
        IStoreOperation storeOperation = new StoreManager();
        IRoleOperation roleOperation = new RoleManager();
        private Enums.Operation Operation { get; }
        private User User { get; set; }
        public fUsers(Enums.Operation _operation, User _users)
        {
            InitializeComponent();
            Operation = _operation;
            User = _users;
        }

        private void userSaveFooter1_SaveClick(object sender, EventArgs e)
        {
            if (Operation is Enums.Operation.Add)
            {
                AddUser();
            }
            else if (Operation is Enums.Operation.Edit)
            {
                EditUser();
            }
        }

        async void AddUser()
        {
            User = new User();
            User.StoreID = await GetByIdStore(lookStore.Text);
            User.Username = tUsername.Text;
            User.Password = tPassword.Text;
            User.NameSurname = tNameSurname.Text;
            User.Email = tEmail.Text;
            User.Phone = tPhone.Text;
            User.RoleID = await GetByIdRole(lookRole.Text);
            User.IsDeleted = 0;
            User.Status = true;

            bool uniqueData = userOperation.Where(x => x.Username == tUsername.Text.Trim()).Any();
            if (!uniqueData)
            {
                Message(UserValidation.ExistingUsername, NextPOS.UserControls.fMessage.enmType.Warning);
                return;
            }


            var validator = ValidationHelpers.ValidateMessage(User, new UserValidation(), this);

            if (!validator.IsValid)
            {
                return;
            }

            await userOperation.Add(User);
            Clear();
        }

        async void EditUser()
        {
            User.StoreID = await GetByIdStore(lookStore.Text);
            User.Password = tPassword.Text;
            User.NameSurname = tNameSurname.Text;
            User.Email = tEmail.Text;
            User.Phone = tPhone.Text;
            User.RoleID = await GetByIdRole(lookRole.Text);

            var validator = ValidationHelpers.ValidateMessage(User, new UserValidation(), this);

            if (!validator.IsValid)
            {
                return;
            }

          await  userOperation.Update(User, 
              x=> x.StoreID,
              x => x.Password,
              x => x.NameSurname,
              x => x.Email,
              x => x.Phone,
              x => x.RoleID);
            Close();
        }

        void Clear()
        {
            tUsername.Text = null;
            tPassword.Text = null;
            tNameSurname.Text = null;
            tEmail.Text = null;
            tPhone.EditValue = "<Null>";
            lookRole.Text = null;
            lookStore.Text = null;
            tUsername.Focus();
        }

        private async Task<int> GetByIdStore(string storeName)
        {
            var store = await storeOperation.Get(x => x.Name == storeName);
            return store != null ? store.Id : throw new NullReferenceException(UserValidation.StoreNotSelected);
        }

        private async Task<int> GetByIdRole(string roleName)
        {
            var role = await roleOperation.Get(x => x.Name == roleName);
            return role != null ? role.Id : throw new NullReferenceException(UserValidation.RoleNotSelected);
        }

        private void tPassword_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tPassword.Text))
            {
                tPassword.Properties.UseSystemPasswordChar = !tPassword.Properties.UseSystemPasswordChar;
            }
        }

        private void fUsers_Load(object sender, EventArgs e)
        {
            StoreDataLoad();
            RoleDataLoad();
            if (Operation is Enums.Operation.Edit)
            {
                tUsername.ReadOnly = true;
                userSaveFooter1.SaveButtonText = Enums.GetEnumDescription(Operation);
                UserDataLoad();
            }
        }

        void UserDataLoad()
        {
            lookStore.Text = User?.Store?.Name;
            tUsername.Text = User.Username;
            tPassword.Text = User.Password;
            tNameSurname.Text = User.NameSurname;
            tPhone.Text = User.Phone;
            tEmail.Text = User.Email;
            lookRole.Text = User?.Role?.RoleName;
        }

        void StoreDataLoad()
        {
            var data = storeOperation.Where(x => x.IsDeleted == false)
                                     .Select(x => new
                                     {
                                         x.Name
                                     }).ToList();

            FormHelpers.ControlLoad(data, lookStore, "StoreName", null);
        }

        void RoleDataLoad()
        {
            var data = roleOperation.Where(x => x.IsDeleted == 0)
                                     .Select(x => new
                                     {
                                         x.RoleName
                                     }).ToList();

            FormHelpers.ControlLoad(data, lookRole, "RoleName", null);
        }
    }
}