using Licence.Models;
using Licence.Services;
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
        public fDeactive(Client client)
        {
            InitializeComponent();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var path = LicenseService.path;
            //string ProjectPath = $"{Application.StartupPath}\\Next Market.exe";
            //FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(ProjectPath);
            lVersion.Text = $"V{Application.ProductVersion}";
            lKey.Text = Registry.CurrentUser.OpenSubKey(LicenseService.path).GetValue("ProductID").ToString();
        }

        private void lKey_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lKey.Text);
        }
    }
}
