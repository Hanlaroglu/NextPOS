using System;

namespace Barcode_Sales.Terminals.DTOs
{
    public class PosSaleItemDto
    {
        public short No { get; set; }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseSum
        {
            get => PurchasePrice * Quantity;
        }
        public decimal Quantity { get; set; }
        public int UnitId { get; set; }
        public int TaxId { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total
        {
            get => Math.Floor((SalePrice * Quantity - Discount) / 100) / 100;
        }
        public string Barcode { get; set; }
    }
}
