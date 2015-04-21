using Cirrious.CrossCore;
using Cirrious.CrossCore.Exceptions;
using Cirrious.CrossCore.Plugins;
using MobiliTips.MvxPlugins.MvxAms.Data;

namespace MobiliTips.MvxPlugins.MvxAms.LocalStore
{
    public class PluginLoader : IMvxConfigurablePluginLoader
    {
        private bool _loaded;
        public static readonly PluginLoader Instance = new PluginLoader();
        private IMvxAmsPluginLocalStoreExtensionConfiguration _localStoreConfiguration;

        public void EnsureLoaded()
        {
            if (_loaded) return;

            Mvx.RegisterSingleton(_localStoreConfiguration);
            Mvx.RegisterType<IMvxAmsLocalStoreService, MvxAmsLocalStoreService>();

            _loaded = true;
        }

        public void Configure(IMvxPluginConfiguration configuration)
        {
            if (!(configuration is IMvxAmsPluginLocalStoreExtensionConfiguration))
                throw new MvxException(
                    "MvxAms Local Store plugin configuration only supports instances inherited from IMvxAmsPluginLocalStoreConfiguration, you provided {0}",
                    configuration.GetType().Name);

            _localStoreConfiguration = (IMvxAmsPluginLocalStoreExtensionConfiguration)configuration;
        }
    }
}
