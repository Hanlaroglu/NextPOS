using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Barcode_Sales.Product
{
    public partial class fSelectProduct : FormBase
    {
        private readonly Warehouses Warehouse ;
        IProductOperation productOperation = new ProductManager();

        public fSelectProduct(Warehouses _warehouse)
        {
            InitializeComponent();
            Warehouse = _warehouse;
        }

        private void fSelectProduct_Load(object sender, EventArgs e)
        {
            ProductDataLoad();
        }

        private void ProductDataLoad()
        {
            var data = productOperation.WhereAsync(x => x.IsDeleted == CommonData.DEFAULT_INT).Result;
            gridControlProducts.DataSource = data.ToList();
        }

        private void gridProducts_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1) // Sol klikdə və tək klikdə işə düşür
            {
                GridView view = sender as GridView;
                if (view != null && view.FocusedRowHandle >= 0)
                {
                    //Id = Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, colId));
                    //ProductCode = view.GetRowCellValue(view.FocusedRowHandle, colProductCode).ToString();
                    //MehsulAdi = view.GetRowCellValue(view.FocusedRowHandle, colProductName).ToString();
                    //Barcode = view.GetRowCellValue(view.FocusedRowHandle, colBarcode).ToString();
                    //AlisQiymeti = Convert.ToDouble(view.GetRowCellValue(view.FocusedRowHandle, colAlisQiymet));
                    //DialogResult = DialogResult.OK;
                }
            }
        }
    }
}