namespace ContractCalc.ViewModels
{
    public class InputsViewModel : ViewModelBase
    {
        #region Constructor

        public InputsViewModel()
        {
            SetStartingValues();
        }

        #endregion

        #region Input Properties

        public double DayRate
        {
            get { return SharedModel.DayRate; }
            set
            {
                SharedModel.DayRate = (int)value;
                RaisePropertyChanged();
                CalculateMaxSalary();
            }
        }

        private bool _extendMaxDayRate;
        public bool ExtendMaxDayRate
        {
            get
            {
                return _extendMaxDayRate;
            }
            set
            {
                _extendMaxDayRate = value;
                MaxDayRate = _extendMaxDayRate ? 1200 : 600;
                RaisePropertyChanged();
            }
        }

        public double WeeksWorked
        {
            get { return SharedModel.WeeksWorked; }
            set
            {
                SharedModel.WeeksWorked = (int)value;
                RaisePropertyChanged();
                CalculateMaxSalary();
            }
        }

        public double Salary
        {
            get { return (double)SharedModel.Salary; }
            set
            {
                SharedModel.Salary = (decimal)value;
                RaisePropertyChanged();
                CalculateMaxSalary();
            }
        }
        public double Pension
        {
            get { return (double)SharedModel.Pension; }
            set
            {
                SharedModel.Pension = (decimal)value;
                RaisePropertyChanged();
                CalculateMaxSalary();
            }
        }
        public double AccountingFees
        {
            get { return (double)SharedModel.AccountingFees; }
            set
            {
                SharedModel.AccountingFees = (decimal)value;
                RaisePropertyChanged();
                CalculateMaxSalary();
            }
        }

        public double MilesPerDay
        {
            get { return SharedModel.MilesPerDay; }
            set
            {
                SharedModel.MilesPerDay = (int)value;
                RaisePropertyChanged();
                CalculateMaxSalary();
            }
        }

        #endregion

        #region Control Properties

        private double _maxDayRate;
        public double MaxDayRate
        {
            get
            {
                return _maxDayRate;
            }
            set
            {
                _maxDayRate = value;
                RaisePropertyChanged();
            }
        }

        public double GrossRevenue
        {
            get { return (double)SharedModel.GrossRevenue; }
            set { CalculateMaxSalary(); }
        }

        private double _maxSalary;

        public double MaxSalary
        {
            get
            {
                return _maxSalary;
            }
            set
            {
                _maxSalary = value;
                RaisePropertyChanged();
            }
        }

        public double MileageExpense { get { return (double)SharedModel.MileageExpense; } }

        #endregion

        #region     Private methods

        private void CalculateMaxSalary()
        {
            MaxSalary = GrossRevenue - (double)SharedModel.AccountingFees - (double)SharedModel.MileageExpense;
        }

        private void SetStartingValues()
        {
            MaxDayRate = 600;
            DayRate = 310;
            WeeksWorked = 46;
            Salary = 10000;
            Pension = 5000;
            AccountingFees = 1200;
            MilesPerDay = 35;
        }

        #endregion


    }

}
