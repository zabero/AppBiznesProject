using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class AppSettingsViewModel : GetDataFromTable<AppSettings>
    {
        public AppSettingsViewModel() : base("Ustawienia") { }

        public override void Load()
        {
            if (_voucherShopEntities.Customers.Any())
                List = new ObservableCollection<AppSettings>(_voucherShopEntities.AppSettings.ToList());
            else
                List = new ObservableCollection<AppSettings>();
        }
    }
}
