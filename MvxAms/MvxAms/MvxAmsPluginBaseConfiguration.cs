using System;
using System.Net.Http;
using System.Reflection;
using Cirrious.CrossCore.Plugins;
using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugins.MvxAms.Identity;

namespace MobiliTips.MvxPlugins.MvxAms
{
    /// <summary>
    /// MvxAms plugin base configuration
    /// </summary>
    public abstract class MvxAmsPluginBaseConfiguration : IMvxAmsPluginConfiguration, IMvxPluginConfiguration
    {
        private TimeSpan _initTimeout = TimeSpan.FromSeconds(30);
        private MobileServiceJsonSerializerSettings _serializerSettings = new MobileServiceJsonSerializerSettings();

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
        /// [Optional] Credential cache service to save credentials on device
        /// </summary>
        public IMvxAmsCredentialsCacheService CredentialsCacheService { get; set; }

        /// <summary>
        /// Custom Http message handlers (optional)
        /// </summary>
        public HttpMessageHandler[] Handlers { get; set; }

        /// <summary>
        /// Json serializer settings
        /// </summary>
        public MobileServiceJsonSerializerSettings SerializerSettings
        {
            get { return _serializerSettings; }
            set { _serializerSettings = value; }
        }

        /// <summary>
        /// Initialization timeout (optional)
        /// </summary>
        /// <value>30sec</value>
        public TimeSpan InitTimeout
        {
            get { return _initTimeout; }
            set { _initTimeout = value; }
        }
    }
}
