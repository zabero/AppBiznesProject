using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class VoucherCategoriesAddViewModel : AddDataToTable<VoucherCategories>
    {

        #region Properties
        public int CategoryID
        {
            get
            {
                return item.CategoryID;
            }
            set
            {
                item.CategoryID = value;
                OnPropertyChanged(() => CategoryID);
            }
        }

        public string Name
        {
            get
            {
                return item.Name;
            }
            set
            {
                item.Name = value;
                OnPropertyChanged(() => Name);
            }
        }

        public string Description
        {
            get
            {
                return item.Description;
            }
            set
            {
                item.Description = value;
                OnPropertyChanged(() => Description);
            }
        }
        #endregion

        #region Constructor
        public VoucherCategoriesAddViewModel()
            : base("Dodaj kategorie voucheru")
        {
            item = new VoucherCategories();
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            _voucherShopEntities.VoucherCategories.Add(item);
            _voucherShopEntities.SaveChanges();
        }

        #endregion
    }
}
