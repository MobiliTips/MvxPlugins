using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugins.MvxAms.Identity;

namespace MobiliTips.MvxPlugins.MvxAms.WindowsPhoneStore
{
    public class MvxAmsWindowsPhoneStoreIdentityService : IMvxAmsPlatformIdentityService
    {
        private readonly IMobileServiceClient _client;

        public MvxAmsWindowsPhoneStoreIdentityService()
        {
            _client = Mvx.Resolve<IMobileServiceClient>();
        }

        public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            return await _client.LoginAsync(provider, true, parameters);
        }
    }
}
