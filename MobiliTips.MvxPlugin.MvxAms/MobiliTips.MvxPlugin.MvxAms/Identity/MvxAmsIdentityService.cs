using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

namespace MobiliTips.MvxPlugin.MvxAms.Identity
{
    public class MvxAmsIdentityService : IMvxAmsIdentityService
    {
        private readonly MobileServiceClient _client;
        private readonly IMvxAmsPlatformIdentityService _platformIdentityService;

        public MvxAmsIdentityService(MobileServiceClient client, IMvxAmsPlatformIdentityService platformIdentityService)
        {
            _client = client;
            _platformIdentityService = platformIdentityService;
        }

        public MobileServiceUser CurrentUser
        {
            get { return _client.CurrentUser; }
        }

        public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            return await _platformIdentityService.LoginAsync(_client, provider, parameters);
        }

        public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, JObject token)
        {
            return await _client.LoginAsync(provider, token);
        }

        public void Logout()
        {
            _client.Logout();
        }
    }
}