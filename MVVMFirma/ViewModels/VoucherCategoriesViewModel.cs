using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class VoucherCategoriesViewModel : GetDataFromTable<VoucherCategories>
    {
        public VoucherCategoriesViewModel() : base("Kategorie Voucherów") { }

        public override void Load()
        {
            if (_voucherShopEntities.Customers.Any())
                List = new ObservableCollection<VoucherCategories>(_voucherShopEntities.VoucherCategories.ToList());
            else
                List = new ObservableCollection<VoucherCategories>();
        }
    }
}