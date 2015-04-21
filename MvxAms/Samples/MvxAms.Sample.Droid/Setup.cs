using System;
using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using MobiliTips.MvxPlugins.MvxForms;
using MvxAms.Sample.Configurations;
using MvxAms.Sample.Droid.Presenters;

namespace MvxAms.Sample.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var presenter = new MvxFormsAndroidViewPresenter(new MvxFormsApp());
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }

        protected override IMvxPluginConfiguration GetPluginConfiguration(Type plugin)
        {
            if (plugin == typeof (MobiliTips.MvxPlugins.MvxAms.Droid.Plugin))
                return new MvxAmsPluginConfiguration();

            if (plugin == typeof(MobiliTips.MvxPlugins.MvxAms.LocalStore.PluginLoader))
                return new MvxAmsPluginLocalStoreExtensionConfiguration(Environment.GetFolderPath(Environment.SpecialFolder.Personal));

            return base.GetPluginConfiguration(plugin);
        }
    }
}