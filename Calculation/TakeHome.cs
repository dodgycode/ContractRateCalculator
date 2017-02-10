using Calculation.BaseClasses;

namespace Calculation
{
    public class TakeHome : ItemRecord
    {
        #region Input Properties

        private int _dayRate;
        /// <summary>
        ///     Pre-VAT day rate.
        /// </summary>
        public int DayRate
        {
            get
            {
                return _dayRate;
            }
            set
            {
                _dayRate = value;
                GrossRevenue = _dayRate * WeeksWorked * 5;
                RaisePropertyChanged();
            }
        }

        private int _weeksWorked;
        /// <summary>
        ///     Number of weeks worked per year for this contract.
        /// </summary>
        public int WeeksWorked
        {
            get
            {
                return _weeksWorked;
            }
            set
            {
                _weeksWorked = value;
                GrossRevenue = DayRate * _weeksWorked * 5;
                Expenses.SetMileage(MilesPerDay, _weeksWorked);
                Expenses = Expenses;
                RaisePropertyChanged();
            }
        }

        private decimal _salary;
        /// <summary>
        ///     Annual salary taken as PAYE.
        /// </summary>
        public decimal Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
                Taxes.SetSalary(_salary);
                Expenses.SetSalary(_salary);
                Expenses = Expenses;
                RaisePropertyChanged();
            }
        }

        private decimal _pension;
        /// <summary>
        ///     Amount of pension taken pre-tax.
        /// </summary>
        public decimal Pension
        {
            get
            {
                return _pension;
            }
            set
            {
                _pension = value;
                Expenses.SetPension(_pension);
                Expenses = Expenses;
                RaisePropertyChanged();
            }
        }

        private decimal _accountingFees;
        /// <summary>
        ///     Amount of accounting fees paid pre-tax.
        /// </summary>
        public decimal AccountingFees
        {
            get
            {
                return _accountingFees;
            }
            set
            {
                _accountingFees = value;
                Expenses.SetAccountingFees(_accountingFees);
                Expenses = Expenses;
                RaisePropertyChanged();
            }
        }

        private int _milesPerDay;
        public int MilesPerDay
        {
            get
            {
                return _milesPerDay;
            }
            set
            {
                _milesPerDay = value;
                Expenses.SetMileage(_milesPerDay, WeeksWorked);
                Expenses = Expenses;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Private properties
        private Taxes.Taxes Taxes { get; set; }

        private Expenses.Expenses _expenses;
        public Expenses.Expenses Expenses
        {
            get
            {
                return _expenses;
            }
            set
            {
                _expenses = value;
                GrossDividends = GrossRevenue - _expenses.Amount;
                MileageExpense = _expenses.GetMileageExpenseAmount();
                RaisePropertyChanged();
            }
        }
       
        private decimal _grossDividends;
        public decimal GrossDividends
        {
            get
            {
                return _grossDividends;
            }
            set
            {
                _grossDividends = value;
                Taxes.SetGrossDividends(_grossDividends);
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Output properties
        public decimal MileageExpense { get; set; }

        private decimal _grossRevenue;
        public decimal GrossRevenue
        {
            get
            {
                return _grossRevenue;
            }
            set
            {
                _grossRevenue = value;
                Taxes.SetGrossRevenue(_grossRevenue);
                GrossDividends = _grossRevenue - Expenses.Amount;
                RaisePropertyChanged();
            }
        }

        public decimal TotalIncludingPension
        {
            get
            {
                return GrossRevenue -
                    Taxes.Amount;
            }
        }

        public decimal TotalExcludingPension
        {
            get
            {
                return TotalIncludingPension -
                    Expenses.GetPensionAmount() ;
            }
        }
        #endregion

        #region     Constructor
        public TakeHome()
        {
            Taxes = new Taxes.Taxes();
            Expenses = new Expenses.Expenses();
        }
        #endregion

      
    }
}
