using ContractCalc.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ContractCalc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public TakeHomeViewModel thModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
            thModel = new TakeHomeViewModel();
            DataContext = thModel;
        }

        private void sldSalary_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            thModel.MaxSalary = thModel.GrossRevenue - thModel.AccountingFees - thModel.MileageExpense;
            thModel.Pension = thModel.Salary + thModel.Pension > thModel.MaxSalary ?
                thModel.MaxSalary - thModel.Salary : thModel.Pension;
        }

        private void sldPension_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            thModel.MaxSalary = thModel.GrossRevenue - thModel.AccountingFees - thModel.MileageExpense;
            thModel.Salary = thModel.Salary + thModel.Pension > thModel.MaxSalary ?
                thModel.MaxSalary - thModel.Pension : thModel.Salary;
        }
    }
}
