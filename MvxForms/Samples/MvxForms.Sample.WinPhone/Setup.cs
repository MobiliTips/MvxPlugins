using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using Cirrious.MvvmCross.WindowsPhone.Views;
using Microsoft.Phone.Controls;
using MobiliTips.MvxPlugins.MvxForms.Sample.WinPhone.Presenters;
using Xamarin.Forms;

namespace MobiliTips.MvxPlugins.MvxForms.Sample.WinPhone
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
    }
}