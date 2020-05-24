using System;
using System.Windows;
using CarsRental.Cars;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Serilog;
using Serilog.Events;

namespace CarsRental
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void OnInitialized() => base.OnInitialized();

        public App()
        {
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ConfigureServices();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog) => moduleCatalog.AddModule<CarsModule>();

        public void ConfigureServices()
        {
            PrismContainerExtension.Create(Container.GetContainer());
            PrismContainerExtension.Current.RegisterServices(serviceCollection =>
            {
                serviceCollection.ConfigureServices();
            });
        }

        protected override void OnExit(ExitEventArgs e)
        {

            base.OnExit(e);
        }
    }
}
