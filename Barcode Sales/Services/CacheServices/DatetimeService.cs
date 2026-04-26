using System;

namespace Barcode_Sales.Services.CacheServices
{
    public class DatetimeService
    {
        public static DateTime CurrentDateTime
        {
            get
            {
                return DateTime.Now;
            }
        }

        public static string CurrentDateString
        {
            get
            {
                return DateTime.Now.ToString("dd.MM.yyyy");
            }
        }

        public static DateTime FirstDayOfCurrentMonth
        {
            get
            {
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
        }
    }
}
