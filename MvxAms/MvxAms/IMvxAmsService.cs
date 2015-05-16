using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugins.MvxAms.Api;
using MobiliTips.MvxPlugins.MvxAms.Data;
using MobiliTips.MvxPlugins.MvxAms.Identity;

namespace MobiliTips.MvxPlugins.MvxAms
{
    /// <summary>
    /// Service to request Azure Mobile Services
    /// </summary>
    public interface IMvxAmsService
    {
        /// <summary>
        /// Service to manage data
        /// </summary>
        IMvxAmsDataService Data { get; }

        /// <summary>
        /// Service to handle user Authentication
        /// </summary>
        IMvxAmsIdentityService Identity { get; }

        /// <summary>
        /// Service to send custom request
        /// </summary>
        IMvxAmsApiService Api { get; }

        /// <summary>
        /// Json serializer settings
        /// </summary>
        MobileServiceJsonSerializerSettings SerializerSettings { get; }
    }
}
