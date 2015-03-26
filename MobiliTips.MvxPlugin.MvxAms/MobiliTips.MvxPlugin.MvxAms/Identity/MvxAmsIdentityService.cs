using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

namespace MobiliTips.MvxPlugin.MvxAms.Identity
{
    public class MvxAmsIdentityService : IMvxAmsIdentityService
    {
        private readonly MobileServiceClient _client;
        private readonly IMvxAmsPlatformIdentityService _platformIdentityService;
        private readonly IMvxMessenger _messenger;

        public MvxAmsIdentityService(MobileServiceClient client, IMvxAmsPlatformIdentityService platformIdentityService)
        {
            _client = client;
            _platformIdentityService = platformIdentityService;
            _messenger = Mvx.Resolve<IMvxMessenger>();
        }

        public MobileServiceUser CurrentUser
        {
            get { return _client.CurrentUser; }
        }

        public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider)
        {
            try
            {
                return await _platformIdentityService.LoginAsync(_client, provider);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
                return null;
            }
        }

        public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, JObject token)
        {
            try
            {
                return await _client.LoginAsync(provider, token);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
                return null;
            }
        }

        public void Logout()
        {
            try
            {
                _client.Logout();
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
            }
        }
    }
}