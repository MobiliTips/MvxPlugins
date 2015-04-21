using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

namespace MobiliTips.MvxPlugins.MvxAms.Identity
{
    public class MvxAmsIdentityService : IMvxAmsIdentityService
    {
        private readonly IMobileServiceClient _client;
        private readonly IMvxAmsPlatformIdentityService _platformIdentityService;

        public MvxAmsIdentityService()
        {
            _client = Mvx.Resolve<IMobileServiceClient>();
            _platformIdentityService = Mvx.Resolve<IMvxAmsPlatformIdentityService>();
        }

        public MobileServiceUser CurrentUser
        {
            get { return _client.CurrentUser; }
            set { _client.CurrentUser = value; }
        }

        public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            return await _platformIdentityService.LoginAsync(provider, parameters);
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