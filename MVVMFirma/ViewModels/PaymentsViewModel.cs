using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class PaymentsViewModel : GetDataFromTable<PaymentsForAllViews>
    {
        public PaymentsViewModel() : base("Płatności") { }
        

       public override void Load()
        {
            List = new ObservableCollection<PaymentsForAllViews>(
            _voucherShopEntities.Payments.Select(c => new PaymentsForAllViews
            {
                PaymentID = c.PaymentID,
                OrderID = c.OrderID,
                PaymentDate = c.PaymentDate,
                PaymentAmount = c.PaymentAmount,
                PaymentStatus = c.PaymentStatus,
                CustomerID = c.Orders.CustomerID,
                TotalPrice = c.Orders.TotalPrice,
                OrderDate = c.Orders.OrderDate,
                Status = c.Orders.Status,

            }));
        }
    }
}