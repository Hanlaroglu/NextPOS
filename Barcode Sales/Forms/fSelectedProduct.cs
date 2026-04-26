using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System;
using System.Data.Entity;
using System.Linq;
using Barcode_Sales.DTOs;

namespace Barcode_Sales.Forms
{
    public partial class fSelectedProduct : FormBase
    {
        private IProductOperation productOperation = new ProductManager();

        public fSelectedProduct()
        {
            InitializeComponent();
        }

        private void fSelectedProduct_Shown(object sender, EventArgs e)
        {
            DataLoad();
        }

        private async void DataLoad()
        {
            var data = await productOperation
                .Where(x => x.IsDeleted == false && x.IsActive == true)
                .Select(x => new ProductDto
                {
                    CategoryName = x.Category.CategoryName,
                    ProductName = x.ProductName,
                    Barcode = x.Barcode,
                    UnitName = x.UnitTypes.Name,
                    SalePrice = x.SalePrice
                })
                .ToListAsync();

            FormHelpers.ControlLoad(data, gridControlProducts);
        }
    }
}