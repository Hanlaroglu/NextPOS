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
            var control = UserValidation.AuthenticationControl(tUsername.Text.Trim(), tPassword.Text.Trim(),chSaveMe.Checked);
            if (control.Item1)
            {
                CommonData.CURRENT_USER = control.Item2;
                if (UserValidation.AuthorizationControl(CommonData.CURRENT_USER, role => role.Admin))
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
                else if (UserValidation.AuthorizationControl(CommonData.CURRENT_USER, role => role.Cashier))
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
            else
            {
                chSaveMe.Checked = false;
                tUsername.Text = null;
                tPassword.Text = null;
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

        private void chSaveMe_CheckedChanged(object sender, EventArgs e)
        {
            //if (chSaveMe.Checked)
            //    Properties.Settings.Default.SaveMe = true;
            //else
            //    Properties.Settings.Default.SaveMe = false;
            //Properties.Settings.Default.Save();
        }
    }
}