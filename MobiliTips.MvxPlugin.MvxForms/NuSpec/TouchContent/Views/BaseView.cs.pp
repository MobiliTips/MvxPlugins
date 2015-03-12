using Cirrious.MvvmCross.Touch.Views;
using Foundation;
using UIKit;

namespace $rootnamespace$.Views
{
    /// <summary>
    /// Defines the BaseView type.
    /// </summary>
    public abstract class BaseView : MvxViewController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseView" /> class.
        /// </summary>
        protected BaseView()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseView"/> class.
        /// </summary>
        /// <param name="nibName">Name of the nib.</param>
        /// <param name="bundle">The bundle.</param>
        protected BaseView(string nibName, NSBundle bundle)
            : base(nibName, bundle)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            EdgesForExtendedLayout = UIRectEdge.None;
        }
    }
}