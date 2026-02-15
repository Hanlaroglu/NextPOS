using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Messages;
using DevExpress.XtraEditors;
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
    public partial class fSelected : DevExpress.XtraEditors.XtraForm
    {
        KhanposDbEntities db = new KhanposDbEntities();
        public string CategoryName { get; set; }
        public fSelected()
        {
            InitializeComponent();
            FormHelpers.GridPanelText(gridCategories);
        }

        private void fSelected_Load(object sender, EventArgs e)
        {
            if (navigationFrame1.SelectedPage == pageCategory)
            {
                panelControl1.Visible = false;
                gridControlCategories.DataSource = db.Categories.AsNoTracking()
                                                                .Where(x => x.Status == true)
                                                                .Where(x => x.IsDeleted == 0)
                                                                .ToList();
            }
        }

        private void gridCategories_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridCategories.GetFocusedRow() == null)
            {
                CommonMessageBox.WarningMessageBox(CommonMessages.NOT_SELECTİON);
                return;
            }
            CategoryName = gridCategories.GetFocusedRowCellValue(colCategoryName).ToString();
            DialogResult = DialogResult.OK;
        }
    }
}