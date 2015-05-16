using MobiliTips.MvxPlugins.MvxAms.LocalStore;

namespace $rootnamespace$.Configurations
{
    /// <summary>
    /// MvxAms plugin LocalStore extension configuration. To know how to use it, please read the ToDo-MvxAmsLocalStore
    /// </summary>
    public class MvxAmsPluginLocalStoreExtensionConfiguration : MvxAmsPluginLocalStoreExtensionBaseConfiguration
    {
        public MvxAmsPluginLocalStoreExtensionConfiguration(string databaseFullPath) : base(databaseFullPath)
        {
            // Uncomment if you want to provide for all platforms
            // another database file name than the default amslocalstore.db one
            //DatabaseFileName = "YOUR_CUSTOM_NAME_WITH_DB_EXTENSION";
        }
    }
}
