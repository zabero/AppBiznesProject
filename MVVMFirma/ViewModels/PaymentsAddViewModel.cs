using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class PaymentsAddViewModel : AddDataToTable <Payments>
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


        public Nullable<DateTime> PaymentDate
        {
            get
            {
                return item.PaymentDate;
            }
            set
            {
                item.PaymentDate = value;
                OnPropertyChanged(() => PaymentDate);
            }
        }
        public decimal PaymentAmount
        {
            get
            {
                return item.PaymentAmount;
            }
            set
            {
                item.PaymentAmount = value;
                OnPropertyChanged(() => PaymentAmount);
            }
        } 
        
        public string PaymentMethod
        {
            get
            {
                return item.PaymentMethod;
            }
            set
            {
                item.PaymentMethod = value;
                OnPropertyChanged(() => PaymentMethod);
            }
        }
        public string PaymentStatus
        {
            get
            {
                return item.PaymentStatus;
            }
            set
            {
                item.PaymentStatus = value;
                OnPropertyChanged(() => PaymentStatus);
            }
        }
        #endregion

        #region Constructor
        public PaymentsAddViewModel()
            : base("Dodaj Płatności")
        {
            item = new Payments();
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            _voucherShopEntities.Payments.Add(item);
            _voucherShopEntities.SaveChanges();
        }

        #endregion
    }
}
