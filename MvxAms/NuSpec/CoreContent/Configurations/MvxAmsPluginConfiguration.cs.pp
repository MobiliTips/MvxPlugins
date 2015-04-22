using System.Reflection;
using MobiliTips.MvxPlugins.MvxAms;

namespace $rootnamespace$.Configurations
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

            // Uncomment if you want to provide for all platforms 
            // another initialization timeout than the default 30 sec one
            //InitTimeout = TimeSpan.FromSeconds(60);
        }
    }
}
