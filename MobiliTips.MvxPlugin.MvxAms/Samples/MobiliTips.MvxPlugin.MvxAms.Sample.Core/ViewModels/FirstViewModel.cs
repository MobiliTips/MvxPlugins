using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugin.MvxAms.Sample.Core.Model;

namespace MobiliTips.MvxPlugin.MvxAms.Sample.Core.ViewModels
{
    public class FirstViewModel 
		: BaseViewModel
    {
        private readonly IMvxAmsService _azureMobileService;

        public FirstViewModel(IMvxAmsService azureMobileService)
        {
            _azureMobileService = azureMobileService;
        }

        public async Task Init()
        {
            await _azureMobileService.Data.LocalTable<Place>().Pull();
            Places = await _azureMobileService.Data.LocalTable<Place>().ToCollectionAsync(query => query.Where(place => place.Name.Contains("Test")).Take(3));
        }

        private ObservableCollection<Place> _places;
        public ObservableCollection<Place> Places
		{
            get { return _places; }
            set { SetProperty(ref _places, value, () => Places); }
		}

        private MvxCommand _refreshAsyncCommand;
        public ICommand RefreshAsyncCommand
        {
            get
            {
                _refreshAsyncCommand = _refreshAsyncCommand ?? new MvxCommand(async () => await RefreshAsync());
                return _refreshAsyncCommand;
            }
        }

        private async Task RefreshAsync()
        {
            Places = await _azureMobileService.Data.LocalTable<Place>().ToCollectionAsync(query => query.Where(place => place.Name.Contains("Test")).Take(5));
        }

        private MvxCommand _loginAsyncCommand;
        public ICommand LoginAsyncCommand
        {
            get
            {
                _loginAsyncCommand = _loginAsyncCommand ?? new MvxCommand(async () => await LoginAsync());
                return _loginAsyncCommand;
            }
        }

        private async Task LoginAsync()
        {
            User = await _azureMobileService.Identity.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
        }

        private MobileServiceUser _user;
        public MobileServiceUser User
        {
            get { return _user; }
            set { SetProperty(ref _user, value, () => User); }
        }
    }
}
