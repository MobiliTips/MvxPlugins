using UIKit;

namespace MobiliTips.MvxPlugins.MvxAms.Touch
{
    public class MvxAmsTouchTopViewController : IMvxAmsTouchTopViewController
    {
        public MvxAmsTouchTopViewController(UIViewController topViewController)
        {
            TopViewController = topViewController;
        }

        public UIViewController TopViewController { get; private set; }
    }
}