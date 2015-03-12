using Cirrious.CrossCore;
using Cirrious.MvvmCross.Views;
using MobiliTips.MvxPlugin.MvxForms.WindowsPhone;
using Xamarin.Forms.Platform.WinPhone;

namespace $rootnamespace$
{
    public partial class MainPage : FormsApplicationPage
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