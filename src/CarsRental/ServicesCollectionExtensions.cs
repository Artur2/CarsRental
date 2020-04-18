using CarsRental.Domain.Seedwork;
using CarsRental.Infrastructure.Storage.Ef;
using CarsRental.Infrastructure.Storage.Seed;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

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
                var serilogLogger = new LoggerConfiguration().WriteTo.Console(Serilog.Events.LogEventLevel.Debug)
                    .CreateLogger();
                logger.AddSerilog(serilogLogger);
            });
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<IUnitOfWork, CarsRentalDbContext>();
            serviceCollection.AddScoped<ISeedDataService, SeedDataService>();

            return serviceCollection;
        }
    }
}
