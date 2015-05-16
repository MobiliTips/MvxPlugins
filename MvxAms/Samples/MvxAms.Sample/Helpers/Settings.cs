// Helpers/Settings.cs

using MobiliTips.MvxPlugins.MvxAms.Identity;
using Refractored.Xam.Settings;
using Refractored.Xam.Settings.Abstractions;

namespace MvxAms.Sample.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
            return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string MvxAmsIdentityUserIdKey = "MvxAmsIdentityUserId";
        private static readonly string MvxAmsIdentityUserIdDefault = string.Empty;
        private const string MvxAmsIdentityAuthTokenKey = "MvxAmsIdentityAuthToken";
        private static readonly string MvxAmsIdentityAuthTokenDefault = string.Empty;
        private const string MvxAmsIdentityProviderKey = "MvxAmsIdentityProvider";
        private static readonly MvxAmsAuthenticationProvider MvxAmsIdentityProviderDefault = MvxAmsAuthenticationProvider.None;

        #endregion


        public static string MvxAmsIdentityUserId
        {
            get
            {
                return AppSettings.GetValueOrDefault(MvxAmsIdentityUserIdKey, MvxAmsIdentityUserIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(MvxAmsIdentityUserIdKey, value);
            }
        }

        public static string MvxAmsIdentityAuthToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(MvxAmsIdentityAuthTokenKey, MvxAmsIdentityAuthTokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(MvxAmsIdentityAuthTokenKey, value);
            }
        }

        public static MvxAmsAuthenticationProvider MvxAmsIdentityProvider
        {
            get
            {
                return AppSettings.GetValueOrDefault(MvxAmsIdentityProviderKey, MvxAmsIdentityProviderDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(MvxAmsIdentityProviderKey, value);
            }
        }
    }
}