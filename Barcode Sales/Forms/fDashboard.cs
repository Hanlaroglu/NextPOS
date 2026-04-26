using Barcode_Sales.DTOs;
using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
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
        IPosSaleOperation posSaleOperation = new PosSaleManager();
        IPosSaleItemOperation posSaleItemOperation = new PosSaleItemManager();

        public fDashboard()
        {
            InitializeComponent();
        }

        private async void fDashboard_Load(object sender, EventArgs e)
        {
            await WeeklyEarningLoadAsync();
            await Top5SellingProductAsync();
            CurrentSalesDataAsync();
            await CurrentPaymentTypeLoadsAsync();
            CurrentRefundDataAsync();
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

        private void bPopupEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (navigationMenu.SelectedPage == pageWarehouse)
                    WarehouseEdit();
                else if (navigationMenu.SelectedPage == pageStore)
                    StoreEdit();
                else if (navigationMenu.SelectedPage == pageSupplier)
                    SupplierEdit();
                else if (navigationMenu.SelectedPage == pageProduct)
                    ProductEdit();
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
                    WarehouseDelete();
                else if (navigationMenu.SelectedPage == pageStore)
                    StoreDelete();
                else if (navigationMenu.SelectedPage == pageSupplier)
                    SupplierDelete();
                else if (navigationMenu.SelectedPage == pageProduct)
                    ProductDelete();
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

        private async void tabPane3_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (tabPane3.SelectedPage == tabCategory)
            {
                await CategoryDataListAsync();
            }
        }


        #region [.. DASHBOARD ..]

        /// <summary>
        /// Cari satış məbləği
        /// </summary>
        private async void CurrentSalesDataAsync()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var query = posSaleOperation.Where(x => x.SaleDate >= today && x.SaleDate < tomorrow);

            var result = await query.GroupBy(x => 1)
                .Select(c => new
                {
                    Amount = c.Sum(x => (decimal?)x.Total) ?? 0,
                    Count = c.Count()
                })
                .FirstOrDefaultAsync();

            lSalesAmount.Text = result?.Amount.ToString("C2") ?? 0.ToString("C2");
            lSalesCount.Text = result?.Count.ToString("N0") ?? "0";
        }

        private void CurrentRefundDataAsync()
        {
            //lRollbackAmount.Text = returnPosOperation.CurrentAmountTotal().ToString();
            //lRollbackCount.Text = returnPosOperation.CurrentCountTotal().ToString();
        }

        private async Task CurrentPaymentTypeLoadsAsync()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var data = await posSaleOperation.Where(x => x.SaleDate >= today && x.SaleDate < tomorrow)
                .GroupBy(x => 1)
                .Select(c => new
                {
                    TotalCash = c.Sum(x => (decimal?)x.Cash) ?? 0,
                    TotalCard = c.Sum(x => (decimal?)x.Card) ?? 0
                })
                .FirstOrDefaultAsync();

            lCashAmount.Text = data?.TotalCash.ToString("C2") ?? 0.ToString("C2");
            lCardAmount.Text = data?.TotalCard.ToString("C2") ?? 0.ToString("C2");
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
                        //TotalGain = posSaleOperation.Where(x => x.SaleDate == day).Sum(x => x.Total),
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
                        TotalGain = posSaleOperation
                            .Where(x => x.SaleDate.Year == monthDate.Year && x.SaleDate.Month == monthDate.Month)
                            .Sum(x => x.Total)
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
            DateTime now = DateTime.Now;
            // Ayın 1-i (00:00:00)
            DateTime monthStart = new DateTime(now.Year, now.Month, 1);

            // Növbəti ayın 1-i (00:00:00)
            DateTime nextMonthStart = monthStart.AddMonths(1);

            using (KhanposDbEntities db = new KhanposDbEntities())
            {
                var list = await (
                    from sd in db.PosSales
                    join sdd in db.PosSaleItems on sd.Id equals sdd.PosSaleId
                    join p in db.Products on sdd.ProductId equals p.Id
                    where sd.SaleDate >= monthStart
                       && sd.SaleDate < nextMonthStart   // <<< kritik nöqtə
                    group sdd by p.ProductName into g
                    orderby g.Sum(x => x.Quantity) descending
                    select new DashboardStatisticsDto
                    {
                        ProductName = g.Key ?? "Adsız",
                        TotalQuantity = g.Sum(x => x.Quantity)
                    }
                )
                .Take(5)
                .ToListAsync();

                var series = chartTop5Product.Series[0];
                series.DataSource = list;
                series.ArgumentDataMember = "ProductName";
                series.ValueDataMembers.Clear();
                //series.ValueDataMembers.AddRange("TotalQuantity");
                series.ValueDataMembers.AddRange(new[] { "TotalQuantity" });

                //series.Label.TextPattern = "{VP:P2}";
                //series.LegendTextPattern = "{A}";

                chartTop5Product.Titles[0].Text = $"{monthStart.ToString("MMMM yyyy")} üzrə ən çox satılan 5 məhsul";
            }
        }

        #endregion [.. DASHBOARD ..]


        #region [.. WAREHOUSE ..]

        private void bAddWarehouse_Click(object sender, EventArgs e)
        {
            fWarehouse f = new fWarehouse(Enums.Operation.Add, null);
            f.FormClosed += async (s, x) =>
            {
                await WarehouseDataList();
            };
            f.ShowDialog();
        }

        private async void WarehouseEdit()
        {
            var row = gridWarehouse.GetFocusedRow() as WarehousesDto;
            if (row is null) return;

            var data = await warehouseOperation.Get(x => x.Id == row.Id);
            if (data is null)
                return;

            fWarehouse f = new fWarehouse(Enums.Operation.Edit, data);
            f.FormClosed += async (s, x) =>
            {
                await WarehouseDataList();
            };
            f.ShowDialog();
        }

        private async void WarehouseDelete()
        {
            var row = gridWarehouse.GetFocusedRow() as WarehousesDto;
            if (row is null) return;

            var data = await warehouseOperation.Get(x => x.Id == row.Id);

            var args = NotificationHelpers.Dialogs.DialogResultYesNo(
                $"({data.Name}) anbarını silmək istədiyinizə əminsiniz ?", String.Empty);

            var dialog = XtraMessageBox.Show(args);

            if (dialog is DialogResult.Yes)
            {
                var result = await warehouseOperation.Remove(data);
                if (result)
                {
                    await WarehouseDataList();
                    NotificationHelpers.Messages.SuccessMessage(this, $"{data.Name} anbarı uğurla silindi");
                }
            }
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

        private void gridWarehouse_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridViewStatusDisplayColor(gridColumn93, "Aktiv", "Deaktiv", e);
        }

        #endregion [.. WAREHOUSE ..]


        #region [.. STORE ..]

        private void bStoreAdd_Click(object sender, EventArgs e)
        {
            fStoreAdd f = new fStoreAdd(Enums.Operation.Add, null);
            f.FormClosed += async (s, x) =>
            {
                await StoreDataList();
            };
            f.ShowDialog();
        }

        private async void StoreEdit()
        {
            var row = gridStore.GetFocusedRow() as StoresDto;
            if (row is null) return;

            var data = await storeOperation.Get(x => x.Id == row.Id);
            if (data is null)
                return;

            fStoreAdd f = new fStoreAdd(Enums.Operation.Edit, data);
            f.FormClosed += async (s, x) =>
            {
                await StoreDataList();
            };
            f.ShowDialog();
        }

        private async void StoreDelete()
        {
            var row = gridStore.GetFocusedRow() as StoresDto;
            if (row is null) return;

            var data = await storeOperation.Get(x => x.Id == row.Id);

            var args = NotificationHelpers.Dialogs.DialogResultYesNo(
                $"({data.Name}) flialını silmək istədiyinizə əminsiniz ?", String.Empty);

            var dialog = XtraMessageBox.Show(args);

            if (dialog is DialogResult.Yes)
            {
                var result = await storeOperation.Remove(data);
                if (result)
                {
                    await StoreDataList();
                    NotificationHelpers.Messages.SuccessMessage(this, $"{data.Name} flialı uğurla silindi");
                }
            }
        }

        private async void bStoreRefresh_Click(object sender, EventArgs e)
        {
            await StoreDataList();
        }

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

        private void bStoreSetting_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            PopupShow();
        }

        private void gridStore_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridViewStatusDisplayColor(gridColumn109, "Aktiv", "Deaktiv", e);
        }

        #endregion [.. STORE ..]


        #region [.. SUPPLIERS ..]

        private async Task SupplierDataList()
        {
            var data = await supplierOperation.Where(x => x.IsDeleted == false).Select(x => new SupplierDto
            {
                Id = x.Id,
                SupplierName = x.SupplierName,
                Voen = x.Voen,
                Debt = x.Debt,
                Status = x.Status == true ? "Aktiv" : "Deaktiv",
                StatusType = x.Status
            }).ToListAsync();

            FormHelpers.ControlLoad(data, gridControlSuppliers);
        }

        private void bSupplierAdd_Click(object sender, EventArgs e)
        {
            fSupplier f = new fSupplier(Enums.Operation.Add, null);
            f.FormClosed += async (s, x) =>
            {
                await SupplierDataList();
            };
            f.ShowDialog();
        }

        private void bSupplierDebtAdd_Click(object sender, EventArgs e)
        {

        }

        private async void gridSuppliers_DoubleClick(object sender, EventArgs e)
        {
            var row = gridSuppliers.GetFocusedRow() as SupplierDto;
            if (row is null) return;

            var data = await supplierOperation.Get(x => x.Id == row.Id);
            if (data is null)
                return;

            fSupplier f = new fSupplier(Enums.Operation.Show, data);
            f.ShowDialog();
        }

        private async void bSupplierRefresh_Click(object sender, EventArgs e)
        {
            await SupplierDataList();
        }

        private async void SupplierEdit()
        {
            var row = gridSuppliers.GetFocusedRow() as SupplierDto;
            if (row is null) return;

            var data = await supplierOperation.Get(x => x.Id == row.Id);
            if (data is null)
                return;

            fSupplier f = new fSupplier(Enums.Operation.Edit, data);
            f.FormClosed += async (s, x) =>
            {
                await SupplierDataList();
            };
            f.ShowDialog();
        }

        private async void SupplierDelete()
        {
            var row = gridSuppliers.GetFocusedRow() as SupplierDto;
            if (row is null) return;

            var data = await supplierOperation.Get(x => x.Id == row.Id);

            var args = NotificationHelpers.Dialogs.DialogResultYesNo(
                $"({data.SupplierName}) təchizatçısını silmək istədiyinizə əminsiniz ?", String.Empty);

            var dialog = XtraMessageBox.Show(args);

            if (dialog is DialogResult.Yes)
            {
                var result = await supplierOperation.Remove(data);
                if (result)
                {
                    await SupplierDataList();
                    NotificationHelpers.Messages.SuccessMessage(this, $"{data.SupplierName} təchizatçısı uğurla silindi");
                }
            }
        }

        private void gridSuppliers_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridViewStatusDisplayColor(gridColumn79, "Aktiv", "Deaktiv", e);
        }

        private void bSupplierSettings_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            PopupShow();
        }

        #endregion [.. SUPPLIERS ..]


        #region [.. PRODUCTS ..]

        private void bAddProduct_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fAddProduct>(Enums.Operation.Add, null);
        }

        private List<ProductDto> _productList;
        private async void ProductDataList()
        {
            _productList = await productOperation.Where(x => x.IsDeleted == false)
                                        .Select(x => new ProductDto()
                                        {
                                            Id = x.Id,
                                            CategoryName = x.Category.CategoryName,
                                            ProductName = x.ProductName,
                                            Barcode = x.Barcode,
                                            UnitName = x.UnitTypes.Name,
                                            UnitId = x.UnitId,
                                            TaxName = x.TaxTypes.Name,
                                            TaxId = x.TaxId,
                                            SalePrice = x.SalePrice,
                                            Quantity = x.Quantity,
                                            IsActive = x.IsActive,
                                            IsDeleted = x.IsDeleted,
                                        }).ToListAsync();

            FormHelpers.ControlLoad(_productList, gridControlProducts);
        }

        private void bProductRefresh_Click(object sender, EventArgs e)
        {
            ProductDataList();
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

        private async void ProductEdit()
        {
            var row = gridProducts.GetFocusedRow() as ProductDto;
            if (row is null) return;

            var data = await productOperation.Get(x => x.Id == row.Id);

            fAddProduct f = new fAddProduct(Enums.Operation.Edit, data);
            f.FormClosed += (s, x) =>
            {
                ProductDataList();
            };
            f.ShowDialog();
        }

        private async void ProductDelete()
        {
            var row = gridProducts.GetFocusedRow() as ProductDto;
            if (row is null) return;

            var args = NotificationHelpers.Dialogs.DialogResultYesNo(
                $"({row.ProductName}) məhsulunu silmək istədiyinizə əminsiniz ?", String.Empty);

            var result = XtraMessageBox.Show(args);
            if (result is DialogResult.Yes)
            {
                var product = await productOperation.Get(x => x.Id == row.Id);
                var remove = await productOperation.Remove(product);
                if (remove)
                {
                    _productList.Remove(row);
                    gridControlProducts.RefreshDataSource();
                    NotificationHelpers.Messages.SuccessMessage(this, $"{row.ProductName} məhsulu uğurla silindi");
                }
            }
        }

        private void bAddInvoice_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fInvoiceProduct>();
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
            var data = await categoryOperation.CategoriesList();
            ControlLoad(data, gridControlCategory);

            //var data = await categoryOperation.Where(x => x.IsDeleted == false)
            //    .Select(x => new CategoryDto()
            //    {
            //        Id = x.Id,
            //        CategoryName = x.CategoryName,
            //        Status = x.Status,
            //        IsDeleted = x.IsDeleted
            //    }).ToListAsync();

        }

        private async void CategoryEdit()
        {
            var row = gridCategory.GetFocusedRow() as CategoryDto;
            if (row is null) return;

            var data = await categoryOperation.Get(x => x.Id == row.Id);
            if (data is null)
                return;

            fAddCategory f = new fAddCategory(Enums.Operation.Edit, data);
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

            var data = await categoryOperation.Get(x => x.Id == row.Id);

            var args = NotificationHelpers.Dialogs.DialogResultYesNo(
                $"({data.CategoryName}) kateqoriyasını silmək istədiyinizə əminsiniz ?", String.Empty);

            var dialog = XtraMessageBox.Show(args);

            if (dialog is DialogResult.Yes)
            {
                var result = await categoryOperation.Remove(data);
                if (result)
                {
                    await CategoryDataListAsync();
                    NotificationHelpers.Messages.SuccessMessage(this, $"{data.CategoryName} kateqoriyası uğurla silindi");
                }
            }
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
            var data = await customerOperation.Where(x => x.IsDeleted == false)
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
                var data = await customerOperation.Get(x => x.Id == (int)Id);
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
            var data = await customerOperation.Get(x => x.Id == (int)Id);

            var args = NotificationHelpers.Dialogs.DialogResultYesNo(
                $"{data.NameSurname} müştərisini silmək istədiyinizə əminsiniz ?", String.Empty);
            var result = XtraMessageBox.Show(args);

            if (result is DialogResult.Yes)
            {
                await customerOperation.Remove(data);
                await CustomerDataListAsync();
                NotificationHelpers.Messages.SuccessMessage(this, $"{data.NameSurname} müştərisi uğurla silindi");
            }


        }

        #region [.. CUSTOMERS GROUP ..]

        private async Task CustomerGroupDataListAsync()
        {
            var data = await customerGroupOperation.ToListAsync(x => x.IsDeleted == false);
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
                await customerGroupOperation.Remove(row);
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

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            navigationMenu.SelectedPage = pageProduct;
            ProductDataList();
        }

        private async void accordionControlElement22_Click(object sender, EventArgs e)
        {
            if (navigationMenu.SelectedPage != pageWarehouse)
            {
                navigationMenu.SelectedPage = pageWarehouse;
                await WarehouseDataList();
            }
        }

        private void accordionControlElement29_Click(object sender, EventArgs e)
        {
            if (navigationMenu.SelectedPage != pageStore)
            {
                navigationMenu.SelectedPage = pageStore;
                StoreDataList();
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

        private void accordionControlElement11_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fKassalar>();
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fInvoiceReport>();
        }

        private void accordionControlElement37_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fStockReport>();
        }
    }
}