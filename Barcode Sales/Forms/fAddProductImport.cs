using Barcode_Sales.Services;
using DevExpress.XtraGrid;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fAddProductImport : DevExpress.XtraEditors.XtraForm
    {
        private readonly ExcelService _excelService = new ExcelService();
        private DataTable _currentTable;
        private string _currentFilePath;
        public fAddProductImport()
        {
            InitializeComponent();
            this.AllowDrop = true;
        }

        private void fAddProductImport_Load(object sender, EventArgs e)
        {

        }

        private void bSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Excell 97-2003 Workbook|.xls|Excell Workbook|*.xlsx",
                FilterIndex = 2,
            })
            {
                Cursor.Current = Cursors.WaitCursor;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _currentFilePath = openFileDialog.FileName;
                    tFilePath.Text = _currentFilePath;

                    var sheetNames = _excelService.GetSheetNames(_currentFilePath);

                    if (sheetNames.Any())
                    {
                        lookSheet.Enabled = true;

                        lookSheet.Properties.DataSource = sheetNames;
                        lookSheet.Properties.DropDownRows = sheetNames.Count > 7 ? 7 : sheetNames.Count;
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void tFilePath_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            tFilePath.Clear();
            lookSheet.Enabled = false;
            bShowProducts.Visible = false;
            tFilePath.Properties.Buttons[0].Visible = false;
            lookSheet.Properties.DataSource = null;
        }

        private void lookSheet_EditValueChanged(object sender, EventArgs e)
        {
            if (lookSheet.EditValue == null) return;

            string selectedSheet = lookSheet.EditValue.ToString();

            _currentTable = _excelService.GetSheetData(_currentFilePath, selectedSheet);

            gridControlImport.DataSource = _currentTable;


            gridImport.OptionsView.ShowColumnHeaders = true;
            gridImport.BestFitColumns();
        }

        private void gridImport_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view.RowCount != 0) return;

            StringFormat drawFormat = new StringFormat();

            drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString("Məlumat tapılmadı", e.Appearance.Font, SystemBrushes.ControlDark, 
                new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);
            gridImport.OptionsView.ShowColumnHeaders = false;
        }

        private void InsertDbProducts()
        {

        }

        private void bImport_Click(object sender, EventArgs e)
        {

        }
    }
}