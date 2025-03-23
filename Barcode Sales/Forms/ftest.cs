using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
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
using DevExpress.Utils.Behaviors;
using DevExpress.Utils.Behaviors.Common;
using Barcode_Sales.Helpers;
using DevExpress.XtraGrid.Localization;
using static Barcode_Sales.Helpers.FormHelpers;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Windows.Forms.DataVisualization.Charting;

namespace Barcode_Sales.Forms
{
    public partial class ftest : DevExpress.XtraEditors.XtraForm
    {
        IProductOperation productOperation = new ProductManager();
        private BindingList<GridData> dataList;
        short rowNo = 1;
        public ftest()
        {
            InitializeComponent();
        }

        private void ftest_Load(object sender, EventArgs e)
        {
            dataList = new BindingList<GridData>();
            gridControlBasket.DataSource = dataList;
            GridLocalizer.Active = new MyGridLocalizer();
            _ = AutoComplete();
        }


        private async Task AutoComplete()
        {
            var data = await productOperation.WhereAsync(x => x.IsDeleted == 0);
            var product = data.Select(x => new SearchData
            {
               Id = x.Id,
               ProductName= x.ProductName,
               SalePrice = x.SalePrice,
               Barcode = x.Barcode,
               Unit = x.Unit
            }).ToList();

            tSearch.Properties.DataSource = product;
            tSearch.Properties.DisplayMember = "ProductName";
            tSearch.Properties.ValueMember = "Id";
        }

        private void tSearch_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                tSearch.EditValueChanged -= tSearch_EditValueChanged;

                var selectedRow = tSearch.Properties.View.GetFocusedRow() as SearchData;
                if (selectedRow == null) return;

                GridData grid = new GridData
                {
                    ProductName = selectedRow.ProductName,
                    SalePrice = (double)selectedRow.SalePrice,
                    Id = selectedRow.Id,
                    Amount = 1,
                    RowNo = rowNo,
                    Barcode = selectedRow.Barcode,
                    Unit = selectedRow.Unit
                };

                dataList.Add(grid);
                rowNo++;

                tSearch.EditValue = null;
            }
            finally
            {
                tSearch.EditValueChanged += tSearch_EditValueChanged;
            }
        }

        private class SearchData
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public double? SalePrice { get; set; }
            public string Barcode { get; set; }
            public string Unit { get; set; }
        }

        private class GridData
        {
            public short RowNo { get; set; }
            public int Id { get; set; }
            public string ProductName { get; set; }
            public double SalePrice { get; set; }
            public double Total  { get { return SalePrice * Amount; } }
            public double Amount { get; set; } = 1;
            public string Unit { get; set; }
            public string Barcode { get; set; }
        }
    }
}