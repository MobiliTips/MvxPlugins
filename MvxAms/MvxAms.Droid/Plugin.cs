using System;
using System.IO;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace MobiliTips.MvxPlugins.MvxAms.Droid
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
                _configuration.DatabasePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
            else if (!_configuration.DatabasePath.Contains(Environment.GetFolderPath(Environment.SpecialFolder.Personal)))
            {
                _configuration.DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                _configuration.DatabasePath);
            }
        }

        public void Load()
        {
            Mvx.RegisterSingleton<IMvxAmsService>(new MvxAmsService(_configuration, new MvxAmsDroidIdentityService()));
        }
    }
}
