using Microsoft.EntityFrameworkCore;

namespace CarsRental.Infrastructure.Storage.Ef.Configuration
{
    public class DbContextConfiguration : IDbContextConfiguration
    {
        public virtual void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=CarsRental.db;Cache=Shared");
#if DEBUG
            dbContextOptionsBuilder.EnableDetailedErrors();
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
#endif
        }
    }
}
