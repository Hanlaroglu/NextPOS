using DevExpress.XtraEditors;
using Microsoft.Win32;
using NextPOS.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;

using System.Configuration;

namespace NextDBSetup
{
    public partial class fConnection : DevExpress.XtraEditors.XtraForm
    {
        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();


        
        public fConnection()
        {
            InitializeComponent();
        }

        private static void Message(string msg, fMessage.enmType type)
        {
            fMessage frm = new fMessage();
            frm.showAlert(msg, type);
        }

        private void ConnectionCreate()
        {
            try
            {
                connectionStringBuilder.InitialCatalog = "master";
                connectionStringBuilder.DataSource = tServerName.Text;
                if (chWindows.Checked)
                    connectionStringBuilder.IntegratedSecurity = true;
                else
                {
                    connectionStringBuilder.UserID = tUsername.Text;
                    connectionStringBuilder.Password = tPassword.Text;
                    connectionStringBuilder.IntegratedSecurity = false;
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chSql_CheckedChanged(object sender, EventArgs e)
        {
            if (chSql.Checked)
            {
                tUsername.Enabled = true;
                tPassword.Enabled = true;
            }
            else
            {
                tUsername.Enabled = false;
                tPassword.Enabled = false;
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ConnectionCreate();
            if (ConnectionStringInfo.Check(connectionStringBuilder.ConnectionString))
            {
                connectionStringBuilder.InitialCatalog = "Barcodedb";
                ConnectionStringInfo.Set(connectionStringBuilder.ConnectionString);

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["KassadbEntities"].ConnectionString = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=\"" + connectionStringBuilder.ConnectionString.Replace("Data Source", "Server").Replace("Initial Catalog", "Database") + ";MultipleActiveResultSets=True;App=EntityFramework\"";

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("KassadbEntities");
                
                // Create database
                ConnectionStringInfo.CreateDB(chCreateDB.Checked);

                //Registry.CurrentUser.CreateSubKey("NextBarcode").SetValue("Config", connectionStringBuilder.ConnectionString);
                Cursor.Current = Cursors.WaitCursor;
            }
            else { Message("Qoşulma mümkün olmadı", fMessage.enmType.Error); }
        }

        private void bTest_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ConnectionCreate();
                if (ConnectionStringInfo.Check(connectionStringBuilder.ConnectionString))
                    Message("Uğurlu Qoşulma", fMessage.enmType.Success);
                else
                    Message("Qoşulma mümkün olmadı", fMessage.enmType.Error);
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
            Cursor.Current = Cursors.Default;
        }
    }
}