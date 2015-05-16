using Cirrious.CrossCore;
using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugins.MvxAms.Api;
using MobiliTips.MvxPlugins.MvxAms.Data;
using MobiliTips.MvxPlugins.MvxAms.Identity;

namespace MobiliTips.MvxPlugins.MvxAms
{
    public class MvxAmsService : IMvxAmsService
    {
        private readonly IMvxAmsPluginConfiguration _configuration;

        public MvxAmsService()
        {
            _configuration = Mvx.Resolve<IMvxAmsPluginConfiguration>();

            Data = new MvxAmsDataService();
            Mvx.RegisterSingleton(Data);

            Identity = new MvxAmsIdentityService();
            Mvx.RegisterSingleton(Identity);

            Api = new MvxAmsApiService();
            Mvx.RegisterSingleton(Api);
        }

        public IMvxAmsDataService Data { get; private set; }

        public IMvxAmsIdentityService Identity { get; private set; }

        public IMvxAmsApiService Api { get; private set; }

        public MobileServiceJsonSerializerSettings SerializerSettings 
        {
            get { return _configuration.SerializerSettings; }
        }
    }
}