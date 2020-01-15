using System;
using PrismTabNavigationRepro.Services;

namespace PrismTabNavigationRepro.Droid
{
    public class DeeplinkService : IDeeplinkService
    {
        public event EventHandler<Uri> DeeplinkRequested;
        public DeeplinkService()
        {
        }

        public void AddDeeplinkRequest(Uri uri)
        {
            DeeplinkRequested?.Invoke(this, uri);
        }
    }
}