using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugin.MvxAms.Api;
using MobiliTips.MvxPlugin.MvxAms.Data;
using MobiliTips.MvxPlugin.MvxAms.Identity;

namespace MobiliTips.MvxPlugin.MvxAms
{
    public class MvxAmsService : IMvxAmsService
    {
        private readonly MobileServiceClient _client;
        private readonly IMvxAmsDataService _data;
        private readonly IMvxAmsIdentityService _identity;
        private readonly IMvxAmsApiService _api;

        public MvxAmsService(IMvxAmsPluginConfiguration configuration)
        {
            // Init mobile service client
            _client = new MobileServiceClient(configuration.AmsUrl, configuration.AmsAppKey);

            // Init services
            _data = new MvxAmsDataService(configuration, _client);
            _identity = new MvxAmsIdentityService(_client);
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