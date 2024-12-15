using MVVMFirma.Models.Entities;
using MVVMFirma.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{ 
public class OrderDiscountsAddViewModel : AddDataToTable<OrderDiscounts>
{
        #region Properties
 
        public int OrderID
        {
            get
            {
                return item.OrderID;
            }
            set
            {
                item.OrderID = value;
                OnPropertyChanged(() => OrderID);
            }
        }

        public int CodeID
        {
            get
            {
                return item.CodeID;
            }
            set
            {
                item.CodeID = value;
                OnPropertyChanged(() => CodeID);
            }
        }

        public decimal DiscountAmount
    {
        get
        {
            return item.DiscountAmount;
        }
        set
        {
            item.DiscountAmount = value;
            OnPropertyChanged(() => DiscountAmount);
        }
    }





    #endregion

    #region Constructor
    public OrderDiscountsAddViewModel()
        : base("Dodaj Rabat do zamówienia")
    {
        item = new OrderDiscounts();
    }
    #endregion

    #region Helpers
    public override void Save()
    {
        _voucherShopEntities.OrderDiscounts.Add(item);
        _voucherShopEntities.SaveChanges();
    }

    #endregion
} }