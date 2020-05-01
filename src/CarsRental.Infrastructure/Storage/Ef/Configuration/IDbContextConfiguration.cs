using Microsoft.EntityFrameworkCore;

namespace CarsRental.Infrastructure.Storage.Ef.Configuration
{
    public interface IDbContextConfiguration
    {
        void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder);
    }
}