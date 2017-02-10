namespace ContractCalc.ViewModels
{
    public class SummaryViewModel : ViewModelBase
    {
        #region Properties

        public decimal TotalIncludingPension { get { return SharedModel.TotalIncludingPension; } }
        public decimal TotalExcludingPension { get { return SharedModel.TotalExcludingPension; } }

        #endregion
    }
}
