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
        private readonly IRepository<Sedan> _sedanRepository;
        private readonly IRepository<SportCar> _sportCarRepository;
        private readonly IRepository<Vans> _vansRepository;
        private readonly ISeedDataService _seedDataService;

        public DataBootstrapper(IRepository<Car> carRepository,
            IRepository<Sedan> sedanRepository,
            IRepository<SportCar> sportCarRepository,
            IRepository<Vans> vansRepository,
            ISeedDataService seedDataService)
        {
            _carRepository = carRepository;
            _sedanRepository = sedanRepository;
            _sportCarRepository = sportCarRepository;
            _vansRepository = vansRepository;
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

            var sedans = _seedDataService.GetData<Sedan>();
            foreach (var sedan in sedans)
            {
                await _sedanRepository.AddAsync(sedan, cancellationToken);
            }

            var sportCars = _seedDataService.GetData<SportCar>();
            foreach (var sportCar in sportCars)
            {
                await _sportCarRepository.AddAsync(sportCar, cancellationToken);
            }

            var vans = _seedDataService.GetData<Vans>();
            foreach (var van in vans)
            {
                await _vansRepository.AddAsync(van, cancellationToken);
            }

            await _carRepository.UnitOfWork.CommitAsync(cancellationToken);
        }
    }
}
