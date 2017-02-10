using ContractCalc.ViewModels;
using Windows.UI.Xaml.Controls;

namespace ContractCalc.Controls
{
    public sealed partial class SummaryControl : UserControl
    {
        SummaryViewModel model { get; set; } = new SummaryViewModel();

        #region Constructor

        public SummaryControl()
        {
            InitializeComponent();
            DataContext = model;
        }

        #endregion
    }
}
