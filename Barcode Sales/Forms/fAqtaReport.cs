using Barcode_Sales.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
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
    public partial class fAqtaReport : XtraForm
    {
        private BindingList<GridData> dataList;
        public fAqtaReport()
        {
            InitializeComponent();
            dataList = new BindingList<GridData>();
            gridControl1.DataSource = dataList;
            GridRowAddLoad();
        }

        private void GridRowAddLoad()
        {
            /* 
             * Malın adı
             * Ştrixkod
             * Satış qiyməti
             * Buraxılış tarixi
             * Saxlanma müddəti
             * Saxlanma şəraiti
             * Tərkibi
             * */

            #region [... Malın adı ...]

            dataList.Add(new GridData
            {
                ComponentName = "Malın adı",
                FontSize = 10,
                Visible = true,
                X = 10,
                Y = 10,
                AX = false,
                BL = false,
                IT = false,
                OX = false
            });

            #endregion [... Malın adı ...]

            #region [... Satış qiyməti ...]
            dataList.Add(new GridData
            {
                ComponentName = "Satış qiyməti",
                FontSize = 15,
                Visible = true,
                X = 150,
                Y = 50,
                AX = false,
                BL = true,
                IT = false,
                OX = false
            });
            #endregion [... Satış qiyməti ...]

            #region [... Ştrixkod ...]

            dataList.Add(new GridData
            {
                ComponentName = "Ştrixkod",
                FontSize = 15,
                Visible = true,
                X = 150,
                Y = 70,
                AX = false,
                BL = false,
                IT = false,
                OX = false
            });

            #endregion [... Ştrixkod ...]

            //#region [... Buraxılış tarixi ...]
            //dataList.Add(new GridData
            //{
            //    ComponentName = "Buraxılış tarixi",
            //    FontSize = 20,
            //    Visible = false,
            //    X = 10,
            //    Y = 10,
            //    AX = false,
            //    BL = false,
            //    IT = false,
            //    OX = false
            //});
            //#endregion [... Buraxılış tarixi ...]

            //#region [... Saxlanma müddəti ...]
            //dataList.Add(new GridData
            //{
            //    ComponentName = "Saxlanma müddəti",
            //    FontSize = 20,
            //    Visible = false,
            //    X = 10,
            //    Y = 10,
            //    AX = false,
            //    BL = false,
            //    IT = false,
            //    OX = false
            //});
            //#endregion [... Saxlanma müddəti ...]

            //#region [... Saxlanma şəraiti ...]
            //dataList.Add(new GridData
            //{
            //    ComponentName = "Saxlanma şəraiti",
            //    FontSize = 20,
            //    Visible = false,
            //    X = 10,
            //    Y = 10,
            //    AX = false,
            //    BL = false,
            //    IT = false,
            //    OX = false
            //});
            //#endregion [... Saxlanma şəraiti ...]

            //#region [... Tərkibi ...]
            //dataList.Add(new GridData
            //{
            //    ComponentName = "Tərkibi",
            //    FontSize = 20,
            //    Visible = false,
            //    X = 10,
            //    Y = 10,
            //    AX = false,
            //    BL = false,
            //    IT = false,
            //    OX = false
            //});
            //#endregion [... Tərkibi ...]
        }

        private class GridData
        {
            public string ComponentName { get; set; }
            public short FontSize { get; set; }
            public bool Visible { get; set; }
            public short X { get; set; }
            public short Y { get; set; }
            public bool AX { get; set; }
            public bool BL { get; set; }
            public bool IT { get; set; }
            public bool OX { get; set; }
        }

        private void tBarcode_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            tBarcode.Text = FormHelpers.ConvertToEAN13(Guid.NewGuid());
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            //if (pictureEdit1.Image == null)
            //{
            //    // Eğer PictureEdit üzerinde bir resim yoksa yeni bir Bitmap oluşturuyoruz.
            //    Bitmap bmp = new Bitmap(pictureEdit1.Width, pictureEdit1.Height);
            //    pictureEdit1.Image = bmp;
            //}

            //Bitmap currentImage = (Bitmap)pictureEdit1.Image;
            //using (Graphics g = Graphics.FromImage(currentImage))
            //{
            //    // Kırmızı bir dikdörtgen çizelim
            //    Pen pen = new Pen(Color.Red, 3);
            //    g.DrawRectangle(pen, 10, 10, 100, 50);

            //    // Pen'i serbest bırak
            //    pen.Dispose();
            //}

            //pictureEdit1.Refresh();
        }

        private void tProductName_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //fSelectedProduct<fAqtaReport> selectedProduct = new fSelectedProduct<fAqtaReport>(this);
            //selectedProduct.ShowDialog();
        }

        //public override void ReceiveData<T>(T data)
        //{
        //    if (data != null && data is AqtaProducts product)
        //    {
        //        tProductId.Text = product.Id.ToString();
        //        tProductName.Text = product.ProductName;
        //        tBarcode.Text = product.Barcode;
        //        tSalesPrice.EditValue = product.SalePrice;
        //        tReleaseDate.Text = product.ReleaseDate.ToString();
        //        tRetentionPeriod.EditValue = product.RetentionPeriod;
        //        tStorageConditions.Text = product.StorageConditions;
        //        tIngredients.Text = product.Ingredients;
        //    }
        //}

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

        private List<ComponentItem> componentItems = new List<ComponentItem>();
        private void bLoad_Click(object sender, EventArgs e)
        {
            componentItems.Clear();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string componentName = gridView1.GetRowCellValue(i, colComponentName).ToString();

                int fontSize = Convert.ToInt32(gridView1.GetRowCellValue(i, colFontSize));

                bool visible = Convert.ToBoolean(gridView1.GetRowCellValue(i, colVisible));

                float x = (float)Convert.ToDouble(gridView1.GetRowCellValue(i, colX));
                float y = (float)Convert.ToDouble(gridView1.GetRowCellValue(i, colY));

                bool ax = Convert.ToBoolean(gridView1.GetRowCellValue(i, colAX));
                bool bl = Convert.ToBoolean(gridView1.GetRowCellValue(i, colBL));
                bool it = Convert.ToBoolean(gridView1.GetRowCellValue(i, colIT));
                bool ox = Convert.ToBoolean(gridView1.GetRowCellValue(i, colOX));

                FontStyle fontStyle = FontStyle.Regular;

                if (ax) fontStyle |= FontStyle.Underline;      // AX (Bold anlamında)
                if (bl) fontStyle |= FontStyle.Bold;    // BL (Italic anlamında)
                if (it) fontStyle |= FontStyle.Italic; // IT (Altı çizili)
                if (ox) fontStyle |= FontStyle.Strikeout; // OX (Üstü çizili)


                componentItems.Add(new ComponentItem
                {
                    Name = componentName,
                    FontSize = fontSize,
                    Visible = visible,
                    X = x,
                    Y = y,
                    FontStyle = fontStyle
                });

                pictureEdit1.Invalidate();
            }

        }

        public class ComponentItem
        {
            public string Name { get; set; }
            public int FontSize { get; set; }
            public bool Visible { get; set; }
            public float X { get; set; }
            public float Y { get; set; }
            public FontStyle FontStyle { get; set; }
        }

        private void pictureEdit1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Tüm bileşenleri çiz
            foreach (var item in componentItems)
            {
                if (item.Visible)
                {
                    if (item.Name == "Malın adı" && !string.IsNullOrWhiteSpace(tProductName.Text))
                    {
                        g.DrawString(tProductName.Text, new Font("Arial", item.FontSize, item.FontStyle), Brushes.Black, item.X, item.Y);
                    }
                    if (item.Name == "Satış qiyməti" && !string.IsNullOrWhiteSpace(tSalesPrice.Text))
                    {
                        g.DrawString(tSalesPrice.Text, new Font("Arial", item.FontSize, item.FontStyle), Brushes.Black, item.X, item.Y);
                    }
                    if (item.Name == "Ştrixkod" && !string.IsNullOrWhiteSpace(tProductName.Text))
                    {
                        g.DrawString(tBarcode.Text, new Font("Arial", item.FontSize, item.FontStyle), Brushes.Black, item.X, item.Y);
                    }
                }
            }
        }
    }
}