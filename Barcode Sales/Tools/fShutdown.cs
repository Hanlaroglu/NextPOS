
using DevExpress.XtraEditors;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales.UserControls
{
    public partial class fShutdown : DevExpress.XtraEditors.XtraForm
    {
        public fShutdown()
        {
            InitializeComponent();
        }

        private void bEndDay_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new NextposDBEntities())
                {

                    Cursor.Current = Cursors.WaitCursor;
                    string delete = @"USE Kassadb TRUNCATE TABLE Masalar";
                    db.Database.ExecuteSqlCommand(delete);
                    //Islemler.RegeditControl();
                    bool backupControl = Convert.ToBoolean(Registry.CurrentUser.OpenSubKey("NextPOS").OpenSubKey("Backup").GetValue("Shutdown"));
                    if (backupControl == true)
                    {
                        Islemler.Backup();
                    }
                    Cursor.Current = Cursors.Default;
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bShutdown_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (var db = new NextposDBEntities())
            {
                string delete = @"USE Kassadb TRUNCATE TABLE Masalar";
                db.Database.ExecuteSqlCommand(delete);
                //Islemler.RegeditControl();
                bool backupControl = Convert.ToBoolean(Registry.CurrentUser.OpenSubKey("NextPOS").OpenSubKey("Backup").GetValue("Shutdown"));
                if (backupControl == true)
                {
                    Islemler.Backup();
                }
            }
            System.Diagnostics.Process.Start("shutdown", "-f -s -t 10");
            Cursor.Current = Cursors.Default;
            Application.Exit();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}