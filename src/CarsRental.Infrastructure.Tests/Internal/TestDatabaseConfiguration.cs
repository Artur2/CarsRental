using CarsRental.Infrastructure.Storage.Ef;
using CarsRental.Infrastructure.Storage.Ef.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CarsRental.Infrastructure.Tests.Internal
{
    public class TestDatabaseConfiguration : IDbContextConfiguration
    {
        public void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseInMemoryDatabase(nameof(CarsRentalDbContext));
#if DEBUG
            dbContextOptionsBuilder.EnableDetailedErrors();
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
#endif
        }
    }
}
