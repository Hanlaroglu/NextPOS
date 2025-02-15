using Barcode_Sales.UserControls;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Sales
{
    static class Islemler
    {
        public static double DoubleYap(string deger)
        {
            double sonuc;
            double.TryParse(deger, NumberStyles.Currency, CultureInfo.CurrentUICulture.NumberFormat, out sonuc);
            return Math.Round(sonuc, 2);

        }

        public static void StokAzalt(string barkod, double miqdar)
        {
            //if (barkod != "1111111111116")
            //{
            //    using (var db = new NextposDBEntities())
            //    {
            //        var urunbilgi = db.Products.SingleOrDefault(x => x.Barcode == barkod);
            //        urunbilgi.Amount -= miqdar;
            //        db.SaveChanges();
            //    }
            //}
        }

        public static void StokArtir(string barkod, double miqdar)
        {
            //if (barkod != "1111111111116")
            //{
            //    using (var db = new NextposDBEntities())
            //    {
            //        var urunbilgi = db.Products.SingleOrDefault(x => x.Barcode == barkod);
            //        urunbilgi.Amount += miqdar;
            //        db.SaveChanges();
            //    }
            //}

        }

        public static void GridDuzenle(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    switch (dgv.Columns[i].HeaderText)
                    {
                        case "Id":
                            dgv.Columns[i].HeaderText = "Id"; break;
                        case "IslemNo":
                            dgv.Columns[i].HeaderText = "Əməliyyat No"; break;
                        case "Iade":
                            dgv.Columns[i].HeaderText = "Qaytarma"; break;
                        case "Mehsulid":
                            dgv.Columns[i].HeaderText = "Məhsul Nömrəsi"; break;
                        case "MehsulAdi":
                            dgv.Columns[i].HeaderText = "Məhsul Adı"; break;
                        case "UrunAd":
                            dgv.Columns[i].HeaderText = "Məhsul Adı"; break;
                        case "UrunGrup":
                            dgv.Columns[i].HeaderText = "Kateqoriya"; break;
                        case "Birim":
                            dgv.Columns[i].HeaderText = "Vahid"; break;
                        case "Tarih":
                            dgv.Columns[i].HeaderText = "Tarix"; break;
                        case "Miktar":
                            dgv.Columns[i].HeaderText = "Miqdar";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "Kullanici":
                            dgv.Columns[i].HeaderText = "İstifadəçi";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "Aciqlama":
                            dgv.Columns[i].HeaderText = "Qeyd"; break;
                        case "Aciklama":
                            dgv.Columns[i].HeaderText = "Qeyd"; break;
                        case "MehsulQrup":
                            dgv.Columns[i].HeaderText = "Məhsul Qrupu"; break;
                        case "AlisQiymet":
                            dgv.Columns[i].HeaderText = "Alış Qiyməti";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "AlisFiyatToplam":
                            dgv.Columns[i].HeaderText = "Alış Qiymətinin Toplamı";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "SatisQiymet":
                            dgv.Columns[i].HeaderText = "Satış Qiyməti";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "EDVDerece":
                            dgv.Columns[i].HeaderText = "ƏDV Nisbəti";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "Vahid":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "Miqdar":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "OdemeSekli":
                            dgv.Columns[i].HeaderText = "Ödəniş Üsulu";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "Kart":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Nakit":
                            dgv.Columns[i].HeaderText = "Nəğd";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Gelir":
                            dgv.Columns[i].HeaderText = "Gəlir";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Gider":
                            dgv.Columns[i].HeaderText = "Xərc";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "İstifadeci":
                            dgv.Columns[i].HeaderText = "İstifadəçi";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "Istıfadeci":
                            dgv.Columns[i].HeaderText = "İstifadəçi";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "EDVMeblegi":
                            dgv.Columns[i].HeaderText = "ƏDV Məbləği";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Toplam":
                            dgv.Columns[i].HeaderText = "Toplam";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;

                    }
                }
            }
        }

        public static void StokHareket(string barkod, string urunad, string birim, double miktar, string urungrup, string kullanici)
        {
            using (var db = new NextposDBEntities())
            {
                //StokHareket sh = new StokHareket();
                //sh.Barkod = barkod;
                //sh.UrunAd = urunad;
                //sh.Birim = birim;
                //sh.Miktar = miktar;
                //sh.UrunGrup = urungrup;
                //sh.Kullanici = kullanici;
                //sh.Tarih = DateTime.Now;
                //db.StokHareket.Add(sh);
                //db.SaveChanges();
            }
        }

        public static void SabitVarsayilan()
        {
            //using (var db = new KassadbEntities())
            //{
            //    if (!db.Company.Any())
            //    {
            //        //Company company = new Company();
            //        //company.Printer = false;
            //        //company.CompanyName = "admin";
            //        //company.Adress = "admin";
            //        //company.Adres = "admin";
            //        //company.Telefon = "admin";
            //        //company.Eposta = "admin";
            //        //db.Company.Add(company);
            //        //db.SaveChanges();
            //    }
            //}
        }

        public static void FolderControl()
        {
            if (!Directory.Exists(Application.StartupPath + "\\Export\\Məhsullar"))
                Directory.CreateDirectory(Application.StartupPath + "\\Export\\Məhsullar");

            if (!Directory.Exists(Application.StartupPath + "\\Export\\Hesabatlar"))
                Directory.CreateDirectory(Application.StartupPath + "\\Export\\Hesabatlar");
        }

        public static void Backup()
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "NextPOS_backup_" + DateTime.Now.ToShortDateString() + ".bak";
            if (File.Exists(save.FileName))
            {
                File.Delete(save.FileName);
            }
            var dbhedef = Application.StartupPath + @"\Backup\" + save.FileName;
            using (var db = new NextposDBEntities())
            {
                var query = @"BACKUP DATABASE Kassadb TO DISK='" + dbhedef + "'";
                db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, query);
            }
            Cursor.Current = Cursors.Default;
            Registry.CurrentUser.CreateSubKey("NextPOS").CreateSubKey("Backup").SetValue("History", DateTime.Now.ToString("dd.MM.yyyy - HH:mm"));
            //Mesaj("Ehtiyat nüsxəsi uğurla yaradıldı", fMessage.enmType.Success);

        }
    }
}
