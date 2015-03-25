using System;
using System.Reflection;
using Cirrious.CrossCore.Plugins;

namespace MobiliTips.MvxPlugin.MvxAms
{
    public class MvxAmsPluginConfiguration : IMvxAmsPluginConfiguration, IMvxPluginConfiguration
    {
        /// <summary>
        /// MvxAms plugin configuration
        /// </summary>
        /// <param name="amsUrl">Url of your Azure Mobile Service</param>
        /// <param name="amsAppKey">Application key of your Azure Mobile Service</param>
        /// <param name="coreAssembly">Assembly hosting your table classes (usually Core)</param>
        /// <param name="databasePath">Device path for database db file (default: string.Empty)</param>
        /// <param name="databaseName">Database name (default: amslocalstrore.db)</param>
        /// <param name="initTimeOut">Initialization timeout (default: 30sec)</param>
        public MvxAmsPluginConfiguration(string amsUrl, string amsAppKey, Assembly coreAssembly, 
            string databasePath = null, string databaseName = "amslocalstore.db", TimeSpan initTimeOut = default(TimeSpan))
        {
            AmsUrl = amsUrl;
            AmsAppKey = amsAppKey;
            CoreAssembly = coreAssembly;
            DatabasePath = databasePath ?? string.Empty;
            DatabaseName = databaseName;
            InitTimeout = initTimeOut != default(TimeSpan) ? initTimeOut : TimeSpan.FromSeconds(30);
        }

        public string AmsUrl { get; private set; }
        public string AmsAppKey { get; private set; }
        public Assembly CoreAssembly { get; private set; }
        public string DatabasePath { get; private set; }
        public string DatabaseName { get; private set; }
        public TimeSpan InitTimeout { get; set; }
    }
}
