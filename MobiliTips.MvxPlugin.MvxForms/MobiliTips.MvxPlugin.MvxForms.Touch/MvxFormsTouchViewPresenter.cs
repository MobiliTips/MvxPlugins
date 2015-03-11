using Cirrious.MvvmCross.Touch.Views.Presenters;
using UIKit;
using Xamarin.Forms;

namespace MobiliTips.MvxPlugin.MvxForms.Touch
{
    public class MvxFormsTouchViewPresenter
        : MvxFormsBaseViewPresenter
        , IMvxTouchViewPresenter
    {
        private readonly UIWindow _window;

        public MvxFormsTouchViewPresenter(Application mvxFormsApp, UIWindow window, string viewModelSuffix = "ViewModel", string viewSuffix = "View")
            : base(mvxFormsApp, viewModelSuffix, viewSuffix)
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
