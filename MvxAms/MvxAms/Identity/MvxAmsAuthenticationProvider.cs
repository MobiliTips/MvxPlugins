using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugins.MvxAms.Identity
{
    public enum MvxAmsAuthenticationProvider
    {
        /// <summary>
        /// Default null authentication provider.
        /// </summary>
        None = 0,
        /// <summary>
        /// Microsoft Account authentication provider.
        /// </summary>
        MicrosoftAccount = 1,
        /// <summary>
        /// Google authentication provider.
        /// </summary>
        Google = 2,
        /// <summary>
        /// Twitter authentication provider.
        /// </summary>
        Twitter = 3,
        /// <summary>
        /// Facebook authentication provider.
        /// </summary>
        Facebook = 4,
        /// <summary>
        /// Azure Active Directory authentication provider.
        /// </summary>
        WindowsAzureActiveDirectory = 5,
        /// <summary>
        /// Classic email and password authentication provider.
        /// </summary>
        EmailPassword = 6
    }

    public static class MvxAmsAuthenticationProviderExtension
    {
        public static MobileServiceAuthenticationProvider ToMobileServiceAuthenticationProvider(
            this MvxAmsAuthenticationProvider authenticationProvider)
        {
            switch (authenticationProvider)
            {
                default:
                    return MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory;
                case MvxAmsAuthenticationProvider.MicrosoftAccount:
                    return MobileServiceAuthenticationProvider.MicrosoftAccount;
                case MvxAmsAuthenticationProvider.Google:
                    return MobileServiceAuthenticationProvider.Google;
                case MvxAmsAuthenticationProvider.Twitter:
                    return MobileServiceAuthenticationProvider.Twitter;
                case MvxAmsAuthenticationProvider.Facebook:
                    return MobileServiceAuthenticationProvider.Facebook;
            }
        }
    }
}
