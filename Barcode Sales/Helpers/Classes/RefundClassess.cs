using Barcode_Sales.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Barcode_Sales.Helpers.Classes.SaleClasses;

namespace Barcode_Sales.Helpers.Classes
{
    public static class RefundClassess
    {
        public abstract class BaseData
        {
            public string IpAddress { get; set; }
            public string AccessToken { get; set; }
            public int SaleDataId { get; set; }
        }

        public class DataItem
        {
            public short RowNo { get; set; }
            public int Id { get; set; }
            public string ProductName { get; set; }
            public double SalePrice { get; set; }
            public double Discount { get; set; } = 0;
            public double Total
            {
                get => Math.Floor((SalePrice * Amount - Discount) * 100) / 100;
            }
            public double? PurchasePrice { get; set; }
            public double? PurchaseSum { get => PurchasePrice * Amount; }
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
                    var taxType = Enum.GetValues(typeof(Enums.NkaTaxType))
                       .Cast<Enums.NkaTaxType>()
                       .FirstOrDefault(x => Enums.GetEnumDescription(x) == Tax);

                    return (int)taxType;

                }
            }
        }

        public class Data : BaseData
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
            public string LongFiskalId { get; set; }
            public string document_number { get; set; }
            public string ShortFiskalId { get; set; }
            public BindingList<DataItem> Items { get; set; } = new BindingList<DataItem>();
        }
    }
}
