using Calculation;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContractCalc.ViewModels
{
    public  class ViewModelBase : INotifyPropertyChanged
    {
        private static TakeHome model;

        #region Constructor

        static ViewModelBase()
        {
            model = model ?? new TakeHome();
        }

        #endregion

        #region Properties

        protected TakeHome SharedModel
        {
            get { return model; }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
