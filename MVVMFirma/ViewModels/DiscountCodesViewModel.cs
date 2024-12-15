using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;


namespace MVVMFirma.ViewModels
{
    public class DiscountCodesViewModel : GetDataFromTable<DiscountCodes>
    {
        public DiscountCodesViewModel() : base("Kody Rabatowe") { }

        public override void Load()
        {
            if (_voucherShopEntities.DiscountCodes.Any())
                List = new ObservableCollection<DiscountCodes>(_voucherShopEntities.DiscountCodes.ToList());
            else
                List = new ObservableCollection<DiscountCodes>();
        }
    }
}