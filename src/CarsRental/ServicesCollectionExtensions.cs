using CarsRental.Domain.Cars.Entities;
using CarsRental.Domain.Cars.Seeds;
using CarsRental.Domain.Seedwork.Data;
using CarsRental.Domain.Seedwork.Query;
using CarsRental.Infrastructure.Storage.Ef;
using CarsRental.Infrastructure.Storage.Ef.Configuration;
using CarsRental.Infrastructure.Storage.Seed;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace CarsRental
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddEntityFrameworkSqlite();
            serviceCollection.AddDbContext<CarsRentalDbContext>();
            serviceCollection.AddLogging(logger =>
            {
                var serilogLogger = new LoggerConfiguration()
                    .WriteTo.Console(LogEventLevel.Debug)
                    .WriteTo.Debug(LogEventLevel.Debug)
                    .CreateLogger();
                logger.AddSerilog(serilogLogger);
            });
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<IUnitOfWork, CarsRentalDbContext>();
            serviceCollection.AddScoped<ISeedDataService, SeedDataService>();
            serviceCollection.AddScoped<ISeedData<Car>, CarSeedData>();
            serviceCollection.AddScoped<IDataBootstrapper, DataBootstrapper>();
            serviceCollection.AddScoped<IDbContextConfiguration, DbContextConfiguration>();

            return serviceCollection;
        }
    }
}
