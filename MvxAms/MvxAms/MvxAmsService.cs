using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugins.MvxAms.Api;
using MobiliTips.MvxPlugins.MvxAms.Data;
using MobiliTips.MvxPlugins.MvxAms.Identity;

namespace MobiliTips.MvxPlugins.MvxAms
{
    public class MvxAmsService : IMvxAmsService
    {
        private readonly MobileServiceClient _client;
        private readonly IMvxAmsDataService _data;
        private readonly IMvxAmsIdentityService _identity;
        private readonly IMvxAmsApiService _api;

        public MvxAmsService(IMvxAmsPluginConfiguration configuration, IMvxAmsPlatformIdentityService platformIdentityService)
        {
            // Init mobile service client
            _client = new MobileServiceClient(configuration.AmsAppUrl, configuration.AmsAppKey);

            // Init services
            _data = new MvxAmsDataService(configuration, _client);
            _identity = new MvxAmsIdentityService(_client, platformIdentityService);
            _api = new MvxAmsApiService(_client);
        }

        public IMvxAmsDataService Data
        {
            get { return _data; }
        }

        public IMvxAmsIdentityService Identity
        {
            get { return _identity; }
        }

        public IMvxAmsApiService Api
        {
            get { return _api; }
        }
    }
}