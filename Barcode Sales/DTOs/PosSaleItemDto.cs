using Barcode_Sales.Terminals.DTOs;

namespace Barcode_Sales.DTOs
{
    public class PosSaleItemDto
    {
        public int PosSaleId { get; set; }
        public int PosSaleItemId { get; set; }
        public int ProductId { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public decimal RemainingQuantity { get; set; }
        public decimal PurchasePrice { get; set; }

        public decimal PurchaseSum
        {
            get => PurchasePrice * RefundQuantity;
        }
        public decimal SalePrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount => RemainingQuantity * SalePrice - Discount;
        public int UnitId { get; set; }
        public string UnitName => DefinitionDto.GetUnitName(UnitId);
        public int TaxId { get; set; }
        public string TaxName => DefinitionDto.GetTaxName(TaxId);
        public decimal TaxPercent => DefinitionDto.GetVatPercent(TaxId);
        public decimal RefundQuantity { get; set; } //Qaytarılacaq miqdar
        public decimal RefundTotalAmount
        {
            get
            {
                var result = SalePrice * RefundQuantity - Discount;
                return result;
            }
        }
    }
}
