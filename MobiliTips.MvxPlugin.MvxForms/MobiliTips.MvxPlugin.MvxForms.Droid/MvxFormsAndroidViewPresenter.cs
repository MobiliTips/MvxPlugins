using Cirrious.MvvmCross.Droid.Views;

namespace MobiliTips.MvxPlugin.MvxForms.Droid
{
    public class MvxFormsAndroidViewPresenter
        : MvxFormsBaseViewPresenter
        , IMvxAndroidViewPresenter
    {
        public MvxFormsAndroidViewPresenter(MvxFormsApp mvxFormsApp, string viewModelSuffix = "ViewModel", string viewSuffix = "View")
            : base(mvxFormsApp, viewModelSuffix, viewSuffix)
        {
        }
    }
}