using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace mvvm_netstandard.ComponentModel
{
    public class NotifyPropertyChangedViewModel : INotifyPropertyChanged
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetValueWithNotify(ref isBusy, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Notify property change works only when valueToChange and value are different.
        /// </summary>
        protected bool SetValueWithNotify<T>(ref T valueToChange, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(valueToChange, value))
            {
                return false;
            }
            else
            {
                valueToChange = value;
                OnPropertyChanged(propertyName);
                return true;
            }
        }
    }
}
