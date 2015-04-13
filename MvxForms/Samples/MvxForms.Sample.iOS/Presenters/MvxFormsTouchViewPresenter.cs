using Cirrious.MvvmCross.Touch.Views.Presenters;
using UIKit;
using Xamarin.Forms;

namespace MobiliTips.MvxPlugins.MvxForms.Sample.iOS.Presenters
{
    public class MvxFormsTouchViewPresenter
        : MvxFormsBaseViewPresenter
        , IMvxTouchViewPresenter
    {
        private readonly UIWindow _window;

        public MvxFormsTouchViewPresenter(MvxFormsApp mvxFormsApp, UIWindow window, string viewSuffix = "View")
            : base(mvxFormsApp, viewSuffix)
        {
            _window = window;
        }

        public virtual bool PresentModalViewController(UIViewController controller, bool animated)
        {
            return false;
        }

        public virtual void NativeModalViewControllerDisappearedOnItsOwn()
        {
        }

        protected override void CustomPlatformInitialization(NavigationPage mainPage)
        {
            _window.RootViewController = mainPage.CreateViewController();
        }
    }
}
