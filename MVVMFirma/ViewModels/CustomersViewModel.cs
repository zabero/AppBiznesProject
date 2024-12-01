using MVVMFirma.Models.Entities;
using MVVMFirma.ViewModels;
using MVVMFirma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class CustomersViewModel : GetDataFromTable<Customers>
    {
        public CustomersViewModel() : base("Klienci") { }

        public override void Load()
        {
            if (_voucherShopEntities.Customers.Any())
                List = new ObservableCollection<Customers>(_voucherShopEntities.Customers.ToList());
            else
                List = new ObservableCollection<Customers>();
        }
    }
}