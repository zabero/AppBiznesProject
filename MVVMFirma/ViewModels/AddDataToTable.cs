using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class AddDataToTable<T> : WorkspaceViewModel
    {
        #region DB
        protected readonly VoucherShopEntities _voucherShopEntities;
        #endregion

        #region Item
        protected T item;
        #endregion

        #region Command
        private BaseCommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new BaseCommand(() => SaveAndClose());
                return _saveCommand;
            }
        }
        #endregion

        #region Constructor
        public AddDataToTable(string displayName)
        {
            base.DisplayName = displayName;
            _voucherShopEntities = new VoucherShopEntities();
        }
        #endregion

        #region Helpers
        public abstract void Save();
        public void SaveAndClose()
        {
            Save();
            OnRequestClose();
        }
        #endregion
    }
}