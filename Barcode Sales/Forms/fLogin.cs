using Barcode_Sales.Helpers;
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
    public partial class fLogin : DevExpress.XtraEditors.XtraForm
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void fLoginDemo_Load(object sender, EventArgs e)
        {
            lVersion.Text = $"V{Application.ProductVersion}";
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

        private void Login()
        {
            var control = UserValidation.AuthenticationControl(tUsername.Text.Trim(), tPassword.Text.Trim(), chSaveMe.Checked);
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