using System.IO;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace MobiliTips.MvxPlugins.MvxAms.WindowsPhone
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

            // Combine platform default root storage with the user specified one
            if (string.IsNullOrEmpty(_configuration.DatabasePath))
            {
                _configuration.DatabasePath = string.Empty;
            }
        }

        public void Load()
        {
            Mvx.RegisterSingleton<IMvxAmsService>(new MvxAmsService(_configuration, new MvxAmsWindowsPhoneIdentityService()));
        }
    }
}
