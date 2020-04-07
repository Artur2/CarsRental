using CarsRental.Domain.Entities.Cars;
using Microsoft.EntityFrameworkCore;

namespace CarsRental.Infrastructure.Storage.Ef
{
    public class CarsRentalDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=CarsRental.db;Cache=Shared");
            dbContextOptionsBuilder.EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarAttribute>()
                .HasKey(x => new { x.CarId, x.CarAttributeTypeId });

            modelBuilder.Entity<CarAttribute>()
                .HasOne(o => o.Car)
                .WithMany(o => o.CarAttributes)
                .HasForeignKey(o => o.CarId);

            modelBuilder.Entity<CarAttribute>()
                .HasOne(o => o.CarAttributeType)
                .WithMany(o => o.CarAttributes)
                .HasForeignKey(o => o.CarAttributeTypeId);
        }
    }
}
