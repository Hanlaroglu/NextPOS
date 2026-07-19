using System;

namespace Barcode_Sales.DTOs
{
    public class ProductInvoiceImportDto
    {
        public string Type { get; set; }
        public string WarehouseName { get; set; }
        public string SupplierName { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Barcode { get; set; }
        public decimal Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public string UnitName { get; set; }
        public string TaxName { get; set; }
    }
}