using Calculation;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContractCalc.ViewModels
{
    public class TakeHomeViewModel : INotifyPropertyChanged
    {
        TakeHome takeHome;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Input Properties
        public double DayRate
        {
            get { return takeHome.DayRate; }
            set
            {
                takeHome.DayRate = (int)value;
                RaisePropertyChanged();
                UpdateResult();
            }
        }
        public double WeeksWorked
        {
            get { return takeHome.WeeksWorked; }
            set
            {
                takeHome.WeeksWorked = (int)value;
                RaisePropertyChanged();
                UpdateResult();
            }
        }

        public double Salary
        {
            get { return (double)takeHome.Salary; }
            set
            {
                takeHome.Salary = (decimal)value;
                RaisePropertyChanged();
                UpdateResult();
            }
        }
        public double Pension
        {
            get { return (double)takeHome.Pension; }
            set
            {
                takeHome.Pension = (decimal)value;
                RaisePropertyChanged();
                UpdateResult();
            }
        }
        public double AccountingFees
        {
            get { return (double)takeHome.AccountingFees; }
            set
            {
                takeHome.AccountingFees = (decimal)value;
                RaisePropertyChanged();
                UpdateResult();
            }
        }

        public double MilesPerDay
        {
            get { return takeHome.MilesPerDay; }
            set
            {
                takeHome.MilesPerDay = (int)value;
                RaisePropertyChanged();
                UpdateResult();
            }
        }
        #endregion

        #region Control Properties
        private double _grossRevenue;
        public double GrossRevenue
        {
            get
            {
                return _grossRevenue;
            }
            set
            {
                _grossRevenue = value;
                RaisePropertyChanged();
            }
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

        private double _maxPension;
        public double MaxPension
        {
            get
            {
                return _maxPension;
            }
            set
            {
                _maxPension = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Output properties
        private decimal _totalIncludingPension;
        public decimal TotalIncludingPension
        {
            get { return _totalIncludingPension; }
            set
            {
                _totalIncludingPension = takeHome.TotalIncludingPension;
                RaisePropertyChanged();
            }
        }

        private decimal _totalExcludingPension;
        public decimal TotalExcludingPension
        {
            get { return _totalExcludingPension; }
            set
            {
                _totalExcludingPension = takeHome.TotalExcludingPension;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public TakeHomeViewModel()
        {
            takeHome = takeHome == null ? new TakeHome() : takeHome;
        }
        #endregion

        #region     Private methods
        private void UpdateResult()
        {
            TotalIncludingPension = takeHome.TotalIncludingPension;
            TotalExcludingPension = takeHome.TotalIncludingPension;
            GrossRevenue = (double)takeHome.GrossRevenue;
            MaxPension = MaxPension == 0 ? GrossRevenue : MaxPension;
            MaxSalary = MaxSalary == 0 ? GrossRevenue : MaxSalary;
        }
        #endregion

    }
}
