using ContractCalc.ViewModels;
using Windows.UI.Xaml.Controls;

namespace ContractCalc.Controls
{
    public sealed partial class BreakdownControl : UserControl
    {
        BreakdownViewModel model { get; set; } = new BreakdownViewModel();

        #region Constructor

        public BreakdownControl()
        {
            InitializeComponent();
            DataContext = model;
        }

        #endregion
    }
}
