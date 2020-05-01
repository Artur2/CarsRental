using CarsRental.Cars.ViewModels;
using CarsRental.Cars.Views;
using CarsRental.Crosscutting;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace CarsRental.Cars
{
    /// <summary>
    /// Prism's module related to renting cars and so on.
    /// </summary>
    public class CarsModule : IModule
    {
        public CarsModule()
        {
        }

        /// <inheritdoc cref="IModule.OnInitialized(IContainerProvider)">
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManger = containerProvider.Resolve<IRegionManager>();
            regionManger.RegisterViewWithRegion(RegionNames.MainContent, typeof(CarsUserControl));
            regionManger.RegisterViewWithRegion(RegionNames.MainContent, typeof(CarDetailUserControl));
        }

        /// <inheritdoc cref="IModule.RegisterTypes(IContainerRegistry)">
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<CarsUserControl, CarsViewModel>();
            ViewModelLocationProvider.Register<CarDetailUserControl, CarDetailViewModel>();
        }
    }
}
