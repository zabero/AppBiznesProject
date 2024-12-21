using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class NotificationsForAllViws
    {
        public int NotificationID { get; set; }
        public string Message { get; set; }
        public Nullable<bool> IsRead { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }


        public string Username { get; set; }
        public string Role { get; set; }
        public Nullable<DateTime> UserCreatedAt { get; set; }
       
    }
}
