using MVVMFirma.Helper;                  // BaseCommand czy RelayCommand
using MVVMFirma.Models.BussinesLogic;    // UserPurchaseLogic
using MVVMFirma.Models.Entities;         // VoucherShopEntities
using MVVMFirma.Models.EntitiesForView;  // UserPurchaseSummary
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class UserPurchaseViewModel : WorkspaceViewModel
    {
        // ====== Pola ======
        private VoucherShopEntities _context;

        // ====== Konstruktor ======
        public UserPurchaseViewModel()
        {
            base.DisplayName = "Zakupy użytkowników";

            // Inicjalizacja EF
            _context = new VoucherShopEntities();

            // Kolekcja do DataGrid
            UserPurchases = new ObservableCollection<UserPurchaseSummary>();

            // Ustaw domyślnie np. ostatni miesiąc
            DateFrom = DateTime.Now.AddMonths(-1);
            DateTo = DateTime.Now;
        }

        // ====== Właściwości ======
        private ObservableCollection<UserPurchaseSummary> _userPurchases;
        public ObservableCollection<UserPurchaseSummary> UserPurchases
        {
            get => _userPurchases;
            set
            {
                if (_userPurchases != value)
                {
                    _userPurchases = value;
                    OnPropertyChanged(() => UserPurchases);
                }
            }
        }

        private DateTime? _dateFrom;
        public DateTime? DateFrom
        {
            get => _dateFrom;
            set
            {
                if (_dateFrom != value)
                {
                    _dateFrom = value;
                    OnPropertyChanged(() => DateFrom);
                }
            }
        }

        private DateTime? _dateTo;
        public DateTime? DateTo
        {
            get => _dateTo;
            set
            {
                if (_dateTo != value)
                {
                    _dateTo = value;
                    OnPropertyChanged(() => DateTo);
                }
            }
        }

        // Suma wszystkich zamówień – łączna liczba (dla wszystkich klientów)
        private int _allPurchaseCount;
        public int AllPurchaseCount
        {
            get => _allPurchaseCount;
            set
            {
                if (_allPurchaseCount != value)
                {
                    _allPurchaseCount = value;
                    OnPropertyChanged(() => AllPurchaseCount);
                }
            }
        }

        // Suma wszystkich kwot (dla wszystkich klientów)
        private decimal _allTotalSpent;
        public decimal AllTotalSpent
        {
            get => _allTotalSpent;
            set
            {
                if (_allTotalSpent != value)
                {
                    _allTotalSpent = value;
                    OnPropertyChanged(() => AllTotalSpent);
                }
            }
        }

        // ====== Komendy ======
        private BaseCommand _loadPurchasesCommand;
        public ICommand LoadPurchasesCommand
        {
            get
            {
                if (_loadPurchasesCommand == null)
                {
                    _loadPurchasesCommand = new BaseCommand(() => LoadPurchases());
                }
                return _loadPurchasesCommand;
            }
        }

        // ====== Metody ======
        private void LoadPurchases()
        {
            // Wywołujemy logikę biznesową
            var logic = new UserPurchaseLogic(_context);
            var results = logic.GetUserPurchases(DateFrom, DateTo);

            // Czyścimy starą listę
            UserPurchases.Clear();

            // Wypełniamy nowymi rekordami (jeden rekord = jeden klient)
            foreach (var item in results)
            {
                UserPurchases.Add(item);
            }

            // Policz sumy globalne (łączną liczbę i łączną kwotę)
            AllPurchaseCount = results.Sum(x => x.PurchaseCount);
            AllTotalSpent = results.Sum(x => x.TotalSpent);
        }
    }
}
