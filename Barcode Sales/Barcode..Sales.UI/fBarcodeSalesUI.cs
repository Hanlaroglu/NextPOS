using Barcode_Sales.Barcode.Sales.UI.Kassa;
using Barcode_Sales.Helpers;
using Barcode_Sales.Tools;
using Barcode_Sales.UserControls;
using DevExpress.XtraEditors;
using NextPOS.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using static Barcode_Sales.Barcode.Sales.UI.Kassa.fPOS;
using Barcode_Sales.Forms;
using Barcode_Sales.Validations;

namespace Barcode_Sales.Barcode.Sales.UI
{
    public partial class fBarcodeSalesUI : FormBase
    {
        KhanposDbEntities db = new KhanposDbEntities();
        private readonly Users CurrentUser;

        public fBarcodeSalesUI(Users _user)
        {
            InitializeComponent();
            CurrentUser = _user;
            //var user = db.Users.FirstOrDefault(x => x.Id == Properties.Settings.Default.UserID);
            //if (user != null || Properties.Settings.Default.UserID != 0)
            //{
            //    lUsername.Text = user.NameSurname;
            //}
            //else
            //{
            //    Message("İstifadəçi tapılmadı", fMessage.enmType.Error); return;
            //}


        }
        private BindingList<GridData> dataList;
        private void tBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            //short rowNo = 1;
            //double amount, price, total;
            //if (e.KeyCode is Keys.Enter)
            //{
            //    amount = DoubleConvert(tAmount.EditValue.ToString());
            //    string barcode = tBarcode.Text.TrimStart().Trim();
            //    var Isbarcode = db.Products.AsNoTracking()
            //                                .FirstOrDefault(x => x.Barkod == barcode);


            //    //dataList.Add(new GridData
            //    //{
            //    //    RowNo = rowNo,
            //    //    Barcode = 
            //    //});
            //}
            //return;

            if (e.KeyCode is Keys.Enter)
            {
                string barcode = tBarcode.Text.Trim();
                if (string.IsNullOrWhiteSpace(barcode))
                {
                    tAmount.Text = 1.ToString();
                }
                else
                {
                    if (barcode.Length <= 2)
                    {
                        tAmount.Text = barcode; //miqdar
                        tBarcode.Text = null;
                        tBarcode.Focus();
                    }
                    else
                    {

                        if (db.Products.AsNoTracking().Any(a => a.Barcode == barcode))
                        {
                            var product = db.Products.FirstOrDefault(x => x.Barcode == barcode);
                            if (product.Amount >= 0)
                            {
                                // MehsulGetirEkrana(urun, barkod, Convert.ToInt32(tAmount.Text));
                                ProductsAddGrid(product, Convert.ToDouble(tAmount.Text));
                                //UrunGetirListeye(product, barcode, Convert.ToInt32(tAmount.Text));
                            }
                            else
                            {
                                Message(product.ProductName + " Stokda mövcud deyil", fMessage.enmType.Warning);
                            }
                        }

                    }
                    gridProducts.ClearSelection();
                }
            }


            return;

            if (e.KeyCode is Keys.Enter)
            {
                string barcode = tBarcode.Text.Trim();
                if (string.IsNullOrWhiteSpace(barcode))
                {
                    tAmount.Text = 1.ToString();
                }
                else
                {
                    if (barcode.Length <= 2)
                    {
                        tAmount.Text = barcode; //miqdar
                        tBarcode.Text = null;
                        tBarcode.Focus();
                    }
                    else
                    {
                        using (var db = new NextposDBEntities())
                        {
                            if (db.Products.Any(a => a.Barcode == barcode))
                            {
                                var product = db.Products.Where(a => a.Barcode == barcode).FirstOrDefault();
                                //if (product.Amount >= 0)
                                //{
                                //    // MehsulGetirEkrana(urun, barkod, Convert.ToInt32(tAmount.Text));
                                //    UrunGetirListeye(product, barcode, Convert.ToInt32(tAmount.Text));
                                //}
                                //else
                                //    Message(product.ProductName + " Stokda mövcud deyil", fMessage.enmType.Warning);
                                //GenelToplam();
                                ProductsTotalSum();
                            }


                            //// TƏRƏZİ KODU
                            //else
                            //{
                            //    int onek = Convert.ToInt32(barcode.Substring(0, 2));
                            //    if (db.Terazi.Any(a => a.TeraziOnEk == onek))
                            //    {
                            //        string terezimehsulno = barcode.Substring(2, 5);
                            //        if (db.Products.Any(a => a.Barkod == terezimehsulno))
                            //        {
                            //            var mehsulterezi = db.Products.Where(a => a.Barkod == terezimehsulno).FirstOrDefault();
                            //            double miqdarkg = Convert.ToDouble(barcode.Substring(7, 5)) / 1000;
                            //            //MehsulGetirEkrana(mehsulterezi, terezimehsulno, miqdarkg);
                            //        }
                            //        else
                            //        {
                            //            Console.Beep(900, 2000);
                            //            //MessageBox.Show("Kg ürün ekleme sayfası");
                            //        }
                            //    }
                            //    else
                            //    {
                            //        Console.Beep(900, 2000);
                            //        Message("Məhsul tapılmadı !", NextPOS.UserControls.fMessage.enmType.Error);
                            //    }
                            //}
                        }
                    }
                    gridSatisListesi.ClearSelection();
                }
            }
        }

