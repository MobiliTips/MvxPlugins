using Cirrious.CrossCore;
using Cirrious.MvvmCross.Views;
using $rootnamespace$.Presenters;

namespace $rootnamespace$
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