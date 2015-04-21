using System;
using System.Reflection;

namespace MobiliTips.MvxPlugins.MvxAms
{
    /// <summary>
    /// MvxAms plugin configuration
    /// </summary>
    public interface IMvxAmsPluginConfiguration
    {
        /// <summary>
        /// Azure Mobile Service application URL
        /// </summary>
        string AmsAppUrl { get; set; }

        /// <summary>
        /// Azure Mobile Service application Key
        /// </summary>
        string AmsAppKey { get; set; }

        /// <summary>
        /// Assembly hosting model classes (usually Core)
        /// </summary>
        Assembly ModelAssembly { get; set; }

        /// <summary>
        /// Initialization timeout
        /// </summary>
        /// <value>30sec</value>
        TimeSpan InitTimeout { get; set; }
    }
}
