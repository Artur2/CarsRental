using System;
using System.Linq;
using System.Threading.Tasks;
using CarsRental.Domain.Cars.Entities;
using CarsRental.Domain.Seedwork.Query;
using CarsRental.Infrastructure.Storage.Ef;
using CarsRental.Infrastructure.Tests.Internal;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CarsRental.Infrastructure.Tests.Storage.Ef
{
    public class RepositoryTests : IClassFixture<ServiceCollectionFixture>
    {
        private readonly ServiceCollectionFixture _serviceCollectionFixture;

        public RepositoryTests(ServiceCollectionFixture serviceCollectionFixture) => _serviceCollectionFixture = serviceCollectionFixture;

        [Fact]
        public async Task InsertWithKeyAsync_With_Wrong_Expression_Should_Throw_Exception()
        {
            var repository = new Repository<Car>(null) as IKeyedRepository<Car>;

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await repository.InsertWithKeyAsync(x => x.Id != null, null, default));
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await repository.InsertWithKeyAsync(x => !string.IsNullOrWhiteSpace(x.Title), null, default));
        }

        [Fact]
        public async Task InsertWithKeyAsync_Should_Query_For_Existing_Item_And_Not_Insert_Doublings()
        {
            using var scope = _serviceCollectionFixture.CreateDefaultScopedProvider();

            var keyedRepository = scope.ServiceProvider.GetService<IKeyedRepository<Car>>();
            var repository = scope.ServiceProvider.GetService<IQueryableRepository<Car>>();

            var car = await repository.AddAsync(new Car { Id = 99, Title = "Test 222" }, default);

            await repository.UnitOfWork.CommitAsync();

            var result = await keyedRepository.InsertWithKeyAsync(x => x.Id, car, default);

            var cars = await repository.QueryAsync(x => x.Title == car.Title, default);

            var count = cars.Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task InsertWithKeyAsync_Should_Query_For_Existing_Item_And_Insert_By_Different_Key()
        {
            using var scope = _serviceCollectionFixture.CreateDefaultScopedProvider();

            var keyedRepository = scope.ServiceProvider.GetService<IKeyedRepository<Car>>();
            var repository = scope.ServiceProvider.GetService<IQueryableRepository<Car>>();

            var car = await repository.AddAsync(new Car { Id = 100, Title = "Test" }, default);

            await repository.UnitOfWork.CommitAsync();

            var result = await keyedRepository.InsertWithKeyAsync(x => x.Id, new Car { Id = 98, Title = "Test" });

            await keyedRepository.UnitOfWork.CommitAsync();

            var cars = await repository.QueryAsync(x => x.Title == car.Title, default);

            var count = cars.Count();

            Assert.Equal(2, count);
        }
    }
}
