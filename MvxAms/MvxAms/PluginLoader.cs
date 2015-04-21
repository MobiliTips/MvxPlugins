using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace MobiliTips.MvxPlugins.MvxAms
{
    public class PluginLoader : IMvxPluginLoader
    {
        private bool _loaded;
        public static readonly PluginLoader Instance = new PluginLoader();

        public void EnsureLoaded()
        {
            if (_loaded) return;

            var manager = Mvx.Resolve<IMvxPluginManager>();
            manager.EnsurePlatformAdaptionLoaded<PluginLoader>();

            _loaded = true;
        }
    }
}
