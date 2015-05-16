using System.Net.Http;
using System.Reflection;
using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugins.MvxAms;
using MobiliTips.MvxPlugins.MvxAms.Identity;
using MvxAms.Sample.Helpers;

namespace MvxAms.Sample.Configurations
{
    /// <summary>
    /// MvxAms plugin configuration. To know how to use it, please read ToDo-MvxAms 
    /// </summary>
    public class MvxAmsPluginConfiguration : MvxAmsPluginBaseConfiguration
    {
        public MvxAmsPluginConfiguration()
        {
            // [Mandatory] Set the Azure Mobile Services application Url
            AmsAppUrl = "YOUR_AZURE_URL";

            // [Mandatory] Set the Azure Mobile Services application Key
            AmsAppKey = "YOUR_AZURE_KEY";

            // [Mandatory] Tell the plugin which Assembly host your Model classes
            ModelAssembly = GetType().GetTypeInfo().Assembly;

            // [Optional] Credential cache service to save, load and clear credentials from device
            CredentialsCacheService = new MvxAmsCredentialCacheService();

            // [Optional] Add a custom handler if you need to work on http massages (Facebook authentication handling in this example)
            Handlers = new HttpMessageHandler[] { new MvxAmsIdentityHandler(MvxAmsAuthenticationProvider.Facebook) };

            // [Optional] Specify your own json serializer settings
            //SerializerSettings = new MobileServiceJsonSerializerSettings
            //{
            //    CamelCasePropertyNames = true
            //};

            // [Optional] Set your own plugin initialization (default: 30 sec)
            //InitTimeout = TimeSpan.FromSeconds(60);
        }

        /// <summary>
        /// This IMvxAmsCredentialsCacheService implementation is a working example 
        /// requiring the installation of Xamarin Settings plugin.
        /// Uncomment if you want to use it
        /// </summary>
        class MvxAmsCredentialCacheService : IMvxAmsCredentialsCacheService
        {
            public bool TryLoadCredentials(out IMvxAmsCredentials credentials)
            {
                credentials = !string.IsNullOrEmpty(Settings.MvxAmsIdentityUserId)
                              && !string.IsNullOrEmpty(Settings.MvxAmsIdentityAuthToken)
                              && Settings.MvxAmsIdentityProvider != MvxAmsAuthenticationProvider.None
                    ? new MvxAmsCredentials
                    {
                        Provider = Settings.MvxAmsIdentityProvider,
                        User = new MobileServiceUser(Settings.MvxAmsIdentityUserId)
                        {
                            MobileServiceAuthenticationToken = Settings.MvxAmsIdentityAuthToken
                        }
                    }
                    : null;

                return credentials != null;
            }

            public void SaveCredentials(IMvxAmsCredentials credentials)
            {
                if (credentials == null)
                    return;

                Settings.MvxAmsIdentityProvider = credentials.Provider;
                Settings.MvxAmsIdentityUserId = credentials.User.UserId;
                Settings.MvxAmsIdentityAuthToken = credentials.User.MobileServiceAuthenticationToken;
            }

            public void ClearCredentials()
            {
                Settings.MvxAmsIdentityProvider = MvxAmsAuthenticationProvider.None;
                Settings.MvxAmsIdentityUserId = string.Empty;
                Settings.MvxAmsIdentityAuthToken = string.Empty;
            }
        }
    }
}
