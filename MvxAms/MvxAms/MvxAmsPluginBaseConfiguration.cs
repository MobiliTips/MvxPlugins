using System;
using System.Reflection;
using Cirrious.CrossCore.Plugins;

namespace MobiliTips.MvxPlugins.MvxAms
{
    public abstract class MvxAmsPluginBaseConfiguration : IMvxAmsPluginConfiguration, IMvxPluginConfiguration
    {
        private string _databaseName = "amslocalstore.db";
        private TimeSpan _initTimeout = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Azure Mobile Service application URL
        /// </summary>
        public string AmsAppUrl { get; set; }

        /// <summary>
        /// Azure Mobile Service application Key
        /// </summary>
        public string AmsAppKey { get; set; }

        /// <summary>
        /// Assembly hosting model classes (usually Core)
        /// </summary>
        public Assembly ModelAssembly { get; set; }

        /// <summary>
        /// Database file device path
        /// </summary>
        /// <value>platform default root storage</value>
        public string DatabasePath { get; set; }

        /// <summary>
        /// Database name
        /// </summary>
        /// <value>amslocalstore.db</value>
        public string DatabaseName
        {
            get { return _databaseName; }
            set { _databaseName = value; }
        }

        /// <summary>
        /// Initialization timeout
        /// </summary>
        /// <value>30sec</value>
        public TimeSpan InitTimeout
        {
            get { return _initTimeout; }
            set { _initTimeout = value; }
        }
    }
}
