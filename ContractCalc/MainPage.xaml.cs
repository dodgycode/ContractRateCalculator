using ContractCalc.ViewModels;
using Windows.Foundation;
using Windows.UI.ViewManagement;
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

            ApplicationView.PreferredLaunchViewSize = new Size { Height = 620, Width = 360 };
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(ApplicationView.PreferredLaunchViewSize);

            ApplicationView appView = ApplicationView.GetForCurrentView();
            appView.Title = "Contractor Take Home Calculator";

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

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            SetStartingValues();
        }

        private void SetStartingValues()
        {
            thModel.MaxDayRate = 600;
            thModel.DayRate = 310;
            thModel.WeeksWorked = 46;
            thModel.Salary = 10000;
            thModel.Pension = 5000;
            thModel.AccountingFees = 1200;
            thModel.MilesPerDay = 35;
        }
    }
}
