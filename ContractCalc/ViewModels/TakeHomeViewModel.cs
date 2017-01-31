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
        public int DayRate
        {
            get { return takeHome.DayRate; }
            set
            {
                takeHome.DayRate = value;
                RaisePropertyChanged();
            }
        }
        public int WeeksWorked
        {
            get { return takeHome.WeeksWorked; }
            set
            {
                takeHome.WeeksWorked = value;
                RaisePropertyChanged();
            }
        }

        public double Salary
        {
            get { return (double)takeHome.Salary; }
            set
            {
                takeHome.Salary = (decimal)value;
                RaisePropertyChanged();
            }
        }
        public double Pension
        {
            get { return (double)takeHome.Pension; }
            set
            {
                takeHome.Pension = (decimal)value;
                RaisePropertyChanged();
            }
        }
        public double AccountingFees
        {
            get { return (double)takeHome.AccountingFees; }
            set
            {
                takeHome.AccountingFees = (decimal)value;
                RaisePropertyChanged();
            }
        }

        public int MilesPerDay
        {
            get { return takeHome.MilesPerDay; }
            set
            {
                takeHome.MilesPerDay = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Output properties
        public decimal TotalIncludingPension
        {
            get { return takeHome.TotalIncludingPension; }
        }

        public decimal TotalExcludingPension
        {
            get { return takeHome.TotalExcludingPension; }
        }
        #endregion

        #region Constructor
        public TakeHomeViewModel() 
        {
            takeHome = takeHome == null ? new TakeHome() : takeHome;
        }
        #endregion

    }
}
