using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class CustomerPreferencesViewModel : GetDataFromTable<CustomerPreferencesForAllView>
    {

        public CustomerPreferencesViewModel() : base("Preferencje kupujących") { }

        public override void Load()
        {
            List = new ObservableCollection<CustomerPreferencesForAllView>(
            _voucherShopEntities.CustomerPreferences.Select(c => new CustomerPreferencesForAllView
            {
                PreferenceID = c.PreferenceID,
                FirstName = c.Customers.FirstName,
                LastName = c.Customers.LastName,
                Email = c.Customers.Email,
                PhoneNumber = c.Customers.PhoneNumber,
                PreferenceKey = c.PreferenceKey,
                PreferenceValue = c.PreferenceValue
            }));
        }
    }
}
