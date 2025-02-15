using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class fSelectedProduct<TParent> : FormBase where TParent:FormBase
    {
        /// <summary>
        /// lookWarehouse kodları yazılmayıb.
        /// Anbar seçiminə görə məhsullar filtrələnmir
        /// </summary>
        IProductOperation productOperation = new ProductManager();
        IAqtaProductsOperation aqtaProductsOperation = new AqtaProductsManager();

        private TParent _parentForm;
        public fSelectedProduct(TParent parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
        }

        private void ProductDataLoad()
        {
            if (_parentForm.Name == "fAqtaReport")
            {
                gridControlProducts.DataSource = aqtaProductsOperation.WhereAsync(x => x.IsDeleted == CommonData.DEFAULT_INT).Result;
                gridProducts.Columns["ProductCode"].Visible = false;
            }
            else
            {
                gridControlProducts.DataSource = productOperation.WhereAsync(x=> x.IsDeleted == CommonData.DEFAULT_INT).Result;
            }
        }

        private void fSelectedProduct_Load(object sender, EventArgs e)
        {
            ProductDataLoad();
        }


        private async void gridProducts_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1) // Sol klikdə və tək klikdə işə düşür
            {
                GridView view = sender as GridView;
                if (view != null && view.FocusedRowHandle >= 0)
                {
                    int Id = Convert.ToInt32(gridProducts.GetFocusedRowCellValue("Id").ToString());
                    object data = null;
                    if (_parentForm.Name == "fAqtaReport")
                    {
                        data = await aqtaProductsOperation.GetByIdAsync(Id);
                    }
                    else
                    {
                        data = await productOperation.GetByIdAsync(Id);
                    }
                    var method = _parentForm.GetType().GetMethod("ReceiveData");
                    if (method != null)
                    {
                        method.MakeGenericMethod(data.GetType()).Invoke(_parentForm, new object[] { data });
                        this.Close();
                    }
                }
            }
        }
    }
}