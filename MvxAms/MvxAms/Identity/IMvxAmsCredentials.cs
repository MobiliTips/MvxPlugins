using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugins.MvxAms.Identity
{
    public interface IMvxAmsCredentials
    {
        /// <summary>
        /// Identity provider for this User
        /// </summary>
        MvxAmsAuthenticationProvider Provider { get; set; }

        /// <summary>
        /// Mobile service user
        /// </summary>
        MobileServiceUser User { get; set; }
    }
}
