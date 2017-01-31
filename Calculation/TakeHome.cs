namespace Calculation
{
    public class TakeHome
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
            }
        }
        #endregion

        #region Private properties
        private Taxes.Taxes Taxes { get; set; }
        private Expenses.Expenses Expenses { get; set; }
        private decimal GrossRevenue { get; set; }

        private decimal GrossDividends
        {
            get
            {
                return GrossRevenue - Expenses.Amount;
            }
        }
        #endregion

        #region Output properties
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
                    Expenses.Pension.Amount;
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
