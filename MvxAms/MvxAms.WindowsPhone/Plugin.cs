using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;
using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugins.MvxAms.Identity;

namespace MobiliTips.MvxPlugins.MvxAms.WindowsPhone
{
    public class Plugin
    : IMvxConfigurablePlugin
    {
        private IMvxAmsPluginConfiguration _configuration;

        public void Configure(IMvxPluginConfiguration configuration)
        {
            if (!(configuration is IMvxAmsPluginConfiguration))
                return;

            _configuration = (IMvxAmsPluginConfiguration)configuration;
        }

        public void Load()
        {
            Mvx.RegisterSingleton(_configuration);
            Mvx.RegisterSingleton<IMobileServiceClient>(new MobileServiceClient(_configuration.AmsAppUrl, _configuration.AmsAppKey));
            Mvx.RegisterType<IMvxAmsPlatformIdentityService, MvxAmsWindowsPhoneIdentityService>();
            Mvx.RegisterType<IMvxAmsService, MvxAmsService>();
        }
    }
}
