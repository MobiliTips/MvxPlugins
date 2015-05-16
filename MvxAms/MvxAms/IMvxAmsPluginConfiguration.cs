using System;
using System.Net.Http;
using System.Reflection;
using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugins.MvxAms.Identity;

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
        /// [Optional] Credential cache service to save credentials on device
        /// </summary>
        IMvxAmsCredentialsCacheService CredentialsCacheService { get; set; }
        
        /// <summary>
        /// [Optional] Custom Http message handlers
        /// </summary>
        HttpMessageHandler[] Handlers { get; set; }

        /// <summary>
        /// [Optional] Json serializer settings
        /// </summary>
        MobileServiceJsonSerializerSettings SerializerSettings { get; set; }

        /// <summary>
        /// [Optional] Initialization timeout
        /// </summary>
        /// <value>30sec</value>
        TimeSpan InitTimeout { get; set; }
    }
}
