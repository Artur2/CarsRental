using System.Threading;
using System.Threading.Tasks;

namespace CarsRental.Domain.Seedwork.Data
{
    /// <summary>
    /// Bootsrapping data on application startup.
    /// </summary>
    public interface IDataBootstrapper
    {
        Task BootstrapAsync(CancellationToken cancellationToken = default);
    }
}
