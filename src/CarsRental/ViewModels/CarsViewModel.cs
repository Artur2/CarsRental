using System.Threading.Tasks;
using System.Windows.Input;
using CarsRental.Core.Commands;
using CarsRental.Core.ViewModels;
using CarsRental.Crosscutting;
using CarsRental.Views;
using Microsoft.Extensions.Logging;
using Prism.Regions;

namespace CarsRental.ViewModels
{
    /// <summary>
    /// View model related to cars list.
    /// </summary>
    public class CarsViewModel : ViewModel
    {
        private readonly IRegionManager _regionManager;

        public CarsViewModel(IRegionManager regionManager, ILogger<CarsViewModel> logger)
        {
            _regionManager = regionManager;
            NavigateToDetailCommand = new AsyncCommand(NavigateToDetailsAsync);
        }

        public string Title { get; set; } = "Cars list";

        public ICommand NavigateToDetailCommand { get; set; }

        public Task NavigateToDetailsAsync()
        {
            _regionManager.RequestNavigate(RegionNames.MainContent, $"{nameof(CarDetailUserControl)}?id=2");
            return Task.CompletedTask;
        }
    }
}
