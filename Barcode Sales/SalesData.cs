//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Barcode_Sales
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesData
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string ReceiptNo { get; set; }
        public string LongFiscalId { get; set; }
        public string ShortFiscalId { get; set; }
        public string Rrn { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public Nullable<System.DateTime> SaleDatetime { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<double> Cash { get; set; }
        public Nullable<double> Card { get; set; }
        public Nullable<double> IncomingSum { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string Note { get; set; }
    }
}
