using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugin.MvxAms
{
    public class MvxAmsService : IMvxAmsService
    {
        private readonly MobileServiceClient _client;
        private readonly IMvxAmsDataService _data;

        public MvxAmsService(IMvxAmsPluginConfiguration configuration)
        {
            // Init mobile service client
            _client = new MobileServiceClient(configuration.AmsUrl, configuration.AmsAppKey);

            // Init data service
            _data = new MvxAmsDataService(configuration, _client);
        }

        public IMvxAmsDataService Data
        {
            get { return _data; }
        }
    }
}