using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NotificationsAddViewModel : AddDataToTable<Notifications>
    {

        #region Properties
        public int NotificationID
        {
            get
            {
                return item.NotificationID;
            }
            set
            {
                item.NotificationID = value;
                OnPropertyChanged(() => NotificationID);
            }
        }
        public int UserID
        {
            get
            {
                return item.UserID;
            }
            set
            {
                item.UserID = value;
                OnPropertyChanged(() => UserID);
            }
        }


        public string Message
        {
            get
            {
                return item.Message;
            }
            set
            {
                item.Message = value;
                OnPropertyChanged(() => Message);
            }
        }

        public Nullable<bool> IsRead
        {
            get
            {
                return item.IsRead;
            }
            set
            {
                item.IsRead = value;
                OnPropertyChanged(() => IsRead);
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


        #endregion

        #region Constructor
        public NotificationsAddViewModel()
            : base("Dodaj Powiadomienie")
        {
            item = new Notifications();
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            _voucherShopEntities.Notifications.Add(item);
            _voucherShopEntities.SaveChanges();
        }

        #endregion
    }
}

    

