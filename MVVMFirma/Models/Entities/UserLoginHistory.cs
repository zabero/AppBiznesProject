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
    
    public partial class UserLoginHistory
    {
        public int LoginID { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> LoginTime { get; set; }
        public string IPAddress { get; set; }
    
        public virtual Users Users { get; set; }
    }
}