//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobilePro
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesBill
    {
        public string ReceiptNo { get; set; }
        public string CustomerName { get; set; }
        public string PaymentType { get; set; }
        public Nullable<System.DateTime> ServiceDate { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<decimal> NetAmount { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
