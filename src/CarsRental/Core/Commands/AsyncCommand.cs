using CarsRental.Crosscutting.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarsRental.Core.Commands
{
    public class AsyncCommand : IAsyncCommand
    {
        public event EventHandler CanExecuteChanged;

        private bool _isExecuting;
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;

        public AsyncCommand(Func<Task> execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute() => !_isExecuting && (_canExecute?.Invoke() ?? true);

        public bool CanExecute(object parameter) => CanExecute();

        void ICommand.Execute(object parameter) => ExecuteAsync(default).FireAndForgetSafeAsync();

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            if (CanExecute())
            {
                try
                {
                    _isExecuting = true;
                    await _execute();
                }
                finally
                {
                    _isExecuting = false;
                }
            }

            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
