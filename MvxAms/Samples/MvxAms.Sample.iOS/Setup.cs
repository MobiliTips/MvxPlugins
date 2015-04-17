using System;
using System.Reflection;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.Views;
using MobiliTips.MvxPlugins.MvxAms;
using MobiliTips.MvxPlugins.MvxForms;
using MvxAms.Sample.iOS.Presenters;
using UIKit;
using Xamarin.Forms;

namespace MvxAms.Sample.iOS
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
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

        protected override IMvxTouchViewPresenter CreatePresenter()
        {
            Forms.Init();

            var presenter = new MvxFormsTouchViewPresenter(new MvxFormsApp(), Window);
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }

        protected override IMvxPluginConfiguration GetPluginConfiguration(Type plugin)
        {
            if(plugin == typeof (MobiliTips.MvxPlugins.MvxAms.Touch.Plugin))
                return new MvxAmsPluginConfiguration();

            return base.GetPluginConfiguration(plugin);
        }
	}
}