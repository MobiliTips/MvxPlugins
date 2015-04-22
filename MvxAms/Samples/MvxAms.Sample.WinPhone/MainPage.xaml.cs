using Cirrious.CrossCore;
using Cirrious.MvvmCross.Views;
using MvxAms.Sample.WinPhone.Presenters;

namespace MvxAms.Sample.WinPhone
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