using System;
using Android.Content;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Prism;
using Prism.Ioc;
using PrismTabNavigationRepro.Services;

namespace PrismTabNavigationRepro.Droid
{
    [Activity(Label = "PrismTabNavigationRepro", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { Intent.ActionView }, Categories = new[] { Intent.ActionView, Intent.CategoryDefault, Intent.CategoryBrowsable }, DataScheme = "deeplink", DataPathPrefix = "/", AutoVerify = true)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IPlatformInitializer
    {
        private IDeeplinkService deeplinkService = new DeeplinkService();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(this));

            var data = Intent?.Data;
            var action = Intent?.Action;
            if (data != null)
            {
                this.deeplinkService.AddDeeplinkRequest(new Uri(data.ToString()));
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <inheritdoc />
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            var data = intent?.Data;
            if (data != null)
            {
                this.deeplinkService.AddDeeplinkRequest(new Uri(data.ToString()));
            }
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            if (containerRegistry == null)
            {
                throw new ArgumentNullException(nameof(containerRegistry));
            }

            containerRegistry.RegisterInstance(typeof(IDeeplinkService), this.deeplinkService);
        }
    }
}