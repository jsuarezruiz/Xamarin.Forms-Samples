using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TodoSqlite.ViewModels.Base
{
    /// <summary>
    ///     This class allows us to delegate command execution to viewmodels.
    ///     This version of the command allow to use async/await.
    /// </summary>
    public class DelegateCommandAsync : ICommand
    {
        private readonly Func<Task<bool>> _canExecute;
        private readonly Func<Task> _execute;

        /// <summary>
        ///     Constructor not using canExecute.
        /// </summary>
        /// <param name="execute"></param>
        public DelegateCommandAsync(Func<Task> execute) : this(execute, null)
        {
        }

        /// <summary>
        ///     Constructor using both execute and canExecute.
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public DelegateCommandAsync(Func<Task> execute, Func<Task<bool>> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        ///     This method is called from XAML to evaluate if the command can be executed.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute().Result;

            return true;
        }

        /// <summary>
        ///     This method is called from XAML to execute the command.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute();
        }

        /// <summary>
        ///     This event notify XAML controls using the command to reevaluate the CanExecute of it.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        ///     This method allow us to force the execution of CanExecute method to reevaluate execution.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            EventHandler tmpHandle = CanExecuteChanged;
            if (tmpHandle != null)
                tmpHandle(this, new EventArgs());
        }
    }

    /// <summary>
    ///     This class allows us to delegate command execution to viewmodels using a T type as parameter.
    /// </summary>
    public class DelegateCommandAsync<T> : ICommand
    {
        private readonly Func<T, Task<bool>> _canExecute;
        private readonly Func<T, Task> _execute;

        /// <summary>
        ///     Constructor not using canExecute.
        /// </summary>
        /// <param name="execute"></param>
        public DelegateCommandAsync(Func<T, Task> execute) : this(execute, null)
        {
        }

        /// <summary>
        ///     Constructor using both execute and canExecute.
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public DelegateCommandAsync(Func<T, Task> execute, Func<T, Task<bool>> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        ///     This method is called from XAML to evaluate if the command can be executed.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute((T) parameter).Result;

            return true;
        }

        /// <summary>
        ///     This method is called from XAML to execute the command.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute((T) parameter);
        }

        /// <summary>
        ///     This event notify XAML controls using the command to reevaluate the CanExecute of it.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        ///     This method allow us to force the execution of CanExecute method to reevaluate execution.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            EventHandler tmpHandle = CanExecuteChanged;
            if (tmpHandle != null)
                tmpHandle(this, new EventArgs());
        }
    }
}