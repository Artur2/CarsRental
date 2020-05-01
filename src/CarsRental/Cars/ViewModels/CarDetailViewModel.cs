using System.Windows.Input;
using CarsRental.Cars.Views;
using CarsRental.Core.ViewModels;
using CarsRental.Crosscutting;
using Microsoft.Extensions.Logging;
using Prism.Commands;
using Prism.Regions;

namespace CarsRental.Cars.ViewModels
{
    /// <summary>
    /// View model related to car aggregate
    /// </summary>
    public class CarDetailViewModel : ViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly ILogger<CarDetailViewModel> _logger;

        public CarDetailViewModel(IRegionManager regionManager, ILogger<CarDetailViewModel> logger)
        {
            NavigateBackCommand = new DelegateCommand(() => NavigateToList());
            _regionManager = regionManager;
            _logger = logger;
        }

        public string Title { get; set; } = "Test detail view model";

        public ICommand NavigateBackCommand { get; set; }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var carDetailIdRaw = navigationContext.Parameters.GetValue<string>("id");

            if (int.TryParse(carDetailIdRaw, out var carDetailId))
            {
                // TODO: Retrive
            }

            _logger.LogInformation(carDetailIdRaw);
        }

        private void NavigateToList() => _regionManager.RequestNavigate(RegionNames.MainContent, nameof(CarsUserControl));
    }
}
