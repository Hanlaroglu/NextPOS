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
        public fStockReport()
        {
            InitializeComponent();
        }

        private void fStockReport_Load(object sender, EventArgs e)
        {
            dateStart.DateTime = DateTime.Now;
            dateStart.Properties.MaxDate = DateTime.Now;
            GetReport();
        }

        private void GetReport()
        {
            using (var db = new NextposDBEntities())
            {
                var test = db.Database.SqlQuery<StockReportDto>(@"SELECT
    s.SupplierName        AS SupplierName,
    c.CategoryName        AS CategoryName,
    p.ProductCode         AS ProductCode,
    p.ProductName         AS ProductName,
    p.Barcode             AS Barcode,
    u.Name                AS UnitName,
    t.Name                AS TaxName,
    p.PurchasePrice       AS PurchasePrice,
    p.SalePrice           AS SalePrice,
    p.Amount              AS Amount,
    (p.SalePrice - p.PurchasePrice) * p.Amount AS Profit
FROM Products p
INNER JOIN Suppliers  s ON s.Id = p.SupplierId
INNER JOIN Categories c ON c.Id = p.CategoryId
INNER JOIN UnitTypes  u ON u.Id = p.UnitId
LEFT  JOIN TaxTypes   t ON t.Id = p.TaxId;
").ToList();
                gridControl1.DataSource = test;
                gridView1.Columns["Amount"].Summary.Clear();
                gridView1.Columns["PurchasePrice"].Summary.Clear();
                gridView1.Columns["SalePrice"].Summary.Clear();
                gridView1.Columns["Profit"].Summary.Clear();
                GridColumnSummaryItem stockSum = new GridColumnSummaryItem
                {
                    FieldName = "Amount",
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
                GridColumnSummaryItem ProfitSum = new GridColumnSummaryItem
                {
                    FieldName = "Profit",
                    SummaryType = DevExpress.Data.SummaryItemType.Sum,
                    DisplayFormat = "{0:N2}",

                };
                gridView1.Columns["Amount"].Summary.Add(stockSum);
                gridView1.Columns["PurchasePrice"].Summary.Add(PuchaseSum);
                gridView1.Columns["SalePrice"].Summary.Add(SaleSum);
                gridView1.Columns["Profit"].Summary.Add(ProfitSum);
            }
        }

        private class StockReportDto
        {
            public string SupplierName { get; set; }
            public string CategoryName { get; set; }
            public string ProductCode { get; set; }
            public string ProductName { get; set; }
            public string Barcode { get; set; }
            public string UnitName { get; set; }
            public string TaxName { get; set; }
            public double PurchasePrice { get; set; }
            public double SalePrice { get; set; }
            public double Amount { get; set; }
            public double Profit { get; set; }
        }

        private void gridView1_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            if (e.Column.SummaryItem.SummaryType != DevExpress.Data.SummaryItemType.Sum)
                return;

            decimal value = 0;
            if (e.Info.Value != null && decimal.TryParse(e.Info.Value.ToString(), out value))
            {
                if (e.Column.FieldName != "Amount")
                    e.Info.DisplayText = value.ToString("C2");
            }
            e.Handled = true;

            e.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            e.Appearance.ForeColor = Color.AliceBlue;
            e.Appearance.Font = new Font("Nunito", 10, FontStyle.Bold);

            e.Appearance.DrawBackground(e.Cache, e.Bounds);
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
        }
    }
}