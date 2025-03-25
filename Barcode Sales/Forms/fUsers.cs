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
        NextposDBEntities db = new NextposDBEntities();
        IUserOperation userOperation = new UserManager();
        private Enums.Operation Operation { get; }
        private Users User { get; set; }
        public fUsers(Enums.Operation _operation, Users _users)
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

        void AddUser()
        {
            User = new Users();
            User.StoreID = GetByIdStore(lookStore.Text);
            User.Username = tUsername.Text;
            User.Password = tPassword.Text;
            User.NameSurname = tNameSurname.Text;
            User.Email = tEmail.Text;
            User.Phone = tPhone.Text;
            User.RoleID = GetByIdRole(lookRole.Text);
            User.IsDeleted = 0;
            User.Status = true;

            bool uniqueData = userOperation.Where(x=> x.Username == tUsername.Text.Trim()).Any();
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

            userOperation.Add(User);
            Clear();
        }

        void EditUser()
        {
            User.StoreID = GetByIdStore(lookStore.Text);
            User.Password = tPassword.Text;
            User.NameSurname = tNameSurname.Text;
            User.Email = tEmail.Text;
            User.Phone = tPhone.Text;
            User.RoleID = GetByIdRole(lookRole.Text);

            var validator = ValidationHelpers.ValidateMessage(User, new UserValidation(), this);

            if (!validator.IsValid)
            {
                return;
            }

            userOperation.Update(User);
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

        int GetByIdStore(string storeName)
        {
            var store = db.Stores.AsNoTracking().FirstOrDefault(x => x.StoreName == storeName);
            return store != null ? store.Id : throw new NullReferenceException(UserValidation.StoreNotSelected);
        }

        int GetByIdRole(string roleName)
        {
            var role = db.Roles.AsNoTracking().FirstOrDefault(x => x.RoleName == roleName);
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
            lookStore.Text = User?.Stores?.StoreName;
            tUsername.Text = User.Username;
            tPassword.Text = User.Password;
            tNameSurname.Text = User.NameSurname;
            tPhone.Text = User.Phone;
            tEmail.Text = User.Email;
            lookRole.Text = User?.Roles?.RoleName;
        }

        void StoreDataLoad()
        {
            var data = db.Stores.AsNoTracking()
                               .Where(x => x.IsDeleted == 0)
                               .Select(x => new
                               {
                                   x.StoreName
                               })
                               .ToList();

            FormHelpers.ControlLoad(data, lookStore, "StoreName", null);
        }

        void RoleDataLoad()
        {
            var data = db.Roles.AsNoTracking()
                               .Where(x => x.IsDeleted == 0)
                               .Select(x => new
                               {
                                   x.RoleName
                               })
                               .ToList();


            FormHelpers.ControlLoad(data, lookRole, "RoleName", null);
        }
    }
}