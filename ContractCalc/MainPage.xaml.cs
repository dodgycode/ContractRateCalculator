using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;

namespace ContractCalc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            //ApplicationView.PreferredLaunchViewSize = new Size { Height = 620, Width = 360 };
            //ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            //ApplicationView.GetForCurrentView().SetPreferredMinSize(ApplicationView.PreferredLaunchViewSize);

            ApplicationView appView = ApplicationView.GetForCurrentView();
            appView.Title = "Contractor Take Home Calculator";
        }

     
    }
}
