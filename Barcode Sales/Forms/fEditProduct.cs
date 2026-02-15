using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barcode_Sales.Forms
{
    public partial class fEditProduct : DevExpress.XtraEditors.XtraForm
    {
        IWarehouseOperation warehouseOperation = new WarehouseManager();
        ITaxTypeOperation taxTypeOperation = new TaxTypeManager();
        IProductOperation productOperation = new ProductManager();
        private readonly List<Product> _products;


        public fEditProduct(List<Product> products)
        {
            InitializeComponent();
            _products = products;
        }

        private async void fEditProduct_Load(object sender, EventArgs e)
        {
            await TaxDataLoad();
            await WarehouseDataLoad();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            EditData();
        }

        private void EditData()
        {
            foreach (var product in _products)
            {
                //product.SupplierId = (int)lookWarehouse.EditValue;
                product.CategoryId = (int)lookCategory.EditValue;
                product.TaxId = (int)lookTax.EditValue;
                product.Status = (bool)lookStatus.EditValue;
                productOperation.Update(product);
            }
            Close();
        }

        private async Task TaxDataLoad()
        {
            var data = await taxTypeOperation.WhereAsync(null);

            FormHelpers.ControlLoad(data, lookTax);
        }

        private async Task WarehouseDataLoad()
        {
            var data = await warehouseOperation.WhereAsync();

            FormHelpers.ControlLoad(data, lookWarehouse, "Name", "Id");
        }
    }
}