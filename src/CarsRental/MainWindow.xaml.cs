using System.Threading.Tasks;
using System.Windows;
using CarsRental.Domain.Seedwork.Data;

namespace CarsRental
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDataBootstrapper _dataBootsrapper;

        public MainWindow(IDataBootstrapper dataBootsrapper)
        {
            InitializeComponent();
            _dataBootsrapper = dataBootsrapper;
            Initialized += async (s, e) => await BootstrappAsync();
        }

        public async Task BootstrappAsync() => await _dataBootsrapper.BootstrapAsync(default);
    }
}
