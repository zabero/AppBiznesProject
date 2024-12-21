using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class OrderDiscountsForAllViews
    {
        public int OrderDiscountID { get; set; }
        public int OrderID { get; set; }
        public int CodeID { get; set; }
        public decimal DiscountAmount { get; set; }

        public string Code { get; set; }
        public Nullable<decimal> DiscountPercentage { get; set; }
        public Nullable<DateTime> ExpiryDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
