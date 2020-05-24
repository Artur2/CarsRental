using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using CarsRental.Domain.Seedwork.Query;

namespace CarsRental.Infrastructure.Storage.Ef
{
    /// <summary>
    /// Common repository implementation for EFCore.
    /// </summary>
    /// <typeparam name="T">Instance in database.</typeparam>
    public class Repository<T> : IRepository<T>, IQueryableRepository<T>, IKeyedRepository<T> where T : class
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

        /// <inheritdoc cref="IKeyedRepository{T}.InsertWithKeyAsync{K}(Expression{Func{T, K}}, T, CancellationToken)">
        async Task<T> IKeyedRepository<T>.InsertWithKeyAsync<K>(Expression<Func<T, K>> key, T instance, CancellationToken cancellationToken)
        {
            var memberAccess = key.Body as MemberExpression;
            if (memberAccess == null)
            {
                throw new InvalidOperationException("Body is not MemberAccess Expression");
            }


            var instanceParamenter = Expression.Constant(instance, typeof(T)); // value(instance)
            var instanceMemberAccess = Expression.MakeMemberAccess(instanceParamenter, memberAccess.Member); // value.Member
            var queryParameter = Expression.Parameter(typeof(T), "x"); // x
            var queryMemberAccess = Expression.MakeMemberAccess(queryParameter, memberAccess.Member); // x.Member

            var equalExpression = Expression.Equal(queryMemberAccess, instanceMemberAccess); // x.Member == value.Member

            var queryExpression = Expression.Lambda<Func<T, bool>>(equalExpression, queryParameter); // x => x.Member == value.Member

            var queryResult = await QueryAsync(queryExpression, cancellationToken);
            if (queryResult.Any())
            {
                return queryResult.FirstOrDefault();
            }

            var insertionResult = await AddAsync(instance, cancellationToken);

            return insertionResult;
        }

        /// <inheritdoc cref="IQueryableRepository{T}.QueryAsync(Expression{Func{T, bool}}, CancellationToken)"/>
        public Task<IQueryable<T>> QueryAsync(Expression<Func<T, bool>> queryExpression, CancellationToken cancellationToken)
        {
            var result = Context.Set<T>().AsQueryable().Where(queryExpression);
            return Task.FromResult(result);
        }
    }
}
