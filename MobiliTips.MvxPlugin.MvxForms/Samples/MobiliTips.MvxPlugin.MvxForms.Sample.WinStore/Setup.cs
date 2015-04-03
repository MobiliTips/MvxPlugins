using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsCommon.Platform;
using Windows.UI.Xaml.Controls;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.WindowsCommon.Views;
using MobiliTips.MvxPlugin.MvxForms.Sample.WinStore.Presenters;

namespace MobiliTips.MvxPlugin.MvxForms.Sample.WinStore
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
            var presenter = new MvxFormsWindowsStoreViewPresenter(new MvxFormsApp(), rootFrame);
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }
    }
}