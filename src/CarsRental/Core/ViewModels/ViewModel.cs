using System;
using Prism.Mvvm;
using Prism.Regions;

namespace CarsRental.Core.ViewModels
{
    /// <summary>
    /// Base view model
    /// </summary>
    public class ViewModel : BindableBase, IConfirmNavigationRequest
    {
        /// <inheritdoc cref="IConfirmNavigationRequest.ConfirmNavigationRequest(NavigationContext, Action{bool})">
        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback) => 
            continuationCallback(true);

        /// <inheritdoc cref="INavigationAware.IsNavigationTarget(NavigationContext)">
        public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;


        /// <inheritdoc cref="INavigationAware.OnNavigatedFrom(NavigationContext)">
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        /// <inheritdoc cref="INavigationAware.OnNavigatedTo(NavigationContext)(NavigationContext)">
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
    }
}
