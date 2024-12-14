using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class NotificationsViewModel : GetDataFromTable<NotificationsForAllViws>
    {

        public NotificationsViewModel() : base("Powiadomienia") { }

        public override void Load()
        {
            List = new ObservableCollection<NotificationsForAllViws>(
            _voucherShopEntities.Notifications.Select(c => new NotificationsForAllViws
            {
                NotificationID = c.NotificationID,
                Message = c.Message,
                IsRead = c.IsRead,
                CreatedAt= c.CreatedAt,
                Username = c.Users.Username,
                Role = c.Users.Role,
                UserCreatedAt = c.Users.CreatedAt,
            }));
        }
    }
}