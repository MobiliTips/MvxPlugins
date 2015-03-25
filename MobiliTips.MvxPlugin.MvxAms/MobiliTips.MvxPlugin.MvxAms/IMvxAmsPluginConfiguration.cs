using System;
using System.Collections.Generic;
using System.Reflection;

namespace MobiliTips.MvxPlugin.MvxAms
{
    public interface IMvxAmsPluginConfiguration
    {
        string Url { get; }
        string Key { get; }
        string DatabaseName { get; }
        string DatabasePath { get; }
        Assembly CoreAssembly { get; }
        //List<Type> Tables { get; } 
    }
}
