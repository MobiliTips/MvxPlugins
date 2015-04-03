using Cirrious.CrossCore;
using Cirrious.MvvmCross.Views;
using MobiliTips.MvxPlugin.MvxForms.Sample.WinStore.Presenters;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MobiliTips.MvxPlugin.MvxForms.Sample.WinStore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            var presenter = Mvx.Resolve<IMvxViewPresenter>() as MvxFormsWindowsStoreViewPresenter;
            if (presenter == null) return;

            LoadApplication(presenter.MvxFormsApp);
        }
    }
}
