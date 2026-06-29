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
using Barcode_Sales.Services.CacheServices;

namespace Barcode_Sales.Forms
{
    public partial class fChartTest : DevExpress.XtraEditors.XtraForm
    {
        public fChartTest()
        {
            InitializeComponent();
        }

        private async void fChartTest_Shown(object sender, EventArgs e)
        {
            await Top5SellingProductAsync();
            await DashboardPayType();
        }

        private async Task Top5SellingProductAsync()
        {
            DateTime now = DatetimeService.CurrentDateTime;
            // Ayın 1-i (00:00:00)
            DateTime monthStart = new DateTime(now.Year, now.Month, 1);

            // Növbəti ayın 1-i (00:00:00)
            DateTime nextMonthStart = monthStart.AddMonths(1);

            using (KhanposDbEntities db = new KhanposDbEntities())
            {
                var data = await (
                        from sd in db.PosSales
                        join sdd in db.PosSaleItems on sd.Id equals sdd.PosSaleId
                        join p in db.Products on sdd.ProductId equals p.Id
                        where sd.SaleDate >= monthStart
                              && sd.SaleDate < nextMonthStart   // <<< kritik nöqtə
                        group sdd by p.ProductName into g
                        orderby g.Sum(x => x.Quantity) descending
                        select new DashboardTopSaleProduct
                        {
                            ProductName = g.Key,
                            TotalQuantity = g.Sum(x => x.Quantity)
                        }
                    )
                    .Take(5)
                    .ToListAsync();

                var series = chartTop5Product.Series[0];
                series.DataSource = data;
                series.ArgumentDataMember = "ProductName";
                series.ValueDataMembers.Clear();
                series.ValueDataMembers.AddRange(new[] { "TotalQuantity" });

                series.Label.TextPattern = "{A}";
                series.LegendTextPattern = "{A} - Say: {V:N2}";
            }
        }

        private async Task DashboardPayType()
        {
            DateTime currentDate = DatetimeService.CurrentDateTime.Date;

            var list = new List<DashboardSaleTypeDto>();

            using (KhanposDbEntities db = new KhanposDbEntities())
            {
                var result = await db.PosSales
                    .Where(s => s.SaleDate == currentDate)
                    .GroupBy(s => 1)
                    .Select(g => new
                    {
                        Cash = g.Sum(s => s.Cash),
                        Card = g.Sum(s => s.Card),
                        Total = g.Sum(s => s.Total)
                    })
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    list.Add(new DashboardSaleTypeDto { PaymentName = "Nağd", Amount = result.Cash });
                    list.Add(new DashboardSaleTypeDto { PaymentName = "Kart", Amount = result.Card });
                }

                var series = chartControl2.Series[0];
                series.DataSource = list;
                series.ArgumentDataMember = "PaymentName";
                series.ValueDataMembers.Clear();
                series.ValueDataMembers.AddRange(new[] { "Amount" });

                series.Label.TextPattern = "{A}: {V:C2}";
                series.LegendTextPattern = "{A}";
            }
        }

        private class DashboardTopSaleProduct
        {
            public string ProductName { get; set; }
            public decimal TotalQuantity { get; set; }
        }

        private class DashboardSaleTypeDto
        {
            public string PaymentName { get; set; }
            public decimal Amount { get; set; }
        }
    }
}