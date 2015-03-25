using System;
using System.Collections.Generic;
using System.Reflection;
using Cirrious.CrossCore.Plugins;

namespace MobiliTips.MvxPlugin.MvxAms
{
    public class MvxAmsPluginConfiguration : IMvxAmsPluginConfiguration, IMvxPluginConfiguration
    {
        public MvxAmsPluginConfiguration(string url, string key, string databaseName, string databasePath, Assembly coreAssembly)
        {
            Url = url;
            Key = key;
            DatabaseName = databaseName;
            DatabasePath = databasePath;
            CoreAssembly = coreAssembly;
            //Tables = tables;
        }

        public string Url { get; private set; }
        public string Key { get; private set; }
        public string DatabaseName { get; private set; }
        public string DatabasePath { get; private set; }
        public Assembly CoreAssembly { get; private set; }
        //public List<Type> Tables { get; private set; }
    }
}
