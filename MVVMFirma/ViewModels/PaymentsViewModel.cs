using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class PaymentsViewModel : GetDataFromTable<Payments>
    {
        public PaymentsViewModel() : base("Płatności") { }
        

        public override void Load()
        {
            if (_voucherShopEntities.Customers.Any())
                List = new ObservableCollection<Payments>(_voucherShopEntities.Payments.ToList());
            else
                List = new ObservableCollection<Payments>();
        }
    }
}