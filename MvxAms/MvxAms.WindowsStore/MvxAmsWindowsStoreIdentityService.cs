using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugins.MvxAms.Identity;

namespace MobiliTips.MvxPlugins.MvxAms.WindowsStore
{
    public class MvxAmsWindowsStoreIdentityService : IMvxAmsPlatformIdentityService
    {
        private readonly IMobileServiceClient _client;

        public MvxAmsWindowsStoreIdentityService()
        {
            _client = Mvx.Resolve<IMobileServiceClient>();
        }

        public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            return await _client.LoginAsync(provider, parameters);
        }
    }
}
