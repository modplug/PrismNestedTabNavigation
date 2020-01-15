using System;
using Foundation;
using Prism;
using Prism.Ioc;
using PrismTabNavigationRepro.Services;
using UIKit;

namespace PrismTabNavigationRepro.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IPlatformInitializer
    {

        private IDeeplinkService deeplinkService = new DeeplinkService();
        //
        // This method is invoked when the application has loaded and is ready to run. In this
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(this));

            return base.FinishedLaunching(app, options);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            if (containerRegistry == null)
            {
                throw new ArgumentNullException(nameof(containerRegistry));
            }

            containerRegistry.RegisterInstance(typeof(IDeeplinkService), this.deeplinkService);
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            this.deeplinkService.AddDeeplinkRequest(new Uri(url.ToString()));
            return true;
        }
    }
}
