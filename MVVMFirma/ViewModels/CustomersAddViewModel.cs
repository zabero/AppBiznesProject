using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class CustomersAddViewModel :AddDataToTable<Customers>
    {
        #region Properties
        public int CustomerID
        {
            get
            {
                return item.CustomerID;
            }
            set
            {
                item.CustomerID = value;
                OnPropertyChanged(() => CustomerID);
            }
        }

        public string FirstName
        {
            get
            {
                return item.FirstName;
            }
            set
            {
                item.FirstName = value;
                OnPropertyChanged(() => FirstName);
            }
        }

        public string LastName
        {
            get
            {
                return item.LastName;
            }
            set
            {
                item.LastName = value;
                OnPropertyChanged(() => LastName);
            }
        }

        public string Email
        {
            get
            {
                return item.Email;
            }
            set
            {
                item.Email = value;
                OnPropertyChanged(() => Email);
            }
        }

        public string PhoneNumber
        {
            get
            {
                return item.PhoneNumber;
            }
            set
            {
                item.PhoneNumber = value;
                OnPropertyChanged(() => Address);
            }
        }

        public DateTime? CreatedAt
        {
            get
            {
                return item.CreatedAt;
            }
            set
            {
                item.CreatedAt = value;
                OnPropertyChanged(() => CreatedAt);
            }
        }

        public string Address
        {
            get
            {
                return item.Address;
            }
            set
            {
                item.Address = value;
                OnPropertyChanged(() => PhoneNumber);
            }
        }
        #endregion

        #region Constructor
        public CustomersAddViewModel()
            : base("Dodaj Klienta")
        {
            item = new Customers();
            CreatedAt = DateTime.Now;
        }
        #endregion
       
        #region Helpers
        public override void Save()
        {
            _voucherShopEntities.Customers.Add(item);
            _voucherShopEntities.SaveChanges();
        }

        #endregion
    }
}
