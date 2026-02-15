using System;
using System.ComponentModel;
using System.Linq;
using Barcode_Sales.DTOs;

namespace Barcode_Sales.Helpers.Classes
{
    public static class SaleClasses
    {
        public abstract class BaseSaleData
        {
            public string IpAddress { get; set; }
            public string AccessToken { get; set; }
        }

        public class SaleDataItem
        {
            public short RowNo { get; set; }
            public int Id { get; set; }
            public string ProductName { get; set; }
            public decimal SalePrice { get; set; }
            public decimal Discount { get; set; } = 0;
            public decimal Total
            {
                get => Math.Floor((SalePrice * Amount - Discount) * 100) / 100;
            }
            public decimal? PurchasePrice { get; set; }
            public decimal? PurchaseSum { get => PurchasePrice * Amount; }
            public decimal Amount { get; set; } = 1;
            public int UnitId { get; set; }
            public string UnitName => DefinitionDto.GetUnitName(UnitId);
            public int TaxId { get; set; }
            public string TaxName => DefinitionDto.GetTaxName(TaxId);
            public string Barcode { get; set; }
        }

        public class SaleData : BaseSaleData
        {
            public decimal Total => Items?.Sum(x => x.Total) ?? 0;
            public decimal Cash { get; set; }
            public decimal Card { get; set; }
            public decimal IncomingSum { get; set; }
            public decimal Deposit { get; set; } = 0;
            public decimal Credit { get; set; } = 0;
            public decimal Bonus { get; set; } = 0;
            public string Cashier { get; set; }
            public string RRN { get; set; } = null;
            public string CustomerName { get; set; } = null; //Test üçün istifadə olunur. Digər hallarda Customer classsindan istifadə olunacaq
            public Customer Customer { get; set; }
            public string Note { get; set; } = null;
            public BindingList<SaleDataItem> Items { get; set; } = new BindingList<SaleDataItem>();
        }

        public class PosChangeType
        {
            public string ProductName { get; set; }
            public decimal Amount { get; set; }
            public Enums.PosChangeType ChangeType { get; set; }
        }
    }
}