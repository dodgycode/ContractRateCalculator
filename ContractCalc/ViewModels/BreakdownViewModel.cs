namespace ContractCalc.ViewModels
{
   public class BreakdownViewModel : ViewModelBase
    {
        #region Properties

        public double MileageExpense { get { return (double)SharedModel.MileageExpense; } }
        public double TotalExpenses  {get { return (double)SharedModel.Expenses.Amount; }  }
        public decimal GrossDividends { get { return SharedModel.GrossDividends; } }
        public double GrossRevenue { get { return (double)SharedModel.GrossRevenue; } }

        #endregion
    }
}
