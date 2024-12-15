using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PaymentsForAllViews


    {

        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public Nullable<DateTime> PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }

        public int CustomerID { get; set; }
        public decimal TotalPrice { get; set; }

        public Nullable<DateTime> OrderDate { get; set; }
        public string Status { get; set; }
    }
}
