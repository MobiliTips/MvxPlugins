using MobiliTips.MvxPlugin.MvxAms.Api;
using MobiliTips.MvxPlugin.MvxAms.Data;
using MobiliTips.MvxPlugin.MvxAms.Identity;

namespace MobiliTips.MvxPlugin.MvxAms
{
    public interface IMvxAmsService
    {
        IMvxAmsDataService Data { get; }
        IMvxAmsIdentityService Identity { get; }
        IMvxAmsApiService Api { get; }
    }
}
