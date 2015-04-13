// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the MvxFormsWindowsCommonViewPresenter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Cirrious.MvvmCross.WindowsCommon.Views;
using Xamarin.Forms;

namespace MobiliTips.MvxPlugins.MvxForms.Sample.WindowsCommon.Presenters
{
    /// <summary>
    /// Defines the MvxFormsWindowsCommonViewPresenter type.
    /// </summary>
    public class MvxFormsWindowsStoreViewPresenter
        : MvxFormsBaseViewPresenter
        , IMvxWindowsViewPresenter
    {
        private readonly IMvxWindowsFrame _rootFrame;

        public MvxFormsWindowsStoreViewPresenter(MvxFormsApp mvxFormsApp, IMvxWindowsFrame rootFrame, string viewSuffix = "View")
            : base(mvxFormsApp, viewSuffix)
        {
            _rootFrame = rootFrame;
        }

        protected override void CustomPlatformInitialization(NavigationPage mainPage)
        {
            _rootFrame.Navigate(typeof(MainPage), null);
        }
    }
}
