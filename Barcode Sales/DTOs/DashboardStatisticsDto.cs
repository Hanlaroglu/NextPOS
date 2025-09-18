using System;

namespace Barcode_Sales.DTOs
{
    public class DashboardStatisticsDto
    {
        public string Day { get; set; }
        public DateTime Date { get; set; }
        public double TotalGain { get; set; }
        public string ProductName { get; set; }
        public double TotalQuantity { get; set; }
    }
}