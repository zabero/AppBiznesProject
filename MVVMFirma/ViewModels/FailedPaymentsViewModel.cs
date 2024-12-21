using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        private List<FailedPayment> _allFailedPayments;

        private decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged(() => Amount);
                }
            }
        }

        public ObservableCollection<FailedPayment> FailedPayments { get; set; }

        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        #endregion

        #region Commands

        public ICommand LoadFailedPaymentsCommand { get; set; }
        public ICommand FilterFailedPaymentsCommand { get; set; }
        public ICommand SumOfFailedPaymentsCommand { get; set; }

        #endregion

        #region Constructor

        public FailedPaymentsViewModel()
        {
            base.DisplayName = "Nieudane Płatności";

            FailedPayments = new ObservableCollection<FailedPayment>();

            // -- Komendy tworzone w konstruktorze (tak samo, jak w przykładzie) --
            LoadFailedPaymentsCommand = new BaseCommand(() => LoadFailedPayments());
            FilterFailedPaymentsCommand = new BaseCommand(() => FilterFailedPayments());
            SumOfFailedPaymentsCommand = new BaseCommand(() => SumOfFailedPayments());

            // Na starcie wczytujemy wszystkie nieudane płatności
            LoadFailedPayments();
        }

        #endregion

        #region Methods

        private void LoadFailedPayments()
        {
            var paymentLogic = new PaymentLogic(new VoucherShopEntities());
            _allFailedPayments = paymentLogic.GetFailedPayments();

            FailedPayments.Clear();

            // Suma wszystkich nieudanych płatności z bazy
            Amount = paymentLogic.GetFailedPaymentsAmmount();

            // Przepisujemy do obserwowalnej kolekcji
            foreach (var payment in _allFailedPayments)
            {
                FailedPayments.Add(payment);
            }
        }

        private void FilterFailedPayments()
        {
            if (_allFailedPayments == null)
                return;

            var filtered = _allFailedPayments.AsQueryable();

            if (DateFrom.HasValue)
            {
                filtered = filtered.Where(p => p.PaymentDate >= DateFrom.Value);
            }

            if (DateTo.HasValue)
            {
                filtered = filtered.Where(p => p.PaymentDate <= DateTo.Value);
            }

            // 1. Czyścimy starą zawartość
            FailedPayments.Clear();

            // 2. Dodajemy przefiltrowane rekordy
            foreach (var payment in filtered)
            {
                FailedPayments.Add(payment);
            }

            // 3. Teraz faktycznie kolekcja "FailedPayments" ma przefiltrowane dane
            //    i można je zsumować
            if (FailedPayments.Any())
                Amount = FailedPayments.Sum(x => x.PaymentAmount);
            else
                Amount = 0m;
        }


        private void SumOfFailedPayments()
        {
            // Jeśli chcemy zsumować TYLKO te płatności, które są aktualnie w kolekcji
            if (FailedPayments.Any())
                Amount = FailedPayments.Sum(x => x.PaymentAmount);
            else
                Amount = 0m;
        }

        #endregion
    }
}
