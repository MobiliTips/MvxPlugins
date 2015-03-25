using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

namespace MobiliTips.MvxPlugin.MvxAms.Identity
{
    public class MvxAmsIdentityService : IMvxAmsIdentityService
    {
        private readonly MobileServiceClient _client;

        public MvxAmsIdentityService(MobileServiceClient client)
        {
            _client = client;
        }

        public MobileServiceUser CurrentUser
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, JObject token)
        {
            throw new System.NotImplementedException();
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }
    }
}