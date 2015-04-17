using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugins.MvxAms.Identity;
using UIKit;

namespace MobiliTips.MvxPlugins.MvxAms.Touch
{
    public class MvxAmsTouchIdentityService : IMvxAmsPlatformIdentityService
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            return await client.LoginAsync(new RectangleF(), 
                UIApplication.SharedApplication.KeyWindow.RootViewController.NavigationController.TopViewController.View, 
                provider, 
                parameters);
        }
    }
}