using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NextPOS.Update
{
    public partial class fUpdate : Form
    {
        public static bool IsRunning(string SoftName)
        {
            return Process.GetProcessesByName(SoftName).Length > 0;
        }
        WebClient web = new WebClient();
        public fUpdate()
        {
            InitializeComponent();
            if (IsRunning("Next Market"))
            {
                foreach (var process in Process.GetProcessesByName("Next Market"))
                {
                    process.CloseMainWindow();
                    process.Kill();
                }
            }
        }

        private void fUpdate_Load(object sender, EventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                if (!Directory.Exists(Application.StartupPath + "\\temp"))
                    Directory.CreateDirectory(Application.StartupPath + "\\temp");
                else
                {
                    Directory.Delete(Application.StartupPath + "\\temp", true);
                    Directory.CreateDirectory(Application.StartupPath + "\\temp");
                }
                web.DownloadProgressChanged += (DownloadProgressChangedEventHandler)DownloadStatus;
                web.DownloadFileCompleted += (AsyncCompletedEventHandler)DownloadCompleted;
                web.DownloadFileAsync(new Uri("https://e-kassa.000webhostapp.com/NGT/Next.Market/Update.zip"), Application.StartupPath + "\\temp\\Update.zip");
            }
            else
            {
                MessageBox.Show("İnternet bağlantınız yoxdur", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ZipFile.ExtractToDirectory(Application.StartupPath + "\\temp\\Update.zip", Application.StartupPath + "\\temp");
            XElement Files = XElement.Load(Application.StartupPath + "\\temp\\updateConfig.xml");
            foreach (var element in Files.Elements().ToList())
            {
                if (File.Exists(Application.StartupPath + element.Element("FileLocation").Value))
                {
                    File.Delete(Application.StartupPath + element.Element("FileLocation").Value);
                }
                File.Copy(Application.StartupPath + "\\temp\\" + element.Element("FileName").Value, Application.StartupPath + element.Element("FileLocation").Value);
            }
            Directory.Delete(Application.StartupPath + "\\temp", true);
            MessageBox.Show("Yeni versiya yükləməsi uğurla başa çatdı.\nProqramı yenidən başlatabilərsiniz.", "NGT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void DownloadStatus(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarControl1.Properties.Maximum = (int)e.TotalBytesToReceive;
            progressBarControl1.Text = Convert.ToString(e.BytesReceived);
            labelControl2.Text = $"{(Convert.ToDecimal(e.BytesReceived) / 1024 / 1024).ToString("N2")} MB \\ {(Convert.ToDecimal(e.TotalBytesToReceive) / 1024 / 1024).ToString("N2")} MB";

        }

    }
}
