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
    
    public partial class CustomerPreferences
    {
        public int PreferenceID { get; set; }
        public int CustomerID { get; set; }
        public string PreferenceKey { get; set; }
        public string PreferenceValue { get; set; }
    
        public virtual Customers Customers { get; set; }
    }
}
