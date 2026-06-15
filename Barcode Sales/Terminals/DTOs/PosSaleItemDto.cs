namespace Barcode_Sales.Terminals.DTOs
{
    public class PosSaleItemDto
    {
        public short No { get; set; }
        public int Id { get; set; } //productId
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseSum => PurchasePrice * Quantity;
        public decimal Quantity { get; set; }
        public int UnitId { get; set; }
        public string UnitName => DefinitionDto.GetUnitName(UnitId);
        public int TaxId { get; set; }
        public string TaxName => DefinitionDto.GetTaxName(TaxId);
        public decimal TaxPercent => DefinitionDto.GetVatPercent(TaxId);
        private decimal _salePrice;

        public decimal SalePrice
        {
            get => Quantity == 0 ? 0 : (Total - Discount) / Quantity;
            set => _salePrice = value;
        }

        public decimal Discount { get; set; }
        public decimal Total => _salePrice * Quantity; // Endirimsiz brutto cəm
        public decimal Sum => Total - Discount; // Endirim çıxılmış son məbləğ
    }
}
