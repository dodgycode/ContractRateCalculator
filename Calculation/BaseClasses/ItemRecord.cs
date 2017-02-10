using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Calculation.BaseClasses
{
    public  class ItemRecord : INotifyPropertyChanged
    {
        #region     Properties

        private decimal _amount;
        public virtual decimal Amount
        {
            get { return _amount; }
            set { _amount = value; RaisePropertyChanged(); }
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
