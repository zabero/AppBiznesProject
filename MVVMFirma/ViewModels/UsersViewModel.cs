using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class UsersViewModel : GetDataFromTable<Users>
    {
        public UsersViewModel() : base("Użytkownicy") { } 

        public override void Load()
        {
            if (_voucherShopEntities.Customers.Any())
                List = new ObservableCollection<Users>(_voucherShopEntities.Users.ToList());
            else
                List = new ObservableCollection<Users>();
        }
    }
}