using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Licence
{
    public partial class fDeactive : Form
    {
        public fDeactive()
        {
            InitializeComponent();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string ProjectPath = $"{Application.StartupPath}\\Next Market.exe";
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(ProjectPath);
            lVersion.Text = "V" + versionInfo.ProductVersion;
            lKey.Text = Registry.CurrentUser.OpenSubKey("NGT").OpenSubKey("Next Market").OpenSubKey("Settings").GetValue("ProductID").ToString();
        }

        private void lKey_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lKey.Text);
        }
    }
}
