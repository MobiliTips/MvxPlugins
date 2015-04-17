using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace MobiliTips.MvxPlugins.MvxAms.Touch
{
    public class Plugin
    : IMvxConfigurablePlugin
    {
        private IMvxAmsPluginConfiguration _configuration;

        public void Configure(IMvxPluginConfiguration configuration)
        {
            if (configuration == null)
                return;

            _configuration = (IMvxAmsPluginConfiguration)configuration;
        }

        public void Load()
        {
            Mvx.RegisterSingleton<IMvxAmsService>(new MvxAmsService(_configuration, new MvxAmsTouchIdentityService()));
        }
    }
}
