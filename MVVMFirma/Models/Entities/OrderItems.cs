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
    
    public partial class OrderItems
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int VoucherID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Vouchers Vouchers { get; set; }
    }
}