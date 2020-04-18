using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace CarsRental
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell() =>
            Container.Resolve<MainWindow>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry) => ConfigureServices();

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog) => moduleCatalog.AddModule<CarsModule>();

        public void ConfigureServices()
        {
            PrismContainerExtension.Create(Container.GetContainer());
            PrismContainerExtension.Current.RegisterServices(serviceCollection =>
            {
                serviceCollection.ConfigureServices();
            });
        }
    }
}
