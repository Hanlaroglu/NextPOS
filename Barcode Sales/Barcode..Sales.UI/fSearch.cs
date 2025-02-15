using Barcode_Sales.Tools;
using System;
using System.Data;
using System.Linq;
using System.Windows;

namespace Barcode_Sales.Barcode.Sales.UI
{
    public partial class fSearch : DevExpress.XtraEditors.XtraForm
    {
        NextposDBEntities db = new NextposDBEntities();

        public fSearch()
        {
            InitializeComponent();
        }

        #region [...] Məhsul adına görə axtarış
        private void tName_EditValueChanged(object sender, EventArgs e)
        {
            string searchQuery = tName.Text;
            if (searchQuery.Length <= 1)
            {
                listComplete.Items.Clear();
                navigationFrame1.SelectedPage = pageNull;
                return;
            }
            tCode.Text = null;
            tBarcode.Text = null;
            var result = db.Products.AsNoTracking().Where(x => x.ProductName.StartsWith(searchQuery)).Select(x => x.ProductName).ToList();

            listComplete.Items.Clear();
            listComplete.Items.AddRange(result.ToArray());
        }
        #endregion [...] Məhsul adına görə axtarış


        #region [...] Məhsul koduna görə axtarış
        private void tCode_EditValueChanged(object sender, EventArgs e)
        {
            string searchQuery = tCode.Text;
            if (searchQuery.Length <= 3)
            {
                listComplete.Items.Clear();
                navigationFrame1.SelectedPage = pageNull;
                return;
            }
            var result = db.Products.AsNoTracking()
                                    .Where(x => x.ProductCode.StartsWith(searchQuery))
                                    .Select(x => x.ProductName).ToList();

            listComplete.Items.Clear();
            listComplete.Items.AddRange(result.ToArray());
        }
        #endregion


        #region [...] Məhsul barkoduna görə axtarış
        private void tBarcode_EditValueChanged(object sender, EventArgs e)
        {
            string searchQuery = tBarcode.Text;
            if (searchQuery.Length <= 3)
            {
                listComplete.Items.Clear();
                navigationFrame1.SelectedPage = pageNull;
                return;
            }
            var result = db.Products.AsNoTracking().Where(x => x.Barcode.StartsWith(searchQuery)).Select(x => x.ProductName).ToList();

            listComplete.Items.Clear();
            listComplete.Items.AddRange(result.ToArray());
        }
        #endregion


        #region [...] Məhsul seçimi edildikdə
        private void listComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listComplete.SelectedItem != null)
            {
                string selectedValue = listComplete.SelectedItem.ToString();
                var search = db.Products.AsNoTracking().Where(x => x.ProductName == selectedValue).FirstOrDefault();

                lProductName.Text = selectedValue.Trim();
                lBarcode.Text = search.Barcode.Trim();
                lPrice.Text = search.SalePrice.ToString() + " AZN";
                lComment.Text = search.Comment.Trim();
                //lStock.Text = search.Amount.ToString() + " " + search.Unit;
                navigationFrame1.SelectedPage = pageProduct;
            }
        }
        #endregion [...] Məhsul seçimi edildikdə

        private void lBarcode_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lBarcode.Text);
            OperationsControl.Message("Barkod kopyalandı", NextPOS.UserControls.fMessage.enmType.Success);
        }
    }
}