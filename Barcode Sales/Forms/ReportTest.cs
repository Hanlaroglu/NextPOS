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
    public partial class ReportTest : Form
    {
        private PictureBox previewBox;
        private DataGridView componentsGrid;
        private TextBox txtSatisQiymeti, txtKategoriya, txtMalinAdi;

        public ReportTest()
        {
            InitializeComponent();

            // Form Başlığı
            this.Text = "Şablon Görüntüleyici";
            this.Size = new Size(900, 600);

            // Sol taraf: PreviewBox (önizleme alanı)
            previewBox = new PictureBox();
            previewBox.BorderStyle = BorderStyle.Fixed3D;
            previewBox.Location = new Point(10, 10);
            previewBox.Size = new Size(400, 500);
            previewBox.BackColor = Color.White;
            this.Controls.Add(previewBox);

            // Sağ taraf: DataGridView - Komponent ayarları
            componentsGrid = new DataGridView();
            componentsGrid.Location = new Point(450, 10);
            componentsGrid.Size = new Size(400, 300);
            componentsGrid.Columns.Add("KomponentAdi", "Komponent Adı");
            componentsGrid.Columns.Add("GorunmeStatusu", "Görünme Durumu");
            componentsGrid.Columns.Add("X", "X");
            componentsGrid.Columns.Add("Y", "Y");
            componentsGrid.Columns.Add("Size", "Şrift Ölçüsü");

            // Örnek veri ekleyelim
            componentsGrid.Rows.Add("Malin Adi", true, 100, 50, 12);
            componentsGrid.Rows.Add("Satis Qiymeti", true, 150, 100, 14);
            componentsGrid.Rows.Add("Kategoriya", true, 100, 200, 10);

            componentsGrid.CellValueChanged += Grid_CellValueChanged;
            this.Controls.Add(componentsGrid);

            // Bilgiler için TextBoxlar (Aşağıda yerleşen alanlar)
            txtSatisQiymeti = new TextBox() { Location = new Point(450, 330), Width = 150, Text = "Satış Qiymeti: 5.00" };
            txtKategoriya = new TextBox() { Location = new Point(450, 360), Width = 150, Text = "Kategoriya: Esas" };
            txtMalinAdi = new TextBox() { Location = new Point(450, 390), Width = 150, Text = "Malın Adı: Test" };

            this.Controls.Add(txtSatisQiymeti);
            this.Controls.Add(txtKategoriya);
            this.Controls.Add(txtMalinAdi);

            // Güncelleme butonu
            Button updateButton = new Button();
            updateButton.Text = "Önizlemeyi Güncelle";
            updateButton.Location = new Point(450, 430);
            updateButton.Click += UpdateButton_Click;
            this.Controls.Add(updateButton);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            // Preview alanını güncelle
            using (Graphics g = previewBox.CreateGraphics())
            {
                g.Clear(Color.White);
                g.DrawString(txtMalinAdi.Text, new Font("Arial", 12), Brushes.Black, 100, 50);
                g.DrawString(txtSatisQiymeti.Text, new Font("Arial", 12), Brushes.Black, 150, 100);
                g.DrawString(txtKategoriya.Text, new Font("Arial", 12), Brushes.Black, 100, 200);
            }
        }

        private void Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // X ve Y değerlerini ilgili satırdan alıyoruz
            int x = Convert.ToInt32(componentsGrid.Rows[e.RowIndex].Cells["X"].Value);
            int y = Convert.ToInt32(componentsGrid.Rows[e.RowIndex].Cells["Y"].Value);

            // Şrift ölçüsünü alıyoruz
            int fontSize = Convert.ToInt32(componentsGrid.Rows[e.RowIndex].Cells["Size"].Value);

            // Komponentin adını alıyoruz
            string komponentAdi = componentsGrid.Rows[e.RowIndex].Cells["KomponentAdi"].Value.ToString();

            // Görünme durumunu kontrol ediyoruz
            bool isVisible = Convert.ToBoolean(componentsGrid.Rows[e.RowIndex].Cells["GorunmeStatusu"].Value);

            // Preview alanını temizle
            using (Graphics g = previewBox.CreateGraphics())
            {
                g.Clear(Color.White);

                // Eğer görünme durumu işaretli ise, metni çiz
                if (isVisible)
                {
                    // Komponent adını ve X, Y değerlerine göre metni çiziyoruz
                    g.DrawString(komponentAdi, new Font("Arial", fontSize), Brushes.Black, x, y);
                }
            }
        }
    }
}
