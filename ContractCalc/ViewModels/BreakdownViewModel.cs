namespace ContractCalc.ViewModels
{
    public class BreakdownViewModel : ViewModelBase
    {
        #region Properties

        public double MileageExpense
        {
            get { return (double)SharedModel.MileageExpense; }
            set { RaisePropertyChanged(); }
        }
        public double TotalExpenses
        {
            get { return (double)SharedModel.Expenses.Amount; }
            set { RaisePropertyChanged(); }
        }
        public decimal GrossDividends
        {
            get { return SharedModel.GrossDividends; }
            set { RaisePropertyChanged(); }
        }
        public double GrossRevenue
        {
            get { return (double)SharedModel.GrossRevenue; }
            set { RaisePropertyChanged(); }
        }

        #endregion

        #region Constructor

        public BreakdownViewModel()
        {
            SharedModel.PropertyChanged += SharedModel_PropertyChanged;
        }

        #endregion

        #region Event handlers

        private void SharedModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "MileageExpense":
                    MileageExpense = (double)SharedModel.MileageExpense;
                    break;
                case "Expenses":
                    TotalExpenses = (double)SharedModel.Expenses.Amount;
                    break;
                case "GrossRevenue":
                    GrossRevenue = (double)SharedModel.GrossRevenue;
                    break;
                case "GrossDividends":
                    GrossDividends = SharedModel.GrossDividends;
                    break;
            }
        }

        #endregion
    }
}
