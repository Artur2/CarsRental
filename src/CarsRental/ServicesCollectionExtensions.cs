using System;
using CarsRental.Domain.Cars.Entities;
using CarsRental.Domain.Cars.Seeds;
using CarsRental.Domain.Seedwork.Data;
using CarsRental.Domain.Seedwork.Query;
using CarsRental.Infrastructure.Storage.Ef;
using CarsRental.Infrastructure.Storage.Ef.Configuration;
using CarsRental.Infrastructure.Storage.Seed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            serviceCollection.AddLogging(loggerBuilder =>
            {
#if DEBUG
                loggerBuilder.SetMinimumLevel(LogLevel.Debug);
#else
                logger.SetMinimumLevel(LogLevel.Information);
#endif
                var serilogLogger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Console(LogEventLevel.Debug)
                    .WriteTo.Debug(LogEventLevel.Debug)
                    .WriteTo.File("log.txt", restrictedToMinimumLevel: LogEventLevel.Debug, rollingInterval: RollingInterval.Day, flushToDiskInterval: TimeSpan.FromMilliseconds(100))
                    .CreateLogger();

                loggerBuilder.AddSerilog(serilogLogger, true);
            });

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
