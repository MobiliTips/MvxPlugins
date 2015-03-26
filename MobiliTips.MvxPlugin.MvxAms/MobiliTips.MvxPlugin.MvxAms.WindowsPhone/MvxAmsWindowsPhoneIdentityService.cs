using System;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugin.MvxAms.Identity;

namespace MobiliTips.MvxPlugin.MvxAms.WindowsPhone
{
    public class MvxAmsWindowsPhoneIdentityService : IMvxAmsPlatformIdentityService
    {
        private readonly IMvxMessenger _messenger;

        public MvxAmsWindowsPhoneIdentityService()
        {
            _messenger = Mvx.Resolve<IMvxMessenger>();
        }

        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                return await client.LoginAsync(provider);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
                return null;
            }
        }
    }
}
