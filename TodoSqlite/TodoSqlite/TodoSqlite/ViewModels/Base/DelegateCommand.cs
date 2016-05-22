using System;
using System.Windows.Input;

namespace TodoSqlite.ViewModels.Base
{
    /// <summary>
    /// This class allows us to delegate command execution to viewmodels.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Constructor not using canExecute.
        /// </summary>
        /// <param name="execute"></param>
        public DelegateCommand(Action execute) : this(execute, null) { }

        /// <summary>
        /// Constructor using both execute and canExecute.
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// This method is called from XAML to evaluate if the command can be executed.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute();

            return true;
        }

        /// <summary>
        /// This method is called from XAML to execute the command.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute();
        }

        /// <summary>
        /// This method allow us to force the execution of CanExecute method to reevaluate execution.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var tmpHandle = CanExecuteChanged;
            if (tmpHandle != null)
                tmpHandle(this, new EventArgs());
        }

        /// <summary>
        /// This event notify XAML controls using the command to reevaluate the CanExecute of it.
        /// </summary>
        public event EventHandler CanExecuteChanged;
    }

    /// <summary>
    /// This class allows us to delegate command execution to viewmodels using a T type as parameter.
    /// </summary>
    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        /// <summary>
        /// Constructor not using canExecute.
        /// </summary>
        /// <param name="execute"></param>
        public DelegateCommand(Action<T> execute) : this(execute, null) { }

        /// <summary>
        /// Constructor using both execute and canExecute.
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// This method is called from XAML to evaluate if the command can be executed.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute((T)parameter);

            return true;
        }

        /// <summary>
        /// This method is called from XAML to execute the command.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        /// <summary>
        /// This method allow us to force the execution of CanExecute method to reevaluate execution.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var tmpHandle = CanExecuteChanged;
            if (tmpHandle != null)
                tmpHandle(this, new EventArgs());
        }

        /// <summary>
        /// This event notify XAML controls using the command to reevaluate the CanExecute of it.
        /// </summary>
        public event EventHandler CanExecuteChanged;
    }
}
