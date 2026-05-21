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
        public string UnitName => DefinitionDto.GetUnitName(UnitId);
        public int TaxId { get; set; }
        public string TaxName => DefinitionDto.GetTaxName(TaxId);
        public decimal TaxPercent => DefinitionDto.GetVatPercent(TaxId);
        public decimal SalePrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total
        {
            get
            {
                var result = SalePrice * Quantity - Discount;
                return result;
            }
        }
        public string Barcode { get; set; }
    }
}
