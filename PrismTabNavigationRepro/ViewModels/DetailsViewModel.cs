using System.Diagnostics;
using Prism.Navigation;

namespace PrismTabNavigationRepro.ViewModels
{
    public class DetailsViewModel : INavigatedAware
    {
        private readonly INavigationService navigationService;
        public DetailsViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("id"))
            {
                Debug.WriteLine("Id: " + parameters["id"]);
            }

            var path = this.navigationService.GetNavigationUriPath();
            Debug.WriteLine("Current path: " + path);
        }
    }
}
