using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;
using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugins.MvxAms.Identity;

namespace MobiliTips.MvxPlugins.MvxAms.Droid
{
    public class MvxAmsDroidIdentityService : IMvxAmsPlatformIdentityService
    {
        private readonly IMobileServiceClient _client;

        public MvxAmsDroidIdentityService()
        {
            _client = Mvx.Resolve<IMobileServiceClient>();
        }

        public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            return await _client.LoginAsync(Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity, provider, parameters);
        }
    }
}