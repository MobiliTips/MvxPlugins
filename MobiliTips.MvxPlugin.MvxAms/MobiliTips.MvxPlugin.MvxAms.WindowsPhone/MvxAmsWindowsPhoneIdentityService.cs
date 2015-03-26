using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugin.MvxAms.Identity;

namespace MobiliTips.MvxPlugin.MvxAms.WindowsPhone
{
    public class MvxAmsWindowsPhoneIdentityService : IMvxAmsPlatformIdentityService
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            return await client.LoginAsync(provider, parameters);
        }
    }
}
