using System;
using System.Linq;
using Prism.Navigation;
using PrismTabNavigationRepro.Services;

namespace PrismTabNavigationRepro.ViewModels
{
    public class StartViewModel : INavigationAware
    {
        private IDeeplinkService deeplinkService;
        private INavigationService navigationService;
        public StartViewModel(INavigationService navigationService, IDeeplinkService deeplinkService)
        {
            this.navigationService = navigationService;
            this.deeplinkService = deeplinkService;
            this.deeplinkService.DeeplinkRequested += DeeplinkRequested;
        }

        private async void DeeplinkRequested(object sender, Uri uri)
        {
            var id = uri.Segments.Last();
            await this.navigationService.NavigateAsync($"/TabPage?selectedTab=SecondTab/DetailsPage?id={id}");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }
    }
}
