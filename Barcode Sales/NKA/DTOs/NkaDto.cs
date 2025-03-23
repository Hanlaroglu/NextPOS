using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.NKA.DTOs
{
    public class NkaDto
    {
        public class LoginDto
        {
            public string IpAddress { get; set; }
            public string CashRegisterFactoryNumber { get; set; }
        }
        public class ShiftDto
        {
            public string IpAddress { get; set; }
            public string AccessToken { get; set; }
            public string MerchantId { get; set; } // Sadəcə AzSmart kassası istifadə edir
            public string Cashier { get; set; }
        }
    }
}
