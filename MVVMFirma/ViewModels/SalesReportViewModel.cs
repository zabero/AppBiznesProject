using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMFirma.Models.BussinesLogic;


namespace MVVMFirma.ViewModels
{
    public class SalesReportViewModel:WorkspaceViewModel
    {

        #region Context
        VoucherShopEntities context;
        #endregion

        #region Constructor
        public SalesReportViewModel()
        {
            base.DisplayName = "Raport sprzedaży Voucherów";
            DateFrom = DateTime.Now;
            DateTo = DateTime.Now;
            Profit = 0;
            context = new VoucherShopEntities();
        }
        #endregion

        #region Properties
        private DateTime _dateFrom;
        public DateTime DateFrom
        {
            get
            {
                return _dateFrom;
            }
            set
            {
                if (_dateFrom != value)
                {
                    _dateFrom = value;
                    OnPropertyChanged(() => DateFrom);
                }
            }
        }

        private DateTime _dateTo;
        public DateTime DateTo
        {
            get
            {
                return _dateTo;
            }
            set
            {
                if (_dateTo != value)
                {
                    _dateTo = value;
                    OnPropertyChanged(() => DateTo);
                }
            }
        }

        private int _voucherId;
        public int VoucherId
        {
            get
            {
                return _voucherId;
            }
            set
            {
                if (_voucherId != value)
                {
                    _voucherId = value;
                    OnPropertyChanged(() => VoucherId);
                }
            }
        }

        private decimal? _profit;
        public decimal? Profit
        {
            get
            {
                return _profit;
            }
            set
            {
                if (_profit != value)
                {
                    _profit = value;
                    OnPropertyChanged(() => Profit);
                }
            }
        }

        public List<KeyAndValue> VoucherComboBox
        {
            get
            {
                return new Voucher(context).GetVoucherKeyAndValueItems().ToList();
            }
        }
        #endregion

        #region Commands
        private BaseCommand _sumCommand;
        public ICommand SumCommand
        {
            get
            {
                if (_sumCommand == null)
                {
                    _sumCommand = new BaseCommand(() => SumButtonHandler());
                }
                return _sumCommand;
            }
        }

        private void SumButtonHandler()
        {
            Profit = new VoucherProfit(context).ProfitByDate(VoucherId, DateFrom, DateTo);
        }

        #endregion
    }
}
