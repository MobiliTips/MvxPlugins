namespace MobiliTips.MvxPlugins.MvxAms.LocalStore
{
    /// <summary>
    /// MvxAms Local Store plugin configuration
    /// </summary>
    public interface IMvxAmsPluginLocalStoreExtensionConfiguration
    {
        /// <summary>
        /// Database file full device path
        /// </summary>
        string DatabaseFullPath { get; set; }

        /// <summary>
        /// Database file name with db extension
        /// </summary>
        /// <value>amslocalstore.db</value>
        string DatabaseFileName { get; set; }
    }
}