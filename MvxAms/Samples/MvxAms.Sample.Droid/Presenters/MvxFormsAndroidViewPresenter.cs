using Cirrious.MvvmCross.Droid.Views;
using MobiliTips.MvxPlugins.MvxForms;

namespace MvxAms.Sample.Droid.Presenters
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