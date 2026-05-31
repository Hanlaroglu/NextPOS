using Barcode_Sales.DTOs;
using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Services.CacheServices;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
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
    public partial class fStockReport : DevExpress.XtraEditors.XtraForm
    {
        IProductOperation productOperation = new ProductManager();

        public fStockReport()
        {
            InitializeComponent();
        }

        private void fStockReport_Shown(object sender, EventArgs e)
        {
            dateStart.DateTime = DatetimeService.CurrentDateTime;
            dateStart.Properties.MaxDate = DatetimeService.CurrentDateTime;
            GetReport();
        }

        private async void GetReport()
        {
            var data = await productOperation.StockReport();

            FormHelpers.ControlLoad(data, gridControl1);

            gridControl1.DataSource = data;

            gridView1.Columns["Quantity"].Summary.Clear();
            gridView1.Columns["PurchasePrice"].Summary.Clear();
            gridView1.Columns["SalePrice"].Summary.Clear();
            GridColumnSummaryItem stockSum = new GridColumnSummaryItem
            {
                FieldName = "Quantity",
                SummaryType = DevExpress.Data.SummaryItemType.Sum,
                DisplayFormat = "{0:N2}"
            };
            GridColumnSummaryItem PuchaseSum = new GridColumnSummaryItem
            {
                FieldName = "PurchasePrice",
                SummaryType = DevExpress.Data.SummaryItemType.Sum,
                DisplayFormat = "{0:N2}",

            };
            GridColumnSummaryItem SaleSum = new GridColumnSummaryItem
            {
                FieldName = "SalePrice",
                SummaryType = DevExpress.Data.SummaryItemType.Sum,
                DisplayFormat = "{0:N2}",
            };

            gridView1.Columns["Quantity"].Summary.Add(stockSum);
            gridView1.Columns["PurchasePrice"].Summary.Add(PuchaseSum);
            gridView1.Columns["SalePrice"].Summary.Add(SaleSum);
        }

        private void gridView1_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (e.Column.SummaryItem.SummaryType != DevExpress.Data.SummaryItemType.Sum)
                return;

            decimal value = 0;
            if (e.Info.Value != null && decimal.TryParse(e.Info.Value.ToString(), out value))
            {
                if (e.Column.FieldName != "Quantity")
                    e.Info.DisplayText = value.ToString("C2");
            }
            e.Handled = true;

            e.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            e.Appearance.ForeColor = Color.AliceBlue;
            e.Appearance.Font = new Font("Nunito", 10, FontStyle.Bold);

            e.Appearance.DrawBackground(e.Cache, e.Bounds);
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
        }

        private void bSearch_Click(object sender, EventArgs e)
        {

        }
    }
}