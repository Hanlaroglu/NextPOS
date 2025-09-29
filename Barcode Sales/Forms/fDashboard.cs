using Barcode_Sales.DTOs;
using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Barcode_Sales.Helpers.Enums;
using static Barcode_Sales.Helpers.FormHelpers;

namespace Barcode_Sales.Forms
{
    public partial class fDashboard : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        IWarehouseOperation warehouseOperation = new WarehouseManager();
        IStoreOperation storeOperation = new StoreManager();
        ISupplierOperation supplierOperation = new SupplierManager();
        IProductOperation productOperation = new ProductManager();
        ICategoryOperation categoryOperation = new CategoryManager();
        ICustomerOperation customerOperation = new CustomerManager();
        ICustomerGroupOperation customerGroupOperation = new CustomerGroupManager();
        ISaleDataOperation saleDataOperation = new SalesDataManager();
        ISalesDataDetailOperation salesDataDetailOperation = new SalesDataDetailManager();

        public fDashboard()
        {
            InitializeComponent();
        }

        private async void fDashboard_Load(object sender, EventArgs e)
        {
            await WeeklyEarningLoadAsync();
            await Top5SellingProductAsync();
            await CurrentSalesDataAsync();
            await CurrentPaymentTypeLoadsAsync();

        }

        private void ScreenREsolution()
        {
            var width = Screen.PrimaryScreen.Bounds.Width;
            var height = Screen.PrimaryScreen.Bounds.Height;

            if (width <= 1366 && height <= 768)
            {
                tablePanel1.Columns[3].Visible = false;
            }
        }

        private void PopupShow()
        {
            Point mousePosition = Control.MousePosition;
            popupMainMenu.ShowPopup(mousePosition);
        }

        private void bAddProduct_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fAddProduct>(Enums.Operation.Add, null);
        }

        private async void tabPane3_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (tabPane3.SelectedPage == tabCategory)
            {
                await CategoryDataListAsync();
            }
        }


        #region [.. DASHBOARD ..]

        private async Task CurrentSalesDataAsync()
        {
            lSalesAmount.Text = await saleDataOperation.CurrentSalesDataAsync();
            lSalesCount.Text = await saleDataOperation.CurrentSalesCountAsync();
        }

        private async Task CurrentPaymentTypeLoadsAsync()
        {
            var totals = await saleDataOperation.CurrentPaymentTypeDataAsync();
            lCashAmount.Text = totals.TotalCash.ToString("C2");
            lCardAmount.Text = totals.TotalCard.ToString("C2");
        }

        private async Task WeeklyEarningLoadAsync()
        {
            DateTime today = DateTime.Today;

            int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime weekFirstDay = today.AddDays(-diff);

            var list = await Task.Run(() =>
            {
                return Enumerable.Range(0, 7)
                .Select(i =>
                {
                    var day = weekFirstDay.AddDays(i);

                    var name = (Enums.Week)(((int)day.DayOfWeek + 6) % 7);

                    return new DashboardStatisticsDto
                    {
                        Day = Enums.GetEnumDescription(name),
                        Date = day,
                        TotalGain = saleDataOperation
                            .Where(x => x.SaleDate.HasValue && DbFunctions.TruncateTime(x.SaleDate) == day)
                            .Sum(x => x.Total) ?? 0
                    };
                })
                .ToList();
            });

            chartControl1.Series[0].DataSource = list;
            chartControl1.Series[0].ArgumentDataMember = "Day";
            chartControl1.Series[0].ValueDataMembers.Clear();
            chartControl1.Series[0].ValueDataMembers.AddRange(new[] { "TotalGain" });
        }

        private async Task MonthEarningLoadAsync()
        {
            int year = DateTime.Today.Year;
            DateTime startMonth = new DateTime(year, 1, 1);

            var list = await Task.Run(() =>
            {
                return Enumerable.Range(0, 12)
                .Select(i =>
                {
                    var monthDate = startMonth.AddMonths(i);
                    var name = (Enums.Month)monthDate.Month;

                    return new DashboardStatisticsDto
                    {
                        Day = Enums.GetEnumDescription(name),
                        Date = monthDate,
                        TotalGain = saleDataOperation
                            .Where(x => x.SaleDate.Value.Year == monthDate.Year && x.SaleDate.Value.Month == monthDate.Month)
                            .Sum(x => x.Total) ?? 0
                    };
                }).ToList();
            });

            chartControlMonth.Series[0].DataSource = list;
            chartControlMonth.Series[0].ArgumentDataMember = "Day";
            chartControlMonth.Series[0].ValueDataMembers.Clear();
            chartControlMonth.Series[0].ValueDataMembers.AddRange(new[] { "TotalGain" });
        }

        private async Task Top5SellingProductAsync()
        {
            DateTime today = DateTime.Today;
            int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime weekFirstDay = today.AddDays(-diff);
            DateTime weekLastDay = weekFirstDay.AddDays(6);

            using (NextposDBEntities db = new NextposDBEntities())
            {
                var list = await (
                    from sd in db.SalesDatas
                    join sdd in db.SalesDataDetail on sd.Id equals sdd.SaleDataId
                    join p in db.Products on sdd.ProductId equals p.Id
                    where sd.SaleDate >= weekFirstDay && sd.SaleDate <= weekLastDay
                    group sdd by p.ProductName into g
                    orderby g.Sum(x => x.Quantity) descending
                    select new DashboardStatisticsDto
                    {
                        ProductName = g.Key ?? "Adsız",
                        TotalQuantity = g.Sum(x => x.Quantity) ?? 0
                    }
                )
                .Take(5)
                .ToListAsync();

                var series = chartTop5Product.Series[0];
                series.DataSource = list;
                series.ArgumentDataMember = "ProductName";
                series.ValueDataMembers.Clear();
                series.ValueDataMembers.AddRange(new[] { "TotalQuantity" });


                // Pie dilimlerinde sadece yüzde göster
                series.Label.TextPattern = "{VP:P2}";
                series.LegendTextPattern = "{A}";

                if (chartTop5Product.Legends.Count > 1)
                {
                    series.Legend = chartTop5Product.Legends[1]; // Sağ üstteki ek legend
                    chartTop5Product.Legends[1].AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
                    chartTop5Product.Legends[1].AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Top;
                }


                chartTop5Product.Titles[0].Text = $"({weekFirstDay.ToString("dd.MM.yyyy")} - {weekLastDay.ToString("dd.MM.yyyy")}) Çox satılan 5 məhsul";
            }


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
            var data = await warehouseOperation.Where(x => x.IsDeleted == 0)
                .Select(x => new WarehousesDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = (bool)x.Status,
                    IsDeleted = x.IsDeleted
                }).ToListAsync();

            FormHelpers.ControlLoad(data, gridControlWarehouse);
        }

        private void bWarehouseSettings_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            PopupShow();
        }

        private void WarehouseEdit()
        {
            var row = gridWarehouse.GetFocusedRow() as WarehousesDto;
            if (row is null) return;

            fWarehouse f = new fWarehouse(Enums.Operation.Edit, row);
            f.FormClosed += async (s, x) =>
            {
                await WarehouseDataList();
            };
            f.ShowDialog();
        }

        private async Task WarehouseDelete()
        {
            var row = gridWarehouse.GetFocusedRow() as WarehousesDto;
            if (row is null) return;

            var args = NotificationHelpers.Dialogs.DialogResultYesNo(
                $"({row.Name}) anbarını silmək istədiyinizə əminsiniz ?", String.Empty);
            var result = XtraMessageBox.Show(args);
            if (result is DialogResult.Yes)
            {
                warehouseOperation.Remove(row);
                await WarehouseDataList();
                NotificationHelpers.Messages.SuccessMessage(this, $"{row.Name} anbarı uğurla silindi");
            }
        }

        private void gridWarehouse_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridViewStatusDisplayColor(gridColumn93, "Aktiv", "Deaktiv", e);
        }

        #endregion [.. WAREHOUSE ..]


        #region [.. STORE ..]

        private async Task StoreDataList()
        {
            var data = await storeOperation.Where(x => x.IsDeleted == false)
                .Select(x => new StoresDto()
                {
                    Id = x.Id,
                    WarehouseName = x.Warehouse.Name,
                    Name = x.Name,
                    Status = x.Status,
                    IsDeleted = x.IsDeleted
                }).ToListAsync();

            FormHelpers.ControlLoad(data, gridControlStore);
        }

        #endregion [.. STORE ..]


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
                                        .Select(x => new ProductDto()
                                        {
                                            Id = x.Id,
                                            ProductName = x.ProductName,
                                            Barcode = x.Barcode,
                                            UnitName = x.UnitTypes.Name,
                                            UnitId = x.UnitId,
                                            TaxName = x.TaxTypes.Name,
                                            TaxId = x.TaxId,
                                            SalePrice = x.SalePrice,
                                            Amount = x.Amount,
                                            Status = x.Status,
                                            IsDeleted = x.IsDeleted,
                                        }).ToListAsync();

            FormHelpers.ControlLoad(data, gridControlProducts);
        }

        private void bEditProduct_Click(object sender, EventArgs e)
        {
            int[] selectedRows = gridProducts.GetSelectedRows();
            foreach (int row in selectedRows)
            {

            }
        }

        private void chSelectedProducts_CheckedChanged(object sender, EventArgs e)
        {
            if (chSelectedProducts.Checked)
            {
                gridProducts.OptionsSelection.MultiSelect = true;
                bEditProduct.Visible = true;
                bDeleteProduct.Visible = true;
            }
            else
            {
                gridProducts.OptionsSelection.MultiSelect = false;
                bEditProduct.Visible = false;
                bDeleteProduct.Visible = false;
            }
        }

        private void bProductSettings_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            PopupShow();
        }

        private void ProductEdit()
        {
            var row = gridProducts.GetFocusedRow() as ProductDto;
            if (row is null) return;

            //fWarehouse f = new fWarehouse(Enums.Operation.Edit, row);
            //f.FormClosed += async (s, x) =>
            //{
            //    await ProductDataList();
            //};
            //f.ShowDialog();
        }

        private async Task ProductDelete()
        {
            var row = gridProducts.GetFocusedRow() as ProductDto;
            if (row is null) return;

            var args = NotificationHelpers.Dialogs.DialogResultYesNo(
                $"({row.ProductName}) məhsulunu silmək istədiyinizə əminsiniz ?", String.Empty);
            var result = XtraMessageBox.Show(args);
            if (result is DialogResult.Yes)
            {
                productOperation.Remove(row);
                await ProductDataList();
                NotificationHelpers.Messages.SuccessMessage(this, $"{row.ProductName} məhsulu uğurla silindi");
            }
        }

        #endregion [.. PRODUCTS ..]


        #region [.. CATEGORY ..]

        private void bAddCategory_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fAddCategory>(async () =>
            {
                await CategoryDataListAsync();
            }, Operation.Add, null);
        }

        private async Task CategoryDataListAsync()
        {
            var data = await categoryOperation.Where(x => x.IsDeleted == 0)
                .Select(x => new CategoryDto()
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName,
                    Status = x.Status,
                    IsDeleted = x.IsDeleted
                }).ToListAsync();

            FormHelpers.ControlLoad(data, gridControlCategory);
        }

        private void CategoryEdit()
        {
            var row = gridCategory.GetFocusedRow() as CategoryDto;
            if (row is null) return;

            fAddCategory f = new fAddCategory(Enums.Operation.Edit, row);
            f.FormClosed += async (s, x) =>
            {
                await CategoryDataListAsync();
            };
            f.ShowDialog();
        }

        private async Task CategoryDelete()
        {
            var row = gridCategory.GetFocusedRow() as CategoryDto;
            if (row is null) return;

            categoryOperation.Remove(row);
            await CategoryDataListAsync();
        }

        private void gridCategory_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridViewStatusDisplayColor(gridColumn103, "Aktiv", "Deaktiv", e);
        }

        private void bCategorySettings_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            PopupShow();
        }

        #endregion [.. CATEGORY ..]


        #region [.. PRODUCT ROLLBACK INVOICE ..]

        private void bRollBackInvoice_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fInvoiceRollbackProduct>();
        }

        #endregion [.. PRODUCT ROLLBACK INVOICE ..]


        #region [.. CUSTOMERS ..]

        private void bAddCustomer_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fAddCustomer>(async () =>
            {
                await CustomerDataListAsync();
            }, Operation.Add, null);
        }

        private async Task CustomerDataListAsync()
        {
            var data = await customerOperation.Where(x => x.IsDeleted == 0)
                .Select(x => new CustomerDto
                {
                    Id = x.Id,
                    NameSurname = x.NameSurname,
                    GroupName = x.CustomerGroup.Name,
                    Phone = x.Phone,
                    Debt = x.Debt,
                    Balance = x.Balance,
                    UserNameSurname = x.User.NameSurname,
                }).ToListAsync();
            ControlLoad(data, gridControlCustomers);
            FormHelpers.ControlLoad(data, gridControlCustomers);
        }

        private async void CustomerEdit()
        {
            var Id = gridCustomers.GetFocusedRowCellValue("Id");
            if (Id != null)
            {
                var data = await customerOperation.GetByIdAsync((int)Id);
                fAddCustomer f = new fAddCustomer(Enums.Operation.Edit, data);
                f.FormClosed += async (s, x) =>
                {
                    await CustomerDataListAsync();
                };
                f.ShowDialog();
            }
        }

        private async Task CustomerDelete()
        {
            var Id = gridCustomers.GetFocusedRowCellValue("Id");
            if (Id == null) return;
            var data = await customerOperation.GetByIdAsync((int)Id);

            var args = NotificationHelpers.Dialogs.DialogResultYesNo(
                $"{data.NameSurname} müştərisini silmək istədiyinizə əminsiniz ?", String.Empty);
            var result = XtraMessageBox.Show(args);

            if (result is DialogResult.Yes)
            {
                customerOperation.Remove(data);
                await CustomerDataListAsync();
                NotificationHelpers.Messages.SuccessMessage(this, $"{data.NameSurname} müştərisi uğurla silindi");
            }


        }

        #region [.. CUSTOMERS GROUP ..]

        private async Task CustomerGroupDataListAsync()
        {
            var data = await customerGroupOperation.WhereAsync(x => x.IsDeleted == false);
            FormHelpers.ControlLoad(data, gridControlCustomerGroups);
        }

        private void CustomerGroupEdit()
        {
            var row = gridCustomerGroups.GetFocusedRow() as CustomerGroup;
            if (row is null) return;


            fAddCustomerGroup f = new fAddCustomerGroup(Enums.Operation.Edit, row);
            f.FormClosed += async (s, x) =>
            {
                await CustomerGroupDataListAsync();
            };
            f.ShowDialog();
        }

        private async Task CustomerGroupDelete()
        {
            var row = gridCustomerGroups.GetFocusedRow() as CustomerGroup;
            if (row is null) return;

            var args = NotificationHelpers.Dialogs.DialogResultYesNo(
                $"({row.Name}) qrupunu silmək istədiyinizə əminsiniz ?", String.Empty);
            if (XtraMessageBox.Show(args) == DialogResult.Yes)
            {
                customerGroupOperation.Remove(row);
                NotificationHelpers.Messages.SuccessMessage(this, $"{row.Name} qrupu uğurla silindi");
                await CustomerGroupDataListAsync();
            }
        }

        private void bAddCustomerGroups_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fAddCustomerGroup>(async () =>
            {
                await CustomerGroupDataListAsync();
            }, Operation.Add, null);
        }


        #endregion [.. CUSTOMERS GROUP ..]


        #endregion [.. CUSTOMERS ..]


        #region [.. FORM NAVIGATION ..]

        private async void tabPane1_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (tabPane1.SelectedPage == tabMonth)
            {
                await MonthEarningLoadAsync();
            }
        }

        private async void accordionControlElement7_Click(object sender, EventArgs e)
        {
            navigationMenu.SelectedPage = pageProduct;
            await ProductDataList();
        }

        private async void accordionControlElement22_Click(object sender, EventArgs e)
        {
            if (navigationMenu.SelectedPage != pageWarehouse)
            {
                navigationMenu.SelectedPage = pageWarehouse;
                await WarehouseDataList();
            }
        }

        private async void accordionControlElement29_Click(object sender, EventArgs e)
        {
            if (navigationMenu.SelectedPage != pageStore)
            {
                navigationMenu.SelectedPage = pageStore;
                await StoreDataList();
            }
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            if (navigationMenu.SelectedPage != pageMain)
            {
                navigationMenu.SelectedPage = pageMain;
                //await DashboardStockList();
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

        private async void bCustomers_Click(object sender, EventArgs e)
        {
            navigationMenu.SelectedPage = pageCustomers;
            await CustomerDataListAsync();
        }

        private async void bCustomerGroup_Click(object sender, EventArgs e)
        {
            navigationMenu.SelectedPage = pageCustomerGroups;
            await CustomerGroupDataListAsync();
        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fInvoiceRollbackReport>();
        }

        private void accordionControlElement34_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fTerminalSaleReport>();
        }

        private void accordionControlElement30_Click(object sender, EventArgs e)
        {
            fPosSales f = new fPosSales();
            f.ShowDialog();
        }

        private void bAddInvoice_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fInvoiceProduct>();
        }

        private void bCustomerSettings_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            PopupShow();
        }

        private void bCustomerGroupsSettings_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            PopupShow();
        }

        #endregion [.. FORM NAVIGATION ..]


        private void lExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fDashboard_Resize(object sender, EventArgs e)
        {
            if (this.Width <= 1400)
                tablePanel24.Columns[3].Visible = false;
            else
                tablePanel24.Columns[3].Visible = true;
        }

        private void bPopupEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (navigationMenu.SelectedPage == pageWarehouse)
                    WarehouseEdit();
                else if (navigationMenu.SelectedPage == pageProduct && tabPane3.SelectedPage == tabCategory)
                    CategoryEdit();
                else if (navigationMenu.SelectedPage == pageCustomers)
                    CustomerEdit();
                else if (navigationMenu.SelectedPage == pageCustomerGroups)
                    CustomerGroupEdit();
            }
            catch (Exception ex)
            {
                NotificationHelpers.Messages.ErrorMessage(this, ex.Message);
            }
        }

        private async void bPopupDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (navigationMenu.SelectedPage == pageWarehouse)
                    await WarehouseDelete();
                else if (navigationMenu.SelectedPage == pageProduct && tabPane3.SelectedPage == tabCategory)
                    await CategoryDelete();
                else if (navigationMenu.SelectedPage == pageCustomers)
                    await CustomerDelete();
                else if (navigationMenu.SelectedPage == pageCustomerGroups)
                    await CustomerGroupDelete();

            }
            catch (Exception ex)
            {
                NotificationHelpers.Messages.ErrorMessage(this, ex.Message);
            }
        }
    }
}