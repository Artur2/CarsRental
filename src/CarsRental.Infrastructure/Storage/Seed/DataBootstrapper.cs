using System.Threading;
using System.Threading.Tasks;
using CarsRental.Domain.Cars.Entities;
using CarsRental.Domain.Seedwork.Data;
using CarsRental.Domain.Seedwork.Query;
using Microsoft.Extensions.Logging;

namespace CarsRental.Infrastructure.Storage.Seed
{
    /// <summary>
    /// Default data bootsrapper.
    /// </summary>
    public class DataBootstrapper : IDataBootstrapper
    {
        private readonly IKeyedRepository<Car> _carRepository;
        private readonly IKeyedRepository<Sedan> _sedanRepository;
        private readonly IKeyedRepository<SportCar> _sportCarRepository;
        private readonly IKeyedRepository<Vans> _vansRepository;
        private readonly ISeedDataService _seedDataService;

        public DataBootstrapper(IKeyedRepository<Car> carRepository,
            IKeyedRepository<Sedan> sedanRepository,
            IKeyedRepository<SportCar> sportCarRepository,
            IKeyedRepository<Vans> vansRepository,
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
                await _carRepository.InsertWithKeyAsync(x => x.Id, car, cancellationToken);
            }

            var sedans = _seedDataService.GetData<Sedan>();
            foreach (var sedan in sedans)
            {
                await _sedanRepository.InsertWithKeyAsync(x => x.Id, sedan, cancellationToken);
            }

            var sportCars = _seedDataService.GetData<SportCar>();
            foreach (var sportCar in sportCars)
            {
                await _sportCarRepository.InsertWithKeyAsync(x => x.Id, sportCar, cancellationToken);
            }

            var vans = _seedDataService.GetData<Vans>();
            foreach (var van in vans)
            {
                await _vansRepository.InsertWithKeyAsync(x => x.Id, van, cancellationToken);
            }

            await _vansRepository.UnitOfWork.CommitAsync(cancellationToken);
        }
    }
}
