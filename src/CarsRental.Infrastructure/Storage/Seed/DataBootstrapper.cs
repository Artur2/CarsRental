using System.Threading;
using System.Threading.Tasks;
using CarsRental.Domain.Cars.Entities;
using CarsRental.Domain.Seedwork.Data;
using CarsRental.Domain.Seedwork.Query;

namespace CarsRental.Infrastructure.Storage.Seed
{
    /// <summary>
    /// Default data bootsrapper.
    /// </summary>
    public class DataBootstrapper : IDataBootstrapper
    {
        private readonly IRepository<Car> _carRepository;
        private readonly ISeedDataService _seedDataService;

        public DataBootstrapper(IRepository<Car> carRepository, ISeedDataService seedDataService)
        {
            _carRepository = carRepository;
            _seedDataService = seedDataService;
        }

        /// <inheritdoc cref="IDataBootstrapper.BootstrapAsync(CancellationToken)">
        public async Task BootstrapAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var cars = _seedDataService.GetData<Car>();

            foreach (var car in cars)
            {
                await _carRepository.AddAsync(car, cancellationToken);
            }

            await _carRepository.UnitOfWork.CommitAsync(cancellationToken);
        }
    }
}
