using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugins.MvxAms.Identity;

namespace MobiliTips.MvxPlugins.MvxAms.WindowsStore
{
    public class MvxAmsWindowsStoreIdentityService : IMvxAmsPlatformIdentityService
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            return await client.LoginAsync(provider, parameters);
        }
    }
}
