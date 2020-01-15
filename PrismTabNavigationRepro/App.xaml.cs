using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using PrismTabNavigationRepro.Pages;
using PrismTabNavigationRepro.ViewModels;
using Xamarin.Forms;

namespace PrismTabNavigationRepro
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer) : base(initializer)
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TabPage, TabViewModel>();
            containerRegistry.RegisterForNavigation<FirstTab, FirstViewModel>();
            containerRegistry.RegisterForNavigation<SecondTab, SecondViewModel>();
            containerRegistry.RegisterForNavigation<DetailsPage, DetailsViewModel>();
            containerRegistry.RegisterForNavigation<StartPage, StartViewModel>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var result = await NavigationService.NavigateAsync("StartPage");

            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }
    }
}