        private void tBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void gridSatisListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            double qiymet, toplam, miqdar;
            fRelacementPage editForm;
            DataGridViewRow clickedRow;
            switch (e.ColumnIndex)
            {
                case 10:
                    gridSatisListesi.Rows.Remove(gridSatisListesi.CurrentRow);
                    gridSatisListesi.ClearSelection();
                    GenelToplam();
                    tBarcode.Focus(); break;
                case 4:
                    clickedRow = gridSatisListesi.Rows[e.RowIndex];

                    editForm = new fRelacementPage();
                    editForm.selectedRow = clickedRow;
                    editForm.Operations = "Amount";
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        clickedRow.Cells[4].Value = editForm.Amount;
                        miqdar = Convert.ToDouble(clickedRow.Cells[4].Value);
                        qiymet = Convert.ToDouble(clickedRow.Cells[6].Value);
                        toplam = miqdar * qiymet;

                        clickedRow.Cells[7].Value = toplam;
                        GenelToplam();
                    }
                    break;
                case 6:
                    clickedRow = gridSatisListesi.Rows[e.RowIndex];

                    editForm = new fRelacementPage();
                    editForm.selectedRow = clickedRow;
                    editForm.Operations = "Price";
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        clickedRow.Cells[6].Value = editForm.Price;
                        //colPrice.DefaultCellStyle.Format = "C2";
                        miqdar = Convert.ToDouble(clickedRow.Cells[4].Value);
                        qiymet = Convert.ToDouble(clickedRow.Cells[6].Value);
                        toplam = miqdar * qiymet;

