using System;
using CarsRental.Domain.Cars.Entities;
using CarsRental.Domain.Cars.Seeds;
using CarsRental.Domain.Seedwork.Data;
using CarsRental.Domain.Seedwork.Query;
using CarsRental.Infrastructure.Storage.Ef;
using CarsRental.Infrastructure.Storage.Ef.Configuration;
using CarsRental.Infrastructure.Storage.Seed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CarsRental.Infrastructure.Tests.Internal
{
    public class ServiceCollectionFixture
    {
        public IServiceProvider BuildServiceProvider(IServiceCollection customServiceCollection = null)
        {
            var services = new ServiceCollection();

            if (customServiceCollection != null)
            {
                foreach (var service in customServiceCollection)
                {
                    services.Add(service);
                }
            }

            return services.BuildServiceProvider();
        }

        public virtual IServiceProvider BuildWithDefaultServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddEntityFrameworkInMemoryDatabase();
            serviceCollection.AddDbContext<CarsRentalDbContext>();
            serviceCollection.AddLogging();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<IUnitOfWork, CarsRentalDbContext>();
            serviceCollection.AddScoped<ISeedDataService, SeedDataService>();
            serviceCollection.AddScoped<ISeedData<Car>, CarSeedData>();
            serviceCollection.AddScoped<IDataBootstrapper, DataBootstrapper>();
            serviceCollection.AddScoped<IDbContextConfiguration, TestDatabaseConfiguration>();

            return BuildServiceProvider(serviceCollection);
        }

        public virtual IServiceScope CreateDefaultScopedProvider() => BuildWithDefaultServices().CreateScope();
    }
}
