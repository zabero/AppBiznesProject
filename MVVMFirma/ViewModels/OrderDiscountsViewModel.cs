using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
public class OrderDiscountsViewModel : GetDataFromTable<OrderDiscountsForAllViews>
{
    public OrderDiscountsViewModel() : base("Rabaty") { }

    public override void Load()
    {
        List = new ObservableCollection<OrderDiscountsForAllViews>(
        _voucherShopEntities.OrderDiscounts.Select(c => new OrderDiscountsForAllViews
        {
            OrderDiscountID = c.OrderDiscountID,
            OrderID = c.OrderID,
            DiscountAmount = c.DiscountAmount,
            CodeID = c.DiscountCodes.CodeID,
            Code = c.DiscountCodes.Code,
            DiscountPercentage =c.DiscountCodes.DiscountPercentage,
            ExpiryDate = c.DiscountCodes.ExpiryDate,
            IsActive = c.DiscountCodes.IsActive,
        }));
    }
}
}