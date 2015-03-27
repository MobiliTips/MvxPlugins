using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.Views;
using MobiliTips.MvxPlugin.MvxForms.Sample.iOS.Presenters;
using UIKit;
using Xamarin.Forms;

namespace MobiliTips.MvxPlugin.MvxForms.Sample.iOS
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
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

        protected override IMvxTouchViewPresenter CreatePresenter()
        {
            Forms.Init();

            var presenter = new MvxFormsTouchViewPresenter(new MvxFormsApp(), Window);
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }
	}
}