using Cirrious.CrossCore.Plugins;

namespace MobiliTips.MvxPlugins.MvxAms.LocalStore
{
    /// <summary>
    /// MvxAms Local Store plugin base configuration
    /// </summary>
    public abstract class MvxAmsPluginLocalStoreExtensionBaseConfiguration : IMvxAmsPluginLocalStoreExtensionConfiguration, IMvxPluginConfiguration
    {
        private string _databaseFileName = "amslocalstore.db";

        protected MvxAmsPluginLocalStoreExtensionBaseConfiguration(string databaseFullPath)
        {
            DatabaseFullPath = databaseFullPath;
        }

        /// <summary>
        /// Database file full device path
        /// </summary>
        public string DatabaseFullPath { get; set; }

        /// <summary>
        /// Database file name with db extension
        /// </summary>
        /// <value>amslocalstore.db</value>
        public string DatabaseFileName
        {
            get { return _databaseFileName; }
            set { _databaseFileName = value; }
        }
    }
}
