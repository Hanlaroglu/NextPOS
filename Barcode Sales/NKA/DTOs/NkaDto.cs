using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.NKA.DTOs
{
    public class NkaDto
    {
        public abstract class BaseDto
        {
            public string IpAddress { get; set; }
            public string AccessToken { get; set; }
            public string MerchantId { get; set; } // Sadəcə AzSmart kassaları üçün
        }

        public class LoginDto:BaseDto
        {
            public string CashRegisterFactoryNumber { get; set; }
        }

        public class ShiftDto:BaseDto
        {
            public string Cashier { get; set; }
        }

        public class DepositDto: BaseDto
        {
            public double Amount { get; set; }
            public string Cashier { get; set; }
        }
    }
}
