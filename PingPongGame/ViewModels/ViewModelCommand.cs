using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PingPongGame.ViewModels
{
    public class ViewModelCommand : ICommand
    {
        private readonly Action<object> _excuteAction;
        private readonly Predicate<object> _canExecuteAction;
        public ViewModelCommand(Action<object> executeActionConstructor)
        {
            _excuteAction = executeActionConstructor;
            _canExecuteAction = null;
        }
        public ViewModelCommand(Action<object> executeActionConstructor, Predicate<object> canExecuteAction)
        {
            _excuteAction = executeActionConstructor;
            _canExecuteAction = canExecuteAction;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);
        }

        public void Execute(object parameter)
        {
            _excuteAction(parameter);
        }
    }


}
