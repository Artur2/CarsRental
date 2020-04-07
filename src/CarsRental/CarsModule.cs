using CarsRental.Crosscutting;
using CarsRental.ViewModels;
using CarsRental.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace CarsRental
{
    public class CarsModule : IModule
    {
        public CarsModule()
        {
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManger = containerProvider.Resolve<IRegionManager>();
            regionManger.RegisterViewWithRegion(RegionNames.MainContent, typeof(CarsUserControl));
            regionManger.RegisterViewWithRegion(RegionNames.MainContent, typeof(CarDetailUserControl));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<CarsUserControl, CarsViewModel>();
            ViewModelLocationProvider.Register<CarDetailUserControl, CarDetailViewModel>();
        }
    }
}
