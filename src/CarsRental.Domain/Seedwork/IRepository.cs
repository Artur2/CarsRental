using System.Threading;
using System.Threading.Tasks;

namespace CarsRental.Domain.Seedwork
{
    /// <summary>
    /// Contract related to execute operations against storage.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Instance of <see cref="IUnitOfWork"/> for modify state of requested objects 
        /// from underlying storage.
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Getting entity by id.
        /// </summary>
        Task<T> GetByAsync(int id);

        /// <summary>
        /// Retrieve all data from underlying storage.
        /// </summary>
        Task<T[]> GetAllAsync(CancellationToken cancellationToken);


        /// <summary>
        /// Adding instance to underlying storage.
        /// </summary>
        /// <param name="entity">Persisting instance.</param>
        /// <param name="cancellationToken">Used to stop all underlying pending operations.</param>
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        /// Deleting provided entity from underlying storage.
        /// </summary>
        /// <param name="entity">Persisted instance which will be deleted..</param>
        /// <param name="cancellationToken">Used to stop all underlying pending operations.</param>
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}
