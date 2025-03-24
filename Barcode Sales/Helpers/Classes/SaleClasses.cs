using Barcode_Sales.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Sales.Helpers.Classes
{
    public static class SaleClasses
    {
        public class SaleDataItem
        {
            public short RowNo { get; set; }
            public int Id { get; set; }
            public string ProductName { get; set; }
            public double SalePrice { get; set; }
            public double Discount { get; set; } = 0;
            public double Total { get { return (SalePrice * Amount) - Discount; } }
            public double Amount { get; set; } = 1;
            public string Unit { get; set; }
            public string Tax { get; set; }
            public string Barcode { get; set; }

            public int QuantityType
            {
                get
                {
                    return EnumsCache.quantityType.TryGetValue(Unit, out int value) ? value : (int)Enums.UnitTypes.Quantity;
                }
            }

            public int TaxType
            {
                get
                {
                    return EnumsCache.taxType.TryGetValue(Tax, out int value) ? value : (int)Enums.NkaTaxType.Vat18;
                }
            }
        }


        public class SaleData
        {
            public double Total => Items?.Sum(x => x.Total) ?? 0;
            public double Cash { get; set; }
            public double Card { get; set; }
            public double IncomingSum { get; set; }
            public double Deposit { get; set; } = 0;
            public double Credit { get; set; } = 0;
            public double Bonus { get; set; } = 0;
            public string Cashier { get; set; }
            public string RRN { get; set; } = null;
            public string CustomerName { get; set; } = null;
            public Customers Customer { get; set; }
            public string Note { get; set; } = null;
            public BindingList<SaleDataItem> Items { get; set; } = new BindingList<SaleDataItem>();
        }

        public class PosChangeType
        {
            public string ProductName { get; set; }
            public double Amount { get; set; }
            public Enums.PosChangeType ChangeType { get; set; }
        }
    }
}
