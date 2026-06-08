using System;

namespace Barcode_Sales.DTOs
{
    public class PosBasketDto
    {
        public int Id { get; set; }
        public string BasketName { get; set; }
        public string CustomerName { get; set; }
        public int? CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
