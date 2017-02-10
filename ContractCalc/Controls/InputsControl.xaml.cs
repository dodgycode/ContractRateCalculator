using ContractCalc.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace ContractCalc.Controls
{
    public sealed partial class InputsControl : UserControl
    {
        InputsViewModel model { get; set; } = new InputsViewModel();

        #region Constructor

        public InputsControl()
        {
            InitializeComponent();
            DataContext = model;
        }

        #endregion

        #region Control event handlers

        private void sldSalary_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            model.MaxSalary = model.GrossRevenue - model.AccountingFees - model.MileageExpense;
            model.Pension = model.Salary + model.Pension > model.MaxSalary ?
                model.MaxSalary - model.Salary : model.Pension;
        }

        private void sldPension_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            model.MaxSalary = model.GrossRevenue - model.AccountingFees - model.MileageExpense;
            model.Salary = model.Salary + model.Pension > model.MaxSalary ?
                model.MaxSalary - model.Pension : model.Salary;
        }

        #endregion
    }
}
