using MVVMFirma.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class CustomersViewModel : WorkspaceViewModel
    {
        public CustomersViewModel()
        {
            base.DisplayName = "Zarzadzanie klientami";
        }
    }
}