namespace ContractCalc.ViewModels
{
    public class SummaryViewModel : ViewModelBase
    {
        #region Properties

        private decimal _totalIncludingPension;
        public decimal TotalIncludingPension
        {
            get
            {
                return _totalIncludingPension;
            }
            set
            {
                _totalIncludingPension = value;
                TotalExcludingPension = _totalIncludingPension - SharedModel.Expenses.GetPensionAmount();
                RaisePropertyChanged();
            }
        }

        private decimal _totalExcludingPension;
        public decimal TotalExcludingPension
        {
            get
            {
                return _totalExcludingPension;
            }
            set
            {
                _totalExcludingPension = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public SummaryViewModel()
        {
            SharedModel.PropertyChanged += SharedModel_PropertyChanged;
        }

        #endregion

        #region Private methods

        private void CalculateTotalIncludingPension()
        {
            TotalIncludingPension = SharedModel.GrossRevenue - SharedModel.Taxes.Amount;
        }

        #endregion

        #region Event handlers

        private void SharedModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "GrossRevenue":
                case "Pension":
                case "Taxes":
                case "Expenses":
                    CalculateTotalIncludingPension();
                    break;
            }
        }

        #endregion
    }
}
