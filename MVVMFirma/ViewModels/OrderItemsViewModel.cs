﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class OrderItemsViewModel : WorkspaceViewModel
    {
        public OrderItemsViewModel()
        {
            base.DisplayName = "Pozycje w zamówieniach";
        }
    }
}