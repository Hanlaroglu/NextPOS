using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barcode_Sales
{
    public class Yazdir
    {
        private string ProccesNo { get; set; }

        private bool Type { get; set; }

        public Yazdir(string proccesNo, bool type)
        {
            ProccesNo = proccesNo;
            using (var db = new NextposDBEntities())
            {
                //switch (type)
                //{
                //    case true: db.Satis.Where(x => x.ProccesNo == proccesNo).ToList(); break;
                //    case false: db.Return_Sales.Where(x => x.ProccesNo == proccesNo).ToList(); break;
                //}
            }
            Type = type;
            var liste = type;
        }

        PrintDocument pd = new PrintDocument();




        public void YazdirmaBasla()
        {
            try
            {
                pd.PrintPage += Pd_PrintPage;
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //NextposDBEntities db = new NextposDBEntities();
            ////var isyeri = db.Company.FirstOrDefault();
            ////var liste = Type is KassadbEntities;

            //var liste = db.Satis.Where(x => x.ProccesNo == ProccesNo).ToList();

            //if (isyeri != null && liste != null) // Satış Çekine Yazılacaqlar
            //{
            //    int kagituzunluk = 120;
            //    for (int i = 0; i < liste.Count; i++)
            //    {
            //        kagituzunluk += 15;
            //    }
            //    PaperSize ps58 = new PaperSize("58mm Termal", 280, kagituzunluk + 120);
            //    pd.DefaultPageSettings.PaperSize = ps58;
            //    // Fontlar
            //    Font fontBaslik = new Font("Calibri", 12, FontStyle.Bold);
            //    Font fontbilgi = new Font("Calibri", 9, FontStyle.Regular);
            //    Font fontIcerikBaslik = new Font("Calibri", 9, FontStyle.Underline);
            //    Font yekunmebleg = new Font("Calibri", 10, FontStyle.Bold);
            //    Font footerbaslik = new Font("Calibri", 8, FontStyle.Regular);
            //    //---------------------------
            //    StringFormat ortala = new StringFormat(StringFormatFlags.FitBlackBox);
            //    ortala.Alignment = StringAlignment.Center;
            //    RectangleF rcUnvanKonum = new RectangleF(0, 20, 280, 20);
            //    RectangleF rcUnvanKonum2 = new RectangleF(0, 40, 280, 20);
            //    RectangleF rcUnvanKonumTelefon = new RectangleF(0, 60, 280, 20);
            //    e.Graphics.DrawString(isyeri.CompanyName, fontBaslik, Brushes.Black, rcUnvanKonum, ortala);
            //    e.Graphics.DrawString(isyeri.Adress, fontbilgi, Brushes.Black, rcUnvanKonum2, ortala);
            //    e.Graphics.DrawString("Qəbz Nömrəsi : " + ProccesNo.ToString(), footerbaslik, Brushes.Black, rcUnvanKonumTelefon, ortala);
            //    e.Graphics.DrawString("***************************************", fontbilgi, Brushes.Black, new Point(5, 85));
            //    e.Graphics.DrawString("Məhsulun Adı", fontIcerikBaslik, Brushes.Black, new Point(5, 95));
            //    e.Graphics.DrawString("Say", fontIcerikBaslik, Brushes.Black, new Point(120, 95));
            //    e.Graphics.DrawString("Qiymət", fontIcerikBaslik, Brushes.Black, new Point(165, 95));
            //    e.Graphics.DrawString("Cəmi", fontIcerikBaslik, Brushes.Black, new Point(215, 95));

            //    int yukseklik = 120;
            //    double geneltoplam = 0;
            //    foreach (var item in liste)
            //    {
            //        e.Graphics.DrawString(item.MehsulAd, fontbilgi, Brushes.Black, new Point(5, yukseklik));
            //        e.Graphics.DrawString(item.Miqdar.ToString(), fontbilgi, Brushes.Black, new Point(130, yukseklik));
            //        e.Graphics.DrawString(Convert.ToDouble(item.SatisQiymet).ToString("N2"), fontbilgi, Brushes.Black, new Point(172, yukseklik));
            //        e.Graphics.DrawString(Convert.ToDouble(item.Toplam).ToString("N2"), fontbilgi, Brushes.Black, new Point(217, yukseklik));
            //        yukseklik += 20;
            //        geneltoplam += Convert.ToDouble(item.Toplam);
            //    }
            //    //double? qaliq = list.ParaUstu;
            //    //double? odenen = list.Odenen;
            //    e.Graphics.DrawString("--------------------------------------------------------------", fontbilgi, Brushes.Black, new Point(5, yukseklik + 3));
            //    e.Graphics.DrawString("YEKUN MƏBLƏĞ :   ", yekunmebleg, Brushes.Black, new Point(5, yukseklik + 20));
            //    e.Graphics.DrawString(Convert.ToDouble(geneltoplam).ToString("C2"), yekunmebleg, Brushes.Black, new Point(185, yukseklik + 20));
            //    e.Graphics.DrawString("--------------------------------------------------------------", fontbilgi, Brushes.Black, new Point(5, yukseklik + 35));
            //    //e.Graphics.DrawString("Ödəniş Növü", PaymentType, Brushes.Black, new Point(5, yukseklik + 50));
            //    //e.Graphics.DrawString(list.OdemeSekli, fontbilgi, Brushes.Black, new Point(6, yukseklik + 72));
            //    //e.Graphics.DrawString(Convert.ToDouble(odenen).ToString("C2"), fontbilgi, Brushes.Black, new Point(185, yukseklik + 72));
            //    //e.Graphics.DrawString("QALIQ", fontbilgi, Brushes.Black, new Point(6, yukseklik + 87)); // Qalıq
            //    //e.Graphics.DrawString(Convert.ToDouble(qaliq).ToString("C2"), fontbilgi, Brushes.Black, new Point(185, yukseklik + 87));
            //}
        }

    }
}
