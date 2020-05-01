using System;
using System.Threading;
using System.Threading.Tasks;
using CarsRental.Domain.Cars.Entities;
using CarsRental.Domain.Seedwork.Query;
using CarsRental.Infrastructure.Storage.Ef.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarsRental.Infrastructure.Storage.Ef
{
    /// <summary>
    /// Main context for CarsRental project.
    /// </summary>
    public class CarsRentalDbContext : DbContext, IUnitOfWork
    {
        private readonly ILogger<CarsRentalDbContext> _logger;
        private readonly IDbContextConfiguration _contextConfiguration;

        public CarsRentalDbContext(ILogger<CarsRentalDbContext> logger, IDbContextConfiguration contextConfiguration)
        {
            _logger = logger;
            _contextConfiguration = contextConfiguration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => _contextConfiguration.OnConfiguring(dbContextOptionsBuilder);

        public DbSet<Car> Cars { get; set; }

        public DbSet<Vans> Vans { get; set; }

        public DbSet<SportCar> SportCars { get; set; }

        public DbSet<Sedan> Sedans { get; set; }

        /// <inheritdoc cref="DbContext.OnModelCreating(ModelBuilder)">
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Entity<Car>()
                    .OwnsOne(p => p.Stereo);

                modelBuilder.Entity<Car>()
                    .OwnsOne(p => p.Conditioner);

                modelBuilder.Entity<Car>()
                    .OwnsOne(p => p.Engine);

                modelBuilder.Entity<Car>()
                    .HasDiscriminator(x => x.CarType)
                    .HasValue<Vans>(Constants.CarTypeVans)
                    .HasValue<SportCar>(Constants.CarTypeSport)
                    .HasValue<Sedan>(Constants.CarTypeSedan);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create conceptual model");
                throw;
            }
        }

        /// <inheritdoc cref="IUnitOfWork.CommitAsync(CancellationToken)">
        public async Task CommitAsync(CancellationToken cancellationToken) => await SaveChangesAsync(cancellationToken);

        /// <inheritdoc cref="IUnitOfWork.RollbackAsync(CancellationToken)">
        public async Task RollbackAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Modified || entry.State == EntityState.Deleted) // reload entry if we have modifed or deleted entry.
                {
                    await entry.ReloadAsync();
                }
                else if (entry.State == EntityState.Added) // Remove if we added something.
                {
                    entry.State = EntityState.Detached;
                }
            }
        }
    }
}
