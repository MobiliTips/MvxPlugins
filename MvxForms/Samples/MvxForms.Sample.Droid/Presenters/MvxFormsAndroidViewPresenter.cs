using Cirrious.MvvmCross.Droid.Views;

namespace MobiliTips.MvxPlugins.MvxForms.Sample.Droid.Presenters
{
    public class MvxFormsAndroidViewPresenter
        : MvxFormsBaseViewPresenter
        , IMvxAndroidViewPresenter
    {
        public MvxFormsAndroidViewPresenter(MvxFormsApp mvxFormsApp, string viewSuffix = "View")
            : base(mvxFormsApp, viewSuffix)
        {
        }
    }
}