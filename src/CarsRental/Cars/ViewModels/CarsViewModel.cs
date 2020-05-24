using System.Threading.Tasks;
using System.Windows.Input;
using CarsRental.Cars.Views;
using CarsRental.Core.Commands;
using CarsRental.Core.ViewModels;
using CarsRental.Crosscutting;
using CarsRental.Domain.Cars.Entities;
using CarsRental.Domain.Seedwork.Query;
using Prism.Regions;

namespace CarsRental.Cars.ViewModels
{
    /// <summary>
    /// View model related to cars list.
    /// </summary>
    public class CarsViewModel : ViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly IRepository<Car> _carRepository;

        public CarsViewModel(IRegionManager regionManager, IRepository<Car> carRepository)
        {
            _regionManager = regionManager;
            _carRepository = carRepository;
            NavigateToDetailCommand = new AsyncCommand(NavigateToDetailsAsync);
        }

        public string Title { get; set; } = "Cars list";

        public ICommand NavigateToDetailCommand { get; set; }

        public async Task NavigateToDetailsAsync()
        {
            var car = await _carRepository.GetByAsync(1);
            _regionManager.RequestNavigate(RegionNames.MainContent, $"{nameof(CarDetailUserControl)}?id=2");
        }
    }
}