                        clickedRow.Cells[7].Value = toplam;
                        GenelToplam();
                    }
                    break;
            }
        }

        void ProductsTotalSum()
        {
            if (gridProducts.RowCount > 0)
            {
                double? total = 0;
                for (int i = 0; i < gridProducts.RowCount; i++)
                {
                    total += DoubleConvert(gridProducts.GetFocusedRowCellValue(colTotals).ToString());
                }
                tTotal.EditValue = total.Value;
            }
            else
            {
                tTotal.EditValue = 0;
            }
            tAmount.Text = 1.ToString();
            tBarcode.Text = null;
            tBarcode.Focus();
        }

        private void GenelToplam()
        {
            //if (gridSatisListesi.Rows.Count > 0)
            //{
            //    double toplam = 0;
            //    for (int i = 0; i < gridSatisListesi.Rows.Count; i++)
            //    {
            //        toplam += Convert.ToDouble(gridSatisListesi.Rows[i].Cells["colTotal"].Value);
            //    }
            //    tTotal.EditValue = toplam;
            //}
            //else { tTotal.EditValue = 0; }
            //tAmount.Text = "1";
            //tBarcode.Text = null;
            //tBarcode.Focus();
        }

        private class GridData
        {
            public int Id { get; set; }
            public short RowNo { get; set; }
            public string Barcode { get; set; }
            public string PName { get; set; }
            public double Amount { get; set; }
            public string Unit { get; set; }
            public double SPrice { get; set; }
            public double Total { get; set; }
        }

        void ProductsAddGrid(Product _product, double _amount)
        {
            short rowNo = 1;
            try
            {
                short rowCount = (short)gridProducts.RowCount;
                bool IsAdded = false;
                if (rowCount > 0)
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        string gridBarkod = gridProducts.GetRowCellValue(i, "Barcode")?.ToString();
                        if (gridBarkod == _product.Barcode)
                        {
                            gridProducts.SetRowCellValue(i, colMiqdar, _amount + Convert.ToDouble(gridProducts.GetRowCellValue(i, colMiqdar)));
                            gridProducts.SetRowCellValue(i, colTotals, Math.Round(Convert.ToDouble(gridProducts.GetRowCellValue(i, colMiqdar)) * Convert.ToDouble(gridProducts.GetRowCellValue(i, colSPrice)), 2));
                            IsAdded = true;
                            break;
                        }
                    }
                }

                if (!IsAdded)
                {
                    double total = Math.Round(_amount * (double)_product.SalePrice, 2);
                    //GridData gridData = new GridData();
                    //gridData.RowNo = rowNo;
                    //gridData.Barcode = _product.Barcode;
                    //gridData.PName = _product.ProductName;
                    //gridData.Amount = _amount;
                    //gridData.SPrice = (double)_product.SalePrice;
                    //gridData.Unit = _product.Unit;
                    //gridData.Total = total;
                    //dataList.Add(gridData);
                    dataList.Add(new GridData
                    {
                        Id = _product.Id,
                        RowNo = rowNo,
                        Barcode = _product.Barcode,
                        PName = _product.ProductName,
                        Amount = _amount,
                        SPrice = (double)_product.SalePrice,
                        //Unit = _product.Unit,
                        Total = total,
                    });
                    rowNo++;
                    ProductsTotalSum();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void UrunGetirListeye(Product urun, string barkod, double miktar)
        {
            try
            {
                short satirsayisi = (short)gridSatisListesi.Rows.Count;
                bool eklenmismi = false;
                if (satirsayisi > 0)
                {
                    for (int i = 0; i < satirsayisi; i++)
                    {
                        if (gridSatisListesi.Rows[i].Cells["colBarcode"].Value.ToString() == barkod)
                        {
                            gridSatisListesi.Rows[i].Cells["colAmount"].Value = miktar + Convert.ToDouble(gridSatisListesi.Rows[i].Cells["colAmount"].Value);
                            gridSatisListesi.Rows[i].Cells["colTotal"].Value = Math.Round(Convert.ToDouble(gridSatisListesi.Rows[i].Cells["colAmount"].Value) * Convert.ToDouble(gridSatisListesi.Rows[i].Cells["colPrice"].Value), 2);
                            eklenmismi = true;
                        }
                    }
                }
                if (!eklenmismi)
                {
                    gridSatisListesi.Rows.Add();
                    gridSatisListesi.Rows[satirsayisi].Cells["colid"].Value = urun.Id;
                    gridSatisListesi.Rows[satirsayisi].Cells["colProductName"].Value = urun.ProductName;
                    gridSatisListesi.Rows[satirsayisi].Cells["colBarcode"].Value = barkod;
                    gridSatisListesi.Rows[satirsayisi].Cells["colCategory"].Value = urun.Categories.CategoryName;
                    //gridSatisListesi.Rows[satirsayisi].Cells["colVahid"].Value = urun.Unit;
                    gridSatisListesi.Rows[satirsayisi].Cells["colPrice"].Value = urun.SalePrice;
                    gridSatisListesi.Rows[satirsayisi].Cells["colAmount"].Value = miktar;
                    gridSatisListesi.Rows[satirsayisi].Cells["colTotal"].Value = Math.Round(miktar * (double)urun.SalePrice, 2);
                    gridSatisListesi.Rows[satirsayisi].Cells["colAlisQiymet"].Value = urun.PurchasePrice;
                }
            }
            catch
            {
                Message("Məhsul bazada mövcud olmadığına görə seçim ediləbilmədi", fMessage.enmType.Error);
                return;
            }
            tAmount.Text = 1.ToString();
        }
        //todo Transactiıon cədvəlində əməliyyat nömrəsinə görə qeyd aparacaq. və satış ehsabatında həmin əməliyyat nömrəsinin üzərinə vurduqda o əməliyyat nömrəsindən olan satışları göstərəcək

        public void Payment(string paymentType)
        {
            //Transaction_Report transaction = new Transaction_Report();
            //int rowCount = gridSatisListesi.Rows.Count;
            //double alisfiyattoplam = 0;

            //if (ReturnSales == true)
            //{
            //    #region [...] Qaytarma
            //    if (rowCount > 0)
            //    {
            //        string proccesNo = db.ReturnProccesNo().FirstOrDefault();
            //        Return_Sales returnPos = new Return_Sales();
            //        for (int i = 0; i < rowCount; i++)
            //        {
            //            returnPos.ProccesNo = proccesNo.ToString();
            //            returnPos.ProductID = Convert.ToInt32(gridSatisListesi.Rows[i].Cells["colid"].Value.ToString());
            //            returnPos.Amount = Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["colAmount"].Value.ToString());
            //            returnPos.Total = Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["colTotal"].Value.ToString());
            //            returnPos.PaymentType = paymentType;
            //            returnPos.UserID = Properties.Settings.Default.UserID;
            //            returnPos.Date = DateTime.Now;
            //            returnPos.BranchID = 1;
            //            db.Return_Sales.Add(returnPos);
            //            db.SaveChanges();
            //            Islemler.StokArtir(gridSatisListesi.Rows[i].Cells["colBarcode"].Value.ToString(), Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["colAmount"].Value.ToString()));
            //            alisfiyattoplam += Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["colAlisQiymet"].Value.ToString()) * Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["colAmount"].Value.ToString());
            //        }
            //        switch (paymentType)
            //        {
            //            case "NƏĞD":
            //                //returnPos.Cash = Islemler.DoubleYap(lTotal.Text);
            //                //returnPos.Card = 0;
            //                //transaction.Cash = Islemler.DoubleYap(lTotal.Text);
            //                transaction.Card = 0; break;
            //            case "KART":
            //                returnPos.Cash = 0;
            //                //returnPos.Card = Islemler.DoubleYap(lTotal.Text);
            //                transaction.Cash = 0;
            //                /*           transaction.Card = Islemler.DoubleYap(lTotal.Text);*/
            //                break;
            //            case "NƏĞD - KART":
            //                returnPos.Cash = Islemler.DoubleYap(cash);
            //                returnPos.Card = Islemler.DoubleYap(card);
            //                transaction.Cash = Islemler.DoubleYap(cash);
            //                transaction.Card = Islemler.DoubleYap(card); break;
            //        }
            //        transaction.ProccesNo = proccesNo.ToString();
            //        transaction.ProccesType = "Qaytarma";
            //        transaction.PaymentType = paymentType;

            //        try
            //        {
            //            var control = db.Company.FirstOrDefault();
            //            if (control.Printer is true)
            //            {
            //                Yazdir yazdir = new Yazdir(proccesNo.ToString(), false);
            //                yazdir.YazdirmaBasla();
            //            }
            //        }
            //        catch (Exception)
            //        {
            //            Message("Çap etmək mümkün olmadı..\nTexniki servis ilə əlaqə saxlayın", fMessage.enmType.Error);
            //        }
            //        navigationFrame1.SelectedPage = pageMenu;
            //    }
            //    #endregion
            //}
            //else
            //{
            //    #region [...] Satış
            //    if (rowCount > 0)
            //    {
            //        string proccesNo = db.SalesProccessNo().FirstOrDefault();
            //        Sales_Product sales = new Sales_Product();
            //        for (int i = 0; i < rowCount; i++)
            //        {
            //            sales.ProccesNo = proccesNo.ToString();
            //            sales.ProductID = Convert.ToInt32(gridSatisListesi.Rows[i].Cells["colid"].Value.ToString());
            //            sales.Amount = Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["colAmount"].Value.ToString());
            //            sales.PaymentType = paymentType;
            //            sales.SalePrice = Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["colPrice"].Value.ToString());
            //            sales.Total = Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["colTotal"].Value.ToString());
            //            sales.Date = DateTime.Now;
            //            sales.UserID = Properties.Settings.Default.UserID;
            //            db.Sales_Product.Add(sales);
            //            db.SaveChanges();
            //            Islemler.StokAzalt(gridSatisListesi.Rows[i].Cells["colBarcode"].Value.ToString(), Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["colAmount"].Value.ToString()));
            //            alisfiyattoplam += Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["colAlisQiymet"].Value.ToString()) * Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["colAmount"].Value.ToString());
            //        }


            //        switch (paymentType)
            //        {
            //            case "NAĞD":
            //                //transaction.Cash = Islemler.DoubleYap(lTotal.Text);
            //                transaction.Card = 0;
            //                break;
            //            case "KART":
            //                transaction.Cash = 0;
            //                //transaction.Card = Islemler.DoubleYap(lTotal.Text);
            //                break;
            //            case "NAĞD-KART":
            //                transaction.Cash = Islemler.DoubleYap(cash);
            //                transaction.Card = Islemler.DoubleYap(card);
            //                break;
            //        }

            //        transaction.ProccesNo = proccesNo.ToString();
            //        transaction.ProccesType = "Satış";
            //        transaction.PaymentType = paymentType;
            //        transaction.TicketNo = null;
            //        transaction.Fiscall_id = null;
            //        transaction.Branch_ID = 1;
            //        try
            //        {
            //            var control = db.Company.First();
            //            if (control.Printer is true)
            //            {
            //                Yazdir yazdir = new Yazdir(proccesNo.ToString(), true);
            //                yazdir.YazdirmaBasla();
            //            }
            //        }
            //        catch (Exception)
            //        {
            //            Message("Çap etmək mümkün olmadı..\nTexniki servis ilə əlaqə saxlayın", fMessage.enmType.Error);
            //        }
            //        navigationFrame1.SelectedPage = pageMenu;
            //    }
            //    #endregion
            //}
            //transaction.Id = Guid.NewGuid();
            ////transaction.Total = Islemler.DoubleYap(lToplam.Text);
            //transaction.Date = DateTime.Now;
            //db.Transaction_Report.Add(transaction);
            //db.SaveChanges();
            //bReturn.Appearance.BackColor = Color.White;
            //bReturn.ImageOptions.SvgImage = Properties.Resources.return_black;
            //lProccessNo.Text = db.SalesProccessNo().First().ToString();
            //ReturnSales = false;
            //Clear();
        }

        void Clear()
        {
            //tAmount.Text = "1";
            //tBarcode.Text = null;
            ////lTotal.Text = 0.ToString("C2");
            //gridSatisListesi.Rows.Clear();
            //tBarcode.Focus();
            //lProccessNo.Text = db.SalesProccessNo().FirstOrDefault();
            //var salesResult = db.Transaction_Report.Where(x => DbFunctions.TruncateTime(x.Date) == DateTime.Today && x.ProccesType == "Satış");
            //if (salesResult.Any())
            //    lSalesCount.Text = salesResult.Count().ToString();
            //else
            //    lSalesCount.Text = 0.ToString();
        }

        private void bPayment_Click(object sender, EventArgs e)
        {
            if (gridProducts.RowCount > 0)
            {

            }
        }

        void AuthorizationControl()
        {
            if (UserValidation.AuthorizationControl(CurrentUser, role => role.PosSales))
            {
                bPay.Cursor = Cursors.Default;
            }
            if (UserValidation.AuthorizationControl(CurrentUser, role => role.PosReturn))
            {
                bReturn.Cursor = DefaultCursor;
            }
            if (UserValidation.AuthorizationControl(CurrentUser, role => role.MoneyBox))
            {
                bKassa.Cursor = DefaultCursor;
            }
        }

        private void fBarcodeSalesUI_Load(object sender, EventArgs e)
        {
            AuthorizationControl();
            dataList = new BindingList<GridData>();
            gridControlProducts.DataSource = dataList;
            lDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
            //lProccessNo.Text = db.SalesProccessNo().First();
            //var salesResult = db.Transaction_Report.Where(x => DbFunctions.TruncateTime(x.Date) == DateTime.Today && x.ProccesType == "Satış");
            //if (salesResult.Any())
            //    lSalesCount.Text = salesResult.Count().ToString();
            //else
            //    lSalesCount.Text = salesResult.Count().ToString();

            //dataList = new BindingList<GridData>();
            //gridControlProducts.DataSource = dataList;
        }


        #region ÖDƏNİŞ

        public string cash, card, fQaliq;

        private void bBonus_Click(object sender, EventArgs e)
        {
            Message("Tezliklə xidmətinizdə..", fMessage.enmType.Info);
        }

        private void lRemove_Click(object sender, EventArgs e)
        {
            tBarcode.Text = null;
        }

        private bool ReturnSales = false;

        private void bSearch_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fSearch>();
        }

        private void bReturn_Click(object sender, EventArgs e)
        {
            FormHelpers.HasPermission(() =>
            {
                if (gridProducts.RowCount != 0)
                {
                    navigationFrameRight.SelectedPage = pageRightPayments;
                }
            });
        }

        #endregion


        private void bCategory_Click(object sender, EventArgs e)
        {
            navigationPanel.SelectedPage = pageCategory;
            //GetCategory();
        }

        private void labelControl8_Click(object sender, EventArgs e)
        {
            navigationPanel.SelectedPage = pageSales;
        }

        void GetCategory()
        {
            flowLayoutCategory.Controls.Clear();
            if (db.Categories.Any())
            {
                foreach (var item in db.Categories.OrderBy(x => x.Id).ToList())
                {
                    controlCategoryButton category = new controlCategoryButton
                    {
                        Name = item.CategoryName.ToString(),
                        Text = item.CategoryName,
                        Id = item.Id,
                        Height = 40,
                        Width = 150,
                        GroupIndex = 1,
                        //Products = db.Products.Where(x => x.CategoryID == item.Id).ToList(),
                        AllowFocus = false,
                        ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False,
                        Font = new Font("Nunito", 12, FontStyle.Bold),
                    };
                    category.CheckedChanged += SelectCategory;
                    flowLayoutCategory.Controls.Add(category);
                    if (category.TabIndex is 0) { category.Checked = true; }
                }
            }
            else
            {
                Message("Kateqoriya tapılmadı.\nYeni kateqoriya yaradın", fMessage.enmType.Error);
            }
        }

        private void lCalc_Click(object sender, EventArgs e)
        {
            fRelacementPage f = new fRelacementPage();
            f.Operations = "Barcode";
            if (f.ShowDialog() is DialogResult.OK)
            {
                tBarcode.Text = f.Barcode;
                tBarcode_KeyDown(null, new KeyEventArgs(Keys.Enter));
            }
        }

        private void bPaymentsBack_Click(object sender, EventArgs e)
        {
            navigationFrameRight.SelectedPage = pageRigtSales;
        }

        private void bPay_Click(object sender, EventArgs e)
        {
            FormHelpers.HasPermission(() =>
            {
                if (gridProducts.RowCount != 0)
                {
                    navigationFrameRight.SelectedPage = pageRightPayments;
                }
            });
        }

        private void SelectCategory(object sender, EventArgs e)
        {
            flowLayoutProducts.Controls.Clear();
            controlCategoryButton button = (controlCategoryButton)sender;
            foreach (var item in button.Products)
            {
                userBtnCategory productButton = new userBtnCategory
                {
                    Name = item.Id.ToString(),
                    MehsulAdi = item.ProductName,
                    Barcode = item.Barcode,
                    ProductGroup = item.Categories.CategoryName,
                    Height = 220,
                    Width = 200,
                    ProductPrice = item.SalePrice.ToString(),
                };
                productButton.ButtonClick += ProductClick;
                flowLayoutProducts.Controls.Add(productButton);
            }
        }

        private void fBarcodeSalesUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tCash_EditValueChanged(object sender, EventArgs e)
        {
            CashValueChanged();
        }

        private void tCard_EditValueChanged(object sender, EventArgs e)
        {
            CardEditValueChanged();
        }

        void CashValueChanged()
        {
            decimal cash = DecimalConvert(tCash.EditValue.ToString());
            //decimal card = DecimalConvert(tCard.EditValue.ToString());
            decimal total = DecimalConvert(tTotal.EditValue.ToString());
            if (cash < total)
            {
                tCard.EditValue = total - cash;
            }
            else if (cash >= total)
            {
                tCard.EditValue = 0;
                tQaliq.EditValue = total - cash;
            }
        }

        void CardEditValueChanged()
        {
            //decimal cash = DecimalConvert(tCash.EditValue.ToString());
            decimal card = DecimalConvert(tCard.EditValue.ToString());
            decimal total = DecimalConvert(tTotal.EditValue.ToString());

            if (card < total)
            {
                tCash.EditValue = total - card;
            }
            else if (card > total)
            {
                tCard.EditValue = total;
            }
            else if (card >= total)
            {
                tCash.EditValue = 0;
                tQaliq.EditValue = total - card;
            }
        }

        private void tTotal_EditValueChanged(object sender, EventArgs e)
        {
            decimal cash = DecimalConvert(tCash.EditValue.ToString());
            decimal card = DecimalConvert(tCard.EditValue.ToString());
            decimal total = DecimalConvert(tTotal.EditValue.ToString());
            CardEditValueChanged();
            CashValueChanged();
            //tQaliq.EditValue = (cash + card) + total;
        }

        decimal DecimalConvert(string _amount)
        {
            return Decimal.Parse(_amount);
        }
        Double DoubleConvert(string _amount)
        {
            return Double.Parse(_amount);
        }


        private void bNisye_Click(object sender, EventArgs e)
        {
           
        }

        private void bKassa_Click(object sender, EventArgs e)
        {
            fPOS f = new fPOS();
            f.ShowDialog();
        }

        private void ProductClick(object sender, EventArgs e)
        {
            userBtnCategory button = (userBtnCategory)sender;
            MehsulGetirEkrana(button.MehsulAdi, button.Barcode, Convert.ToInt32(tAmount.Text), button.ProductGroup, Convert.ToDouble(button.ProductPrice.Replace(" AZN", "")));
            navigationPanel.SelectedPage = pageSales;
        }

        void MehsulGetirEkrana(string ProductName, string Barcode, int Amount, string ProductGroup, double SalesPrice)
        {
            try
            {
                int satirsayisi = gridSatisListesi.Rows.Count;
                bool eklenmismi = false;
                if (satirsayisi > 0)
                {
                    for (int i = 0; i < satirsayisi; i++)
                    {
                        if (gridSatisListesi.Rows[i].Cells["colBarcode"].Value.ToString() == Barcode)
                        {
                            gridSatisListesi.Rows[i].Cells["colAmount"].Value = Amount + Convert.ToDouble(gridSatisListesi.Rows[i].Cells["colAmount"].Value);
                            gridSatisListesi.Rows[i].Cells["colTotal"].Value = Math.Round(Convert.ToDouble(gridSatisListesi.Rows[i].Cells["colAmount"].Value) * Convert.ToDouble(gridSatisListesi.Rows[i].Cells["colPrice"].Value), 2);
                            eklenmismi = true;
                        }
                    }
                }
                try
                {
                    if (!eklenmismi)
                    {
                        gridSatisListesi.Rows.Add();
                        //gridSatisListesi.Rows[satirsayisi].Cells["colid"].Value = urun.Mehsulid;
                        gridSatisListesi.Rows[satirsayisi].Cells["colBarcode"].Value = Barcode;
                        gridSatisListesi.Rows[satirsayisi].Cells["colProductName"].Value = ProductName;
                        gridSatisListesi.Rows[satirsayisi].Cells["colCategory"].Value = ProductGroup;
                        gridSatisListesi.Rows[satirsayisi].Cells["colAmount"].Value = Amount;
                        gridSatisListesi.Rows[satirsayisi].Cells["colVahid"].Value = "ƏDƏD";
                        gridSatisListesi.Rows[satirsayisi].Cells["colPrice"].Value = SalesPrice;
                        gridSatisListesi.Rows[satirsayisi].Cells["colTotal"].Value = Math.Round(Amount * (double)SalesPrice, 2);
                        gridSatisListesi.Rows[satirsayisi].Cells["colAlisQiymet"].Value = 0;
                    }
                }
                catch (NullReferenceException)
                {
                    Message("Bazada məhsul yoxdur", fMessage.enmType.Error);
                    return;
                }
                //Message(ProductName + " əlavə edildi", fMessage.enmType.Success);
            }
            catch (NullReferenceException)
            {
                Message("Məhsul bazada mövcud olmadığına görə seçim ediləbilmədi", fMessage.enmType.Error);
                return;
            }
            tAmount.Text = 1.ToString();
        }
    }
}