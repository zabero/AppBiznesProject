//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVVMFirma.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class VoucherReviews
    {
        public int ReviewID { get; set; }
        public int VoucherID { get; set; }
        public int CustomerID { get; set; }
        public Nullable<int> Rating { get; set; }
        public string ReviewText { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual Vouchers Vouchers { get; set; }
    }
}
