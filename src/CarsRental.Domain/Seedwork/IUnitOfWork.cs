using System.Threading;
using System.Threading.Tasks;

namespace CarsRental.Domain.Seedwork
{
    /// <summary>
    /// Contract for Unit of work functionality.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Committing changes to underlying storage
        /// </summary>
        Task CommitAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Rollback changes to initali state of underlying storage
        /// </summary>
        Task RollbackAsync(CancellationToken cancellationToken);
    }
}
