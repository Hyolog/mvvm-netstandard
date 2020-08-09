using System;
using System.Windows.Input;

namespace mvvm_netstandard.Windows.Input
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        readonly Predicate<object> canExecute;
        readonly Action<object> execute;

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }

            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (execute == null || !canExecute(parameter))
            {
                return;
            }

            execute(parameter);
        }
    }
}
