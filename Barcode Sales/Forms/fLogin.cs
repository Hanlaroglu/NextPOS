using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Services.CacheServices;
using Barcode_Sales.Validations;
using System;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fLogin : DevExpress.XtraEditors.XtraForm
    {
        IUserOperation userOperation = new UserManager();
        public fLogin()
        {
            InitializeComponent();
        }

        private void fLoginDemo_Load(object sender, EventArgs e)
        {
            lVersion.Text = $"V{Application.ProductVersion}";
            if (Properties.Settings.Default.SaveMe)
            {
                chSaveMe.Checked = Properties.Settings.Default.SaveMe;
                tUsername.Text = Properties.Settings.Default.Username;
                tPassword.Text = Properties.Settings.Default.Password;
            }
            else
            {
                chSaveMe.Checked = false;
                tUsername.Text = null;
                tPassword.Text = null;
            }
        }

        private void Login()
        {
            var control = userOperation.Authentication(tUsername.Text.Trim(), tPassword.Text.Trim(), chSaveMe.Checked);
            if (control.Item1)
            {
                UserCacheService.User = control.Item2;
                if (UserValidation.AuthorizationControl(UserCacheService.User, role => role.Admin))
                {
                    this.Hide();
                    fDashboard f = new fDashboard();
                    //Barcode.Sales.Admin.fDashboard f = new Barcode.Sales.Admin.fDashboard(control.Item2);
                    f.Show();
                    f.FormClosed += (s, args) =>
                    {
                        Application.Exit();
                    };

                }
                else if (UserValidation.AuthorizationControl(UserCacheService.User, role => role.Cashier))
                {
                    this.Hide();
                    fPosSales f = new fPosSales();
                    f.Show();
                    f.FormClosed += (s, args) =>
                    {
                        Application.Exit();
                    };
                }
            }
            else
            {
                NotificationHelpers.Messages.ErrorMessage(this, control.Item3);
                return;
            }
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void fLoginDemo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    Login();
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }
    }
}