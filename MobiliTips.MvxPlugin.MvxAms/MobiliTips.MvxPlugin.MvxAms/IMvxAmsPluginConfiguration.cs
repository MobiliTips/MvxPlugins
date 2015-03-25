using System;
using System.Reflection;

namespace MobiliTips.MvxPlugin.MvxAms
{
    public interface IMvxAmsPluginConfiguration
    {
        string AmsUrl { get; }
        string AmsAppKey { get; }
        Assembly CoreAssembly { get; }
        string DatabasePath { get; }
        string DatabaseName { get; }
        TimeSpan InitTimeout { get; }
    }
}
