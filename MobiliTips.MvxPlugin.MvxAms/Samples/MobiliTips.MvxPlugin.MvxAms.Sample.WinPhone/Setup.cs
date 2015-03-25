using System;
using System.Linq;
using System.Reflection;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using Cirrious.MvvmCross.WindowsPhone.Views;
using Microsoft.Phone.Controls;
using MobiliTips.MvxPlugin.MvxForms;
using MobiliTips.MvxPlugin.MvxForms.WindowsPhone;
using Xamarin.Forms;

namespace MobiliTips.MvxPlugin.MvxAms.Sample.WinPhone
{
    public class Setup : MvxPhoneSetup
    {
        public Setup(PhoneApplicationFrame rootFrame) : base(rootFrame)
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

        protected override IMvxPhoneViewPresenter CreateViewPresenter(PhoneApplicationFrame rootFrame)
        {
            Forms.Init();

            var presenter = new MvxFormsWindowsPhoneViewPresenter(new MvxFormsApp(), rootFrame);
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }

        protected override IMvxPluginConfiguration GetPluginConfiguration(Type plugin)
        {
            return plugin == typeof(MobiliTips.MvxPlugin.MvxAms.WindowsPhone.Plugin) ?
                new MvxAmsPluginConfiguration("YOURURL",
                    "YOURKEY", 
                    "amslocalstore.db", 
                    string.Empty,
                    typeof(Core.App).GetTypeInfo().Assembly) : 
                null;
        }
    }
}