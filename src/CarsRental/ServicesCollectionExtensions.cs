using CarsRental.Crosscutting.Logging;
using CarsRental.Domain.Cars.Entities;
using CarsRental.Domain.Cars.Seeds;
using CarsRental.Domain.Seedwork.Data;
using CarsRental.Domain.Seedwork.Query;
using CarsRental.Infrastructure.Storage.Ef;
using CarsRental.Infrastructure.Storage.Ef.Configuration;
using CarsRental.Infrastructure.Storage.Seed;
using Microsoft.Extensions.DependencyInjection;

namespace CarsRental
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped(typeof(ILoggerWrapper<>), typeof(LoggerWrapper<>));
            serviceCollection.AddEntityFrameworkSqlite();
            serviceCollection.AddDbContext<CarsRentalDbContext>();

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped(typeof(IKeyedRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped(typeof(IQueryableRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<IUnitOfWork, CarsRentalDbContext>();
            serviceCollection.AddScoped<ISeedDataService, SeedDataService>();
            serviceCollection.AddScoped<ISeedData<Car>, CarSeedData>();
            serviceCollection.AddScoped<ISeedData<Vans>, VansSeedData>();
            serviceCollection.AddScoped<ISeedData<SportCar>, SportCarSeedData>();
            serviceCollection.AddScoped<ISeedData<Sedan>, SedanSeedData>();
            serviceCollection.AddScoped<IDataBootstrapper, DataBootstrapper>();
            serviceCollection.AddScoped<IDbContextConfiguration, DbContextConfiguration>();

            return serviceCollection;
        }
    }
}
