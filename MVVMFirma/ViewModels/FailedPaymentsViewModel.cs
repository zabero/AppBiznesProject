using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.BussinesLogic;
using MVVMFirma.Helper;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class FailedPaymentsViewModel : WorkspaceViewModel
    {
        #region Properties
        private ObservableCollection<FailedPayment> _failedPayments;
        public ObservableCollection<FailedPayment> FailedPayments
        {
            get { return _failedPayments; }
            set
            {
                if (_failedPayments != value)
                {
                    _failedPayments = value;
                    OnPropertyChanged(() => FailedPayments);
                }
            }
        }
        #endregion

        #region Commands
        private BaseCommand _loadFailedPaymentsCommand;
        public ICommand LoadFailedPaymentsCommand
        {
            get
            {
                if (_loadFailedPaymentsCommand == null)
                {
                    _loadFailedPaymentsCommand = new BaseCommand(() => LoadFailedPayments());
                }
                return _loadFailedPaymentsCommand;
            }
        }
        #endregion

        #region Constructor
        public FailedPaymentsViewModel()
        {
            base.DisplayName = "Nieudane Płatności";
            FailedPayments = new ObservableCollection<FailedPayment>();
        }
        #endregion

        #region Methods
        private void LoadFailedPayments()
        {
            var paymentLogic = new PaymentLogic(new VoucherShopEntities());
            var failedPaymentsList = paymentLogic.GetFailedPayments();
            FailedPayments.Clear();

            foreach (var payment in failedPaymentsList)
            {
                FailedPayments.Add(payment);
            }
        }
        #endregion
    }
}
