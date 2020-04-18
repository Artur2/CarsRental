using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarsRental.Core.Commands
{
    /// <summary>
    /// Async supported command for interact with UI.
    /// </summary>
    public interface IAsyncCommand : ICommand
    {
        /// <summary>
        /// Executing command in async manner.
        /// </summary>
        Task ExecuteAsync(CancellationToken cancellationToken);

        bool CanExecute();
    }
}
