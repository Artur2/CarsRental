using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CarsRental.Domain.Seedwork.Query
{
    /// <summary>
    /// Contract for operation with <see cref="IQueryable{T}"/>.
    /// </summary>
    public interface IQueryableRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Query async results by filtering provided expression.
        /// </summary>
        /// <param name="expression">Expression by provided.</param>
        /// <returns>Queryable request which holds reference on underlying expression executor.</returns>
        Task<IQueryable<T>> QueryAsync(Expression<Func<T, bool>> queryExpression, CancellationToken cancellationToken = default);
    }
}
