using System;

namespace PrismTabNavigationRepro.Services
{
    public interface IDeeplinkService
    {
        event EventHandler<Uri> DeeplinkRequested;
        void AddDeeplinkRequest(Uri uri);
    }
}