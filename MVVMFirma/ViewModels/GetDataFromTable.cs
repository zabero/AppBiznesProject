using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class GetDataFromTable<T> : WorkspaceViewModel
    {
        #region DB
        protected readonly VoucherShopEntities _voucherShopEntities;
        #endregion

        #region Commands
        private BaseCommand _loadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_loadCommand == null)
                    _loadCommand = new BaseCommand(() => Load());
                return _loadCommand;
            }
        }

        private BaseCommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new BaseCommand(() => Add());
                return _addCommand;
            }
        }

        #endregion


        #region List
        private ObservableCollection<T> _list;
        public ObservableCollection<T> List
        {
            get
            {
                if (_list == null)
                    Load();
                return _list;
            }
            set
            {
                _list = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion

        #region Contructor
        public GetDataFromTable(string displayName)
        {
            _voucherShopEntities = new VoucherShopEntities();
            base.DisplayName = displayName;
        }
        #endregion

        #region Helpers
        public abstract void Load();

        public void Add()
        {
            Messenger.Default.Send(DisplayName + "Add");
        }
        #endregion




    }
}
