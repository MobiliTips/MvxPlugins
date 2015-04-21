using System;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsCommon.Platform;
using Windows.UI.Xaml.Controls;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.WindowsCommon.Views;
using MobiliTips.MvxPlugins.MvxForms;
using MvxAms.Sample.Configurations;
using MvxAms.Sample.WindowsCommon.Presenters;

namespace MvxAms.Sample.WindowsCommon
{
    public class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Sample.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxWindowsViewPresenter CreateViewPresenter(IMvxWindowsFrame rootFrame)
        {
            var presenter = new MvxFormsWindowsPhoneViewPresenter(new MvxFormsApp(), rootFrame);
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }

        protected override IMvxPluginConfiguration GetPluginConfiguration(Type plugin)
        {
            if (plugin == typeof(MobiliTips.MvxPlugins.MvxAms.WindowsPhoneStore.Plugin))
                return new MvxAmsPluginConfiguration();

            if (plugin == typeof(MobiliTips.MvxPlugins.MvxAms.LocalStore.PluginLoader))
                return new MvxAmsPluginLocalStoreExtensionConfiguration(Windows.Storage.ApplicationData.Current.LocalFolder.Path);

            return base.GetPluginConfiguration(plugin);
        }
    }
}