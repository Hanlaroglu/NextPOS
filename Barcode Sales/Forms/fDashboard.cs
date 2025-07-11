using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Barcode_Sales.Helpers.FormHelpers;

namespace Barcode_Sales.Forms
{
    public partial class fDashboard : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        IWarehouseOperation warehouseOperation = new WarehouseManager();
        ISupplierOperation supplierOperation = new SupplierManager();
        IProductOperation productOperation = new ProductManager();
        ICategoryOperation categoryOperation = new CategoryManager();

        public fDashboard()
        {
            InitializeComponent();
        }

        private async void accordionControlElement7_Click(object sender, EventArgs e)
        {
            if (navigationMenu.SelectedPage != pageProduct)
            {
                navigationMenu.SelectedPage = pageProduct;
                await Task.Delay(500);
                await ProductDataList();
            }
        }

        private async void accordionControlElement1_Click(object sender, EventArgs e)
        {
            if (navigationMenu.SelectedPage != pageMain)
            {
                navigationMenu.SelectedPage = pageMain;
                await DashboardStockList();
            }
        }

        private async void accordionControlElement5_Click(object sender, EventArgs e)
        {
            if (navigationMenu.SelectedPage != pageSupplier)
            {
                navigationMenu.SelectedPage = pageSupplier;
                await SupplierDataList();
            }
        }

        private void bAddProduct_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fAddProduct>(Enums.Operation.Add, null);
        }

        private async void accordionControlElement22_Click(object sender, EventArgs e)
        {
            if (navigationMenu.SelectedPage != pageWarehouse)
            {
                navigationMenu.SelectedPage = pageWarehouse;
                await WarehouseDataList();
            }
        }

        private async void tabPane3_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (tabPane3.SelectedPage == tabNavigationPage3)
            {
                await CategoryDataList();
            }
        }

        #region [.. DASHBOARD ..]

        private async Task DashboardStockList()
        {
            var data = await productOperation.Where(x => x.IsDeleted == 0)
                                        .Select(x => new
                                        {
                                            Id = x.Id,
                                            ProductName = x.ProductName,
                                            Barcode = x.Barcode,
                                            SalePrice = x.SalePrice,
                                            Quantity = x.Amount,
                                        }).ToListAsync();

            FormHelpers.ControlLoad(data, gridControlDashboardStock);
        }


        #endregion [.. DASHBOARD ..]


        #region [.. WAREHOUSE ..]

        private void bAddWarehouse_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fWarehouse>(Enums.Operation.Add, null);
        }

        private async void bRefreshWarehouse_Click(object sender, EventArgs e)
        {
            await WarehouseDataList();
        }

        private async Task WarehouseDataList()
        {
            var data = await warehouseOperation.Where(x => x.IsDeleted == 0).Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status == true ? "Aktiv" : "Deaktiv",
                IsDelete = x.IsDeleted,
            }).ToListAsync();

            FormHelpers.ControlLoad(data, gridControlWarehouse);
        }

        private void bWarehouseSettings_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Point mousePosition = Control.MousePosition;
            popupMenu1.ShowPopup(mousePosition);
        }

        private void gridWarehouse_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridViewStatusDisplayColor(gridColumn93, "Aktiv", "Deaktiv", e);
        }

        #endregion [.. WAREHOUSE ..]


        #region [.. SUPPLIERS ..]

        private async Task SupplierDataList()
        {
            var data = await supplierOperation.Where(x => x.IsDeleted == 0).Select(x => new
            {
                Id = x.Id,
                SupplierName = x.SupplierName,
                Voen = x.Voen,
                Status = x.Status == true ? "Aktiv" : "Deaktiv",
            }).ToListAsync();

            FormHelpers.ControlLoad(data, gridControlSuppliers);
        }

        private void bSupplierAdd_Click(object sender, EventArgs e)
        {
            OpenForm<fSupplier>(Enums.Operation.Add, null);
        }

        private void gridSuppliers_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridViewStatusDisplayColor(gridColumn89, "Aktiv", "Deaktiv", e);
        }

        #endregion [.. SUPPLIERS ..]


        #region [.. PRODUCTS ..]

        private async Task ProductDataList()
        {
            var data = await productOperation.Where(x => x.IsDeleted == 0)
                                        .Select(x => new
                                        {
                                            Id = x.Id,
                                            ProductName = x.ProductName,
                                            Barcode = x.Barcode,
                                            Unit = x.Unit,
                                            Tax = x.TaxTypes.Name,
                                            SalePrice = x.SalePrice,
                                            Quantity = x.Amount,
                                            IsDeleted = x.IsDeleted,
                                        }).ToListAsync();

            FormHelpers.ControlLoad(data, gridControlProducts);
        }

        private async Task CategoryDataList()
        {
            var data = await categoryOperation.Where(x => x.IsDeleted == 0)
                                              .Select(x => new
                                              {
                                                  Id = x.Id,
                                                  CategoryName = x.CategoryName,
                                                  Status = x.Status == true ? "Aktiv" : "Deaktiv",
                                                  IsDeleted = x.IsDeleted
                                              }).ToListAsync();

            FormHelpers.ControlLoad(data, gridControlCategory);
        }

        private void gridCategory_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridViewStatusDisplayColor(gridColumn103, "Aktiv", "Deaktiv", e);
        }

        #endregion [.. PRODUCTS ..]


    }
}