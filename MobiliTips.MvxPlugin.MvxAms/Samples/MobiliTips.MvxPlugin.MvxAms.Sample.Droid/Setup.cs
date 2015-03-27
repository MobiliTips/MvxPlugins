using System;
using System.Reflection;
using Acr.XamForms.UserDialogs;
using Acr.XamForms.UserDialogs.Droid;
using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using MobiliTips.MvxPlugin.MvxAms.Sample.Core;
using MobiliTips.MvxPlugin.MvxForms;
using MobiliTips.MvxPlugin.MvxForms.Droid;

namespace MobiliTips.MvxPlugin.MvxAms.Sample.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
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
            return plugin == typeof(MobiliTips.MvxPlugin.MvxAms.Droid.Plugin) ?
                new MvxAmsPluginConfiguration(Config.AzureApplicationUrl,
                    Config.AzureApplicationKey,
                    typeof(Core.App).GetTypeInfo().Assembly) :
                null;
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            // ACR UserDialogs
            Mvx.RegisterSingleton<IUserDialogService>(new UserDialogService());
        }
    }
}