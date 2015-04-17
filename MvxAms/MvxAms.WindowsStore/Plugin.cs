using System.IO;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace MobiliTips.MvxPlugins.MvxAms.WindowsStore
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
                _configuration.DatabasePath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            }
            else if (!_configuration.DatabasePath.Contains(Windows.Storage.ApplicationData.Current.LocalFolder.Path))
            {
                _configuration.DatabasePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,
                    _configuration.DatabasePath);
            }
        }

        public void Load()
        {
            Mvx.RegisterSingleton<IMvxAmsService>(new MvxAmsService(_configuration, new MvxAmsWindowsStoreIdentityService()));
        }
    }
}
