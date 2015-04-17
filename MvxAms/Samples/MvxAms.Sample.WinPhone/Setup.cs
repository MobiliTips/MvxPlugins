using System;
using System.Reflection;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using Cirrious.MvvmCross.WindowsPhone.Views;
using Microsoft.Phone.Controls;
using MobiliTips.MvxPlugins.MvxAms;
using MobiliTips.MvxPlugins.MvxForms;
using MvxAms.Sample.WinPhone.Presenters;
using Xamarin.Forms;

namespace MvxAms.Sample.WinPhone
{
    public class Setup : MvxPhoneSetup
    {
        public Setup(PhoneApplicationFrame rootFrame) : base(rootFrame)
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

        protected override IMvxPhoneViewPresenter CreateViewPresenter(PhoneApplicationFrame rootFrame)
        {
            Forms.Init();

            var presenter = new MvxFormsWindowsPhoneViewPresenter(new MvxFormsApp(), rootFrame);
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }

        protected override IMvxPluginConfiguration GetPluginConfiguration(Type plugin)
        {
            if (plugin == typeof(MobiliTips.MvxPlugins.MvxAms.WindowsPhone.Plugin))
                return new MvxAmsPluginConfiguration();

            return base.GetPluginConfiguration(plugin);
        }
    }
}