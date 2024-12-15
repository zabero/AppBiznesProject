using MVVMFirma.Models.Entities;
using MVVMFirma.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class DiscountCodesAddViewModel : AddDataToTable<DiscountCodes>
{

    #region Properties
    public string Code
        {
        get
        {
            return item.Code;
        }
        set
        {
            item.Code = value;
            OnPropertyChanged(() => Code);
        }
    }


    public Nullable<decimal> DiscountPercentage
        {
        get
        {
            return item.DiscountPercentage;
        }
        set
        {
            item.DiscountPercentage = value;
            OnPropertyChanged(() => DiscountPercentage);
        }
    }
        public Nullable<DateTime> ExpiryDate
        {
            get
            {
                return item.ExpiryDate;
            }
            set
            {
                item.ExpiryDate = value;
                OnPropertyChanged(() => ExpiryDate);
            }
        }

        public Nullable<bool> IsActive
        {
            get
            {
                return item.IsActive;
            }
            set
            {
                item.IsActive = value;
                OnPropertyChanged(() => IsActive);
            }
        }


        #endregion

        #region Constructor
        public DiscountCodesAddViewModel()
        : base("Dodaj Kod Rabatowy")
    {
        item = new DiscountCodes();
    }
    #endregion

    #region Helpers
    public override void Save()
    {
        _voucherShopEntities.DiscountCodes.Add(item);
        _voucherShopEntities.SaveChanges();
    }

    #endregion
}
}