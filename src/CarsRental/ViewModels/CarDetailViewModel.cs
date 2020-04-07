using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using CarsRental.Core.ViewModels;
using CarsRental.Crosscutting;
using CarsRental.Views;
using Prism.Commands;
using Prism.Regions;

namespace CarsRental.ViewModels
{
    /// <summary>
    /// View model related to car aggregate
    /// </summary>
    public class CarDetailViewModel : ViewModel
    {
        private readonly IRegionManager _regionManager;

        public CarDetailViewModel(IRegionManager regionManager)
        {
            NavigateBackCommand = new DelegateCommand(() => NavigateToList());
            _regionManager = regionManager;
        }

        public string Title { get; set; } = "Test detail view model";

        public ICommand NavigateBackCommand { get; set; }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            var carDetailId = navigationContext.Parameters.GetValue<string>("id");
            Debug.WriteLine(carDetailId);
        }

        private void NavigateToList()
        {
            _regionManager.RequestNavigate(RegionNames.MainContent, nameof(CarsUserControl));
        }
    }
}
