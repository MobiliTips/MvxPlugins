using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

namespace MobiliTips.MvxPlugins.MvxAms.Identity
{
    /// <summary>
    /// Service to manage identity
    /// </summary>
    public interface IMvxAmsIdentityService
    {
        /// <summary>
        /// The current authenticated user provided after a successful call to LoginAsync or could be provided manually
        /// </summary>
        MobileServiceUser CurrentUser { get; set; }

        /// <summary>
        /// Logs a user server side into an Azure Mobile Services application
        /// </summary>
        /// <param name="provider">Identity provider to log with (must be of type MicrosoftAccount, Google, Twitter, Facebook or WindowsAzureActiveDirectory)</param>
        /// <param name="parameters">Optional identity provider specific extra parameters</param>
        /// <returns>An authenticated Azure Mobile Services application user</returns>
        Task<MobileServiceUser> LoginAsync(MvxAmsAuthenticationProvider provider, IDictionary<string, string> parameters = null);

        /// <summary>
        /// Logs a user client side into an Azure Mobile Services application
        /// </summary>
        /// <param name="provider">Identity provider to log with (must be of type MicrosoftAccount, Google, Twitter, Facebook or WindowsAzureActiveDirectory)</param>
        /// <param name="token">Identity provider authentication token</param>
        /// <returns>An authenticated Azure Mobile Services application user</returns>
        Task<MobileServiceUser> LoginAsync(MvxAmsAuthenticationProvider provider, JObject token);

        /// <summary>
        /// Logs a user into an Azure Mobile Services application
        /// This request requires you to create an EmailLogin custom api contoller
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        Task<MobileServiceUser> LoginAsync(string email, string password);

        /// <summary>
        /// Register a user into an Azure Mobile Services application
        /// This request requires you to create an EmailRegistration custom api contoller
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        /// <param name="userInfos">Optional user registration informations</param>
        /// <returns></returns>
        Task<MobileServiceUser> RegisterAsync(string email, string password, JObject userInfos = null);

        /// <summary>
        /// Check if user is logged in or silent logs in with stored credentials (if exist)
        /// Setting controlToken to true requires you to create an ControlToken custom api contoller
        /// </summary>
        /// <returns></returns>
        Task<bool> EnsureLoggedInAsync(bool controlToken);

        /// <summary>
        /// Logs a user out from an Azure Mobile Services application
        /// </summary>
        void Logout();
    }
}
