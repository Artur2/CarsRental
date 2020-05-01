using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using CarsRental.Crosscutting.Utilities;
using Microsoft.Extensions.Logging;

namespace CarsRental.Core.Commands
{
    public class AsyncCommand : IAsyncCommand
    {
        public event EventHandler CanExecuteChanged;

        private bool _isExecuting;
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        private readonly ILogger<AsyncCommand> _logger;

        public AsyncCommand(Func<Task> execute, Func<bool> canExecute = null, ILogger<AsyncCommand> logger = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _logger = logger;
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
                catch (Exception ex)
                {
                    _logger?.LogError(ex, "Cannot execute command");
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
