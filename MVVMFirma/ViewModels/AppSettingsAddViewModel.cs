using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class AppSettingsAddViewModel : AddDataToTable <AppSettings>
    {

        #region Properties
        public string SettingKey
        {
            get
            {
                return item.SettingKey;
            }
            set
            {
                item.SettingKey = value;
                OnPropertyChanged(() => SettingKey);
            }
        }


        public string SettingValue
        {
            get
            {
                return item.SettingValue;
            }
            set
            {
                item.SettingValue = value;
                OnPropertyChanged(() => SettingValue);
            }
        }
        #endregion

        #region Constructor
        public AppSettingsAddViewModel()
            : base("Dodaj Ustawienie")
        {
            item = new AppSettings();
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            _voucherShopEntities.AppSettings.Add(item);
            _voucherShopEntities.SaveChanges();
        }

        #endregion
    }
}
