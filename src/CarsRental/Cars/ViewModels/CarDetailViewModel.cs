using System.Windows.Input;
using CarsRental.Cars.Views;
using CarsRental.Core.ViewModels;
using CarsRental.Crosscutting;
using CarsRental.Crosscutting.Logging;
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
        private readonly ILoggerWrapper<CarDetailViewModel> _loggerWrapper;

        public CarDetailViewModel(IRegionManager regionManager, ILoggerWrapper<CarDetailViewModel> loggerWrapper)
        {
            NavigateBackCommand = new DelegateCommand(() => NavigateToList());
            _regionManager = regionManager;
            _loggerWrapper = loggerWrapper;
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

            _loggerWrapper.Information("Test message");
        }

        private void NavigateToList() => _regionManager.RequestNavigate(RegionNames.MainContent, nameof(CarsUserControl));
    }
}
