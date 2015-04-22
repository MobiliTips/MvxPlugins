using MobiliTips.MvxPlugins.MvxAms.Api;
using MobiliTips.MvxPlugins.MvxAms.Data;
using MobiliTips.MvxPlugins.MvxAms.Identity;

namespace MobiliTips.MvxPlugins.MvxAms
{
    public class MvxAmsService : IMvxAmsService
    {
        private readonly IMvxAmsDataService _data = new MvxAmsDataService();
        private readonly IMvxAmsIdentityService _identity = new MvxAmsIdentityService();
        private readonly IMvxAmsApiService _api = new MvxAmsApiService();

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