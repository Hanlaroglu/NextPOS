using Barcode_Sales.Validations;
using System;

namespace Barcode_Sales.Helpers
{
    public class ParseHelpers
    {
        public static double GetConvertStringToDouble(string stringData)
        {
            if (string.IsNullOrWhiteSpace(stringData))
            {
                return 0;
            }
            return Double.Parse(stringData);
        }

        public static short GetConvertStringToInt16(string stringData)
        {
            if (string.IsNullOrWhiteSpace(stringData))
            {
                return 0;
            }
            return Int16.Parse(stringData);
        }

        public static DateTime? StringConvertDatetime(string data)
        {
            if (string.IsNullOrWhiteSpace(data) || data == "<Null>")
            {
                return null;
            }
            DateTime result;
            if (!DateTime.TryParse(data, out result))
            {
                throw new ArgumentException(ValidationHelpers.DatetimeFormatError);
            }
            return result;
        }
    }
}