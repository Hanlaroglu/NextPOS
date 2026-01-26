using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fAddProductImport : DevExpress.XtraEditors.XtraForm
    {
        DataTableCollection tableCollection;
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
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tFilePath.Text = openFileDialog.FileName;
                    using (var stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            List<string> tableNames = new List<string>();
                            lookUpEdit1.Clear();
                            foreach (System.Data.DataTable table in tableCollection)
                                tableNames.Add(table.TableName);

                            if (tableNames.Count > 0)
                            {
                                lookUpEdit1.Enabled = true;
                                bShowProducts.Visible = true;
                                tFilePath.Properties.Buttons[0].Visible = true;
                                lookUpEdit1.Properties.DataSource = tableNames;
                                lookUpEdit1.Properties.DropDownRows = tableNames.Count > 7 ? 7 : tableNames.Count;
                            }
                        }

                    }
                }
            }
        }

        private void tFilePath_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            tFilePath.Clear();
            lookUpEdit1.Enabled = false;
            bShowProducts.Visible = false;
            tFilePath.Properties.Buttons[0].Visible = false;
            lookUpEdit1.Properties.DataSource = null;
        }
    }
}