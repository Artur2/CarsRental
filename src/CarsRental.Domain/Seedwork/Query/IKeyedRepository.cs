using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CarsRental.Domain.Seedwork.Query
{
    /// <summary>
    /// For insert without doubling.
    /// </summary>
    /// <typeparam name="T">Entity instance.</typeparam>
    public interface IKeyedRepository<T> where T : class
    {
        /// <summary>
        /// Unit of work for commit or rollback changes.
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Insert into database instance by keyed expression.
        /// </summary>
        Task<T> InsertWithKeyAsync<K>(Expression<Func<T, K>> key, T instance, CancellationToken cancellationToken = default);
    }
}
