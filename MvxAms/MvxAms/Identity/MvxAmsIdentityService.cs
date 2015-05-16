using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

namespace MobiliTips.MvxPlugins.MvxAms.Identity
{
    internal class MvxAmsIdentityService : IMvxAmsIdentityService
    {
        private readonly IMobileServiceClient _client;
        private readonly IMvxAmsPlatformIdentityService _platformIdentityService;
        private readonly IMvxAmsPluginConfiguration _configuration;

        public MvxAmsIdentityService()
        {
            _client = Mvx.Resolve<IMobileServiceClient>();
            _platformIdentityService = Mvx.Resolve<IMvxAmsPlatformIdentityService>();
            _configuration = Mvx.Resolve<IMvxAmsPluginConfiguration>();
        }

        public MobileServiceUser CurrentUser
        {
            get { return _client.CurrentUser; }
            set { _client.CurrentUser = value; }
        }

        public async Task<MobileServiceUser> LoginAsync(MvxAmsAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            if(provider == MvxAmsAuthenticationProvider.None || provider == MvxAmsAuthenticationProvider.EmailPassword)
                throw new ArgumentException("MvxAmsAuthenticationProvider must be of type MicrosoftAccount, Google, Twitter, Facebook or WindowsAzureActiveDirectory");

            // Run platform specific login process
            var user = await _platformIdentityService.LoginAsync(provider.ToMobileServiceAuthenticationProvider(), parameters);

            // Save new credentials if possible
            if (_configuration.CredentialsCacheService != null)
            {
                _configuration.CredentialsCacheService.SaveCredentials(new MvxAmsCredentials
                {
                    Provider = provider,
                    User = user
                });
            }

            return user;
        }

        public async Task<MobileServiceUser> LoginAsync(MvxAmsAuthenticationProvider provider, JObject token)
        {
            if (provider == MvxAmsAuthenticationProvider.None || provider == MvxAmsAuthenticationProvider.EmailPassword)
                throw new ArgumentException("MvxAmsAuthenticationProvider must be of type MicrosoftAccount, Google, Twitter, Facebook or WindowsAzureActiveDirectory");

            var user = await _client.LoginAsync(provider.ToMobileServiceAuthenticationProvider(), token);

            // Save new credentials if possible
            if (_configuration.CredentialsCacheService != null)
            {
                _configuration.CredentialsCacheService.SaveCredentials(new MvxAmsCredentials
                {
                    Provider = provider,
                    User = user
                });
            }

            return user;
        }

        public async Task<MobileServiceUser> LoginAsync(string email, string password)
        {
            var registrationInfos = new JObject
            {
                {"email", email}, 
                {"password", password}
            };

            // Invoke EmailLogin custom api controller
            var user = await _client.InvokeApiAsync<JObject, MobileServiceUser>("EmailLogin", registrationInfos);

            // Save new credentials if possible
            if (_configuration.CredentialsCacheService != null)
            {
                _configuration.CredentialsCacheService.SaveCredentials(new MvxAmsCredentials
                {
                    Provider = MvxAmsAuthenticationProvider.EmailPassword,
                    User = user
                });
            }

            return user;
        }

        public async Task<MobileServiceUser> RegisterAsync(string email, string password, JObject userInfos = null)
        {
            var registration = new JObject
            {
                {"email", email}, 
                {"password", password},
                userInfos
            };

            // Invoke EmailRegistration custom api controller
            var user = await _client.InvokeApiAsync<JObject, MobileServiceUser>("EmailRegistration", registration);

            // Save new credentials if possible
            if (_configuration.CredentialsCacheService != null)
            {
                _configuration.CredentialsCacheService.SaveCredentials(new MvxAmsCredentials
                {
                    Provider = MvxAmsAuthenticationProvider.EmailPassword,
                    User = user
                });
            }

            return user;
        }

        public async Task<bool> EnsureLoggedInAsync(bool controlToken)
        {
            if (_client.CurrentUser != null)
            {
                if (controlToken)
                {
                    return await ControlToken(_client.CurrentUser.MobileServiceAuthenticationToken);
                }
                return true;
            }

            IMvxAmsCredentials credentials;
            if (_configuration.CredentialsCacheService != null && _configuration.CredentialsCacheService.TryLoadCredentials(out credentials))
            {
                _client.CurrentUser = credentials.User;
                if (controlToken)
                {
                    return await ControlToken(_client.CurrentUser.MobileServiceAuthenticationToken);
                }
                return true;
            }

            return false;
        }

        public void Logout()
        {
            _client.Logout();

            // Clear stored credentials if possible
            if (_configuration.CredentialsCacheService != null)
            {
                _configuration.CredentialsCacheService.ClearCredentials();
            }
        }

        private async Task<bool> ControlToken(string token)
        {
            var tokenObject = new JObject
            {
                { "Token", token }
            };

            // Invoke ControlToken custom api controller
            return await _client.InvokeApiAsync<JObject, bool>("ControlToken", tokenObject);
        }
    }
}