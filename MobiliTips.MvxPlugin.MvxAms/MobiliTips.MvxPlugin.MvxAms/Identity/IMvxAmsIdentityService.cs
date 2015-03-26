using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

namespace MobiliTips.MvxPlugin.MvxAms.Identity
{
    public interface IMvxAmsIdentityService
    {
        MobileServiceUser CurrentUser { get; }
        Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null);
        Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, JObject token);
        void Logout();
    }
}
