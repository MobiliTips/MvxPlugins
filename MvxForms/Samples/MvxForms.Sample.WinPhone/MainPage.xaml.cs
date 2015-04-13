using Cirrious.CrossCore;
using Cirrious.MvvmCross.Views;
using MobiliTips.MvxPlugins.MvxForms.Sample.WinPhone.Presenters;

namespace MobiliTips.MvxPlugins.MvxForms.Sample.WinPhone
{
    public partial class MainPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            var presenter = Mvx.Resolve<IMvxViewPresenter>() as MvxFormsWindowsPhoneViewPresenter;
            if (presenter == null) return;

            LoadApplication(presenter.MvxFormsApp);
        }
    }
}