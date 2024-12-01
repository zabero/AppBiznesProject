using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class UserAddViewModel : AddDataToTable<Users>

    {
        #region Properties
        public int UserID
        {
            get
            {
                return item.UserID;
            }
            set
            {
                item.UserID = value;
                OnPropertyChanged(() => Username);
            }
        }

        public string Username
        {
            get
            {
                return item.Username;
            }
            set
            {
                item.Username = value;
                OnPropertyChanged(() => UserID);
            }
        }
        public string PasswordHash
        {
            get
            {
                return item.PasswordHash;
            }
            set
            {
                item.PasswordHash = value;
                OnPropertyChanged(() => PasswordHash);
            }
        }
        public string Role
        {
            get
            {
                return item.Role;
            }
            set
            {
                item.Role = value;
                OnPropertyChanged(() => Role);
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
        public UserAddViewModel()
            : base("Dodaj użytkownika")
        {
            item = new Users();
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            _voucherShopEntities.Users.Add(item);
            _voucherShopEntities.SaveChanges();
        }

        #endregion
    }
}
