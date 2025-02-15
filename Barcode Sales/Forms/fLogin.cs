using Barcode_Sales.Barcode.Sales.Admin;
using Barcode_Sales.Barcode.Sales.UI;
using Barcode_Sales.Helpers;
using Barcode_Sales.Validations;
using NextPOS.UserControls;
using System;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fLogin : FormBase
    {
        public fLogin()
        {
            InitializeComponent();
            lVersion.Text = FormHelpers.AppVersion();
            tUsername.Focus();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void Login()
        {
            var control = UserValidation.AuthenticationControl(tUsername.Text.Trim(), tPassword.Text.Trim());
            if (control.Item1)
            {
                Users user = control.Item2;
                if (UserValidation.AuthorizationControl(user, role => role.Admin))
                {
                    FormHelpers.OpenForm<fDashboard>(user);
                    this.Hide();
                }
                if (UserValidation.AuthorizationControl(user, role => role.Cashier))
                {
                    FormHelpers.OpenForm<fBarcodeSalesUI>(user);
                    this.Hide();
                }
            }
            else
            {
                NoticationHelpers.Messages.ErrorMessage(this, control.Item3);
                return;
            }
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SaveMe is true)
            {
                chSaveMe.Checked = Properties.Settings.Default.SaveMe;
                tUsername.Text = Properties.Settings.Default.Username;
                tPassword.Text = Properties.Settings.Default.Password;
            }
        }

        private void KeyboardPress(object sender, KeyEventArgs e)
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