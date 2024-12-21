﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class UserPurchaseSummary
    {
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public int PurchaseCount { get; set; }
        public decimal TotalSpent { get; set; }
    }

}

