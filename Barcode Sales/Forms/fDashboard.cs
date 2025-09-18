using Barcode_Sales.DTOs;
using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        ISaleDataOperation saleDataOperation = new SalesDataManager();
        ISalesDataDetailOperation salesDataDetailOperation = new SalesDataDetailManager();

        public fDashboard()
        {
            InitializeComponent();
        }

        private async void fDashboard_Load(object sender, EventArgs e)
        {
            //await Task.Delay(500);
            await WeeklyEarningLoadAsync();
            await Top5SellingProductAsync();

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

        private async void accordionControlElement7_Click(object sender, EventArgs e)
        {
            if (navigationMenu.SelectedPage != pageProduct)
            {
                navigationMenu.SelectedPage = pageProduct;
                await Task.Delay(500);
                await ProductDataList();
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

        private async void accordionControlElement29_Click(object sender, EventArgs e)
        {
            if (navigationMenu.SelectedPage != pageStore)
            {
                navigationMenu.SelectedPage = pageStore;
                await StoreDataList();
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
                                            Unit = x.UnitTypes.Name,
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

        private void bEditProduct_Click(object sender, EventArgs e)
        {
            int[] selectedRows = gridProducts.GetSelectedRows();
            foreach (int row in selectedRows)
            {

            }
        }

        private async Task StoreDataList()
        {
            var data = await storeOperation.Where(x => x.IsDeleted == 0)
                                              .Select(x => new
                                              {
                                                  Id = x.Id,
                                                  StoreName = x.StoreName,
                                                  Status = x.Status == true ? "Aktiv" : "Deaktiv",
                                                  IsDeleted = x.IsDeleted
                                              }).ToListAsync();

            FormHelpers.ControlLoad(data, gridControlStore);
        }

        private void lExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fDashboard_Resize(object sender, EventArgs e)
        {
            if (this.Width <= 1400)
            {
                tablePanel24.Columns[3].Visible = false;
            }
            else
            {
                tablePanel24.Columns[3].Visible = true;
            }
        }

        private async void tabPane1_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (tabPane1.SelectedPage == tabMonth)
            {
                await MonthEarningLoadAsync();
            }
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
    }
}