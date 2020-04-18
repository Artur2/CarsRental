using CarsRental.Domain.Entities.Cars;
using CarsRental.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarsRental.Infrastructure.Storage.Ef
{
    /// <summary>
    /// Main context for CarsRental project.
    /// </summary>
    public class CarsRentalDbContext : DbContext, IUnitOfWork
    {
        private readonly ISeedDataService _seedDataService;

        public CarsRentalDbContext(ISeedDataService seedDataService) => _seedDataService = seedDataService;

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=CarsRental.db;Cache=Shared");
            dbContextOptionsBuilder.EnableDetailedErrors();
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Vans> Vans { get; set; }

        public DbSet<SportCar> SportCars { get; set; }

        public DbSet<Sedan> Sedans { get; set; }

        /// <inheritdoc cref="DbContext.OnModelCreating(ModelBuilder)">
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .OwnsOne(p => p.Stereo);

            modelBuilder.Entity<Car>()
                .OwnsOne(p => p.Conditioner);

            modelBuilder.Entity<Car>()
                .OwnsOne(p => p.Engine)
                .HasData(_seedDataService.GetData<Car>().ToArray());

            modelBuilder.Entity<Vans>()
                .HasData(_seedDataService.GetData<Vans>().ToArray());

            modelBuilder.Entity<SportCar>()
                .HasData(_seedDataService.GetData<Sedan>());

            modelBuilder.Entity<Sedan>()
                .HasData(_seedDataService.GetData<Sedan>());

            modelBuilder.Entity<Car>()
                .HasDiscriminator(x => x.CarType)
                .HasValue<Vans>(Constants.CarTypeVans)
                .HasValue<SportCar>(Constants.CarTypeSport)
                .HasValue<Sedan>(Constants.CarTypeSedan);
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
