using System;
using System.Threading.Tasks;
using CarsRental.Domain.Cars.Entities;
using CarsRental.Domain.Seedwork.Data;
using CarsRental.Domain.Seedwork.Query;
using CarsRental.Infrastructure.Tests.Internal;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CarsRental.Infrastructure.Tests.Storage.Seed
{
    public class DataBootsrapperTests : IClassFixture<ServiceCollectionFixture>
    {
        private readonly ServiceCollectionFixture _serviceCollectionFixture;

        public DataBootsrapperTests(ServiceCollectionFixture serviceCollectionFixture) => _serviceCollectionFixture = serviceCollectionFixture;

        // For test infrastructure.
        [Fact(Skip = "Only for check")]
        public async Task DataBoostrapper_With_Specified_Ids_In_Entities_Should_Not_Have_Doublings()
        {
            using var serviceScope = _serviceCollectionFixture.CreateDefaultScopedProvider();
            var dataBootsrapper = serviceScope.ServiceProvider.GetService<IDataBootstrapper>();
            var repository = serviceScope.ServiceProvider.GetService<IRepository<Car>>();

            await dataBootsrapper.BootstrapAsync(default);
            var allCars = await repository.GetAllAsync(default);

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await dataBootsrapper.BootstrapAsync(default));
        }
    }
}
