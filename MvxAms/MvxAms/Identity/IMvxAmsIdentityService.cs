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
        /// <param name="provider">Identity provider to log with</param>
        /// <param name="parameters">Optional identity provider specific extra parameters</param>
        /// <returns>An authenticated Azure Mobile Services application user</returns>
        Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null);

        /// <summary>
        /// Logs a user client side into an Azure Mobile Services application
        /// </summary>
        /// <param name="provider">Identity provider to log with</param>
        /// <param name="token">Identity provider authentication token</param>
        /// <returns>An authenticated Azure Mobile Services application user</returns>
        Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, JObject token);

        /// <summary>
        /// Logs a user out from an Azure Mobile Services application
        /// </summary>
        void Logout();
    }
}
