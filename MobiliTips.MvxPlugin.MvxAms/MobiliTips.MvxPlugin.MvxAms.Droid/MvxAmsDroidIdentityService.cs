using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;
using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugin.MvxAms.Identity;

namespace MobiliTips.MvxPlugin.MvxAms.Droid
{
    public class MvxAmsDroidIdentityService : IMvxAmsPlatformIdentityService
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            return await client.LoginAsync(Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity, provider, parameters);
        }
    }
}