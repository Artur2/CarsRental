using CarsRental.Domain.Seedwork;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CarsRental.Infrastructure.Storage.Ef
{
    /// <summary>
    /// Common repository implementation for EFCore.
    /// </summary>
    /// <typeparam name="T">Instance in database.</typeparam>
    public class Repository<T> : IRepository<T>, IQueryableRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IUnitOfWork UnitOfWork => _unitOfWork;

        private CarsRentalDbContext Context => _unitOfWork as CarsRentalDbContext;

        /// <inheritdoc cref="IRepository{T}.AddAsync(T, CancellationToken)"/>
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await Context.AddAsync(entity, cancellationToken);
            return entity;
        }

        /// <inheritdoc cref="IRepository{T}.DeleteAsync(T, CancellationToken)"/>
        public Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            Context.Remove(entity);

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="IRepository{T}.GetAllAsync(CancellationToken)"/>
        public Task<T[]> GetAllAsync(CancellationToken cancellationToken) => Task.FromResult(Context.Set<T>().ToArray());

        /// <inheritdoc cref="IRepository{T}.GetByAsync(int)">
        public async Task<T> GetByAsync(int id) => await Context.FindAsync<T>(id);

        /// <inheritdoc cref="IQueryableRepository{T}.QueryAsync(Expression{Func{T, bool}}, CancellationToken)"/>
        public Task<IQueryable<T>> QueryAsync(Expression<Func<T, bool>> queryExpression, CancellationToken cancellationToken)
        {
            var result = Context.Set<T>().AsQueryable().Where(queryExpression);
            return Task.FromResult(result);
        }
    }
}
