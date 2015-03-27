using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace MobiliTips.MvxPlugin.MvxAms.Droid
{
    public class Plugin
    : IMvxConfigurablePlugin
    {
        private IMvxAmsPluginConfiguration _configuration;

        public void Configure(IMvxPluginConfiguration configuration)
        {
            if (configuration == null)
                return;

            _configuration = (MvxAmsPluginConfiguration)configuration;
        }

        public void Load()
        {
            Mvx.RegisterSingleton<IMvxAmsService>(new MvxAmsService(_configuration, new MvxAmsDroidIdentityService()));
        }
    }
}
