using System.Reflection;
using MobiliTips.MvxPlugins.MvxAms;

namespace $rootnamespace$
{
    /// <summary>
    /// MvxAms plugin configuration
    /// </summary>
    public class MvxAmsPluginConfiguration : MvxAmsPluginBaseConfiguration
    {
        public MvxAmsPluginConfiguration()
        {
            AmsAppUrl = "YOUR_AZURE_URL";
            AmsAppKey = "YOUR_AZURE_KEY";
            ModelAssembly = GetType().GetTypeInfo().Assembly;
        }
    }
}
