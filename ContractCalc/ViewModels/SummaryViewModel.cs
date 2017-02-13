namespace ContractCalc.ViewModels
{
    public class SummaryViewModel : ViewModelBase
    {
        #region Properties

        public decimal TotalIncludingPension
        {
            get { return SharedModel.TotalIncludingPension; }
            set { RaisePropertyChanged(); }
        }
        public decimal TotalExcludingPension
        {
            get { return SharedModel.TotalExcludingPension; }
            set { RaisePropertyChanged(); }
        }

        #endregion

        #region Constructor

        public SummaryViewModel()
        {
            SharedModel.PropertyChanged += SharedModel_PropertyChanged;
        }

        #endregion

        #region Event handlers

        private void SharedModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "TotalIncludingPension":
                    TotalIncludingPension = SharedModel.TotalIncludingPension;
                    break;
                case "TotalExcludingPension":
                    TotalExcludingPension = SharedModel.TotalExcludingPension;
                    break;
            }
        }

        #endregion
    }
}
