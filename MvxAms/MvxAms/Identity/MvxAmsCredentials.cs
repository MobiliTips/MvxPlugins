using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugins.MvxAms.Identity
{
    public class MvxAmsCredentials : IMvxAmsCredentials
    {
        /// <summary>
        /// Identity provider for this User
        /// </summary>
        public MvxAmsAuthenticationProvider Provider { get; set; }

        /// <summary>
        /// Mobile service user
        /// </summary>
        public MobileServiceUser User { get; set; }
    }
}