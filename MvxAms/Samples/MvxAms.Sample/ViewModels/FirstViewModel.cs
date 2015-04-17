using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Microsoft.WindowsAzure.MobileServices;
using MobiliTips.MvxPlugins.MvxAms;
using MvxAms.Sample.Model;

namespace MvxAms.Sample.ViewModels
{
    public class FirstViewModel 
		: BaseViewModel
    {
        private readonly IMvxAmsService _azureMobileService;
        private string _errorMessage;

        public FirstViewModel(IMvxAmsService azureMobileService)
        {
            _azureMobileService = azureMobileService;
        }

        public async Task Init()
        {
            _errorMessage = null;
            try
            {
                await _azureMobileService.Data.LocalTable<Place>().Pull();
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
            }
            if (!string.IsNullOrEmpty(_errorMessage))
            {
                Mvx.TaggedError("MvxAms", _errorMessage);
            }
            else
            {
                _errorMessage = null;
                try
                {
                    Places = await _azureMobileService.Data.LocalTable<Place>().ToCollectionAsync(query => query.Where(place => place.Name.Contains("Test")).Take(3));
                }
                catch (Exception ex)
                {
                    _errorMessage = ex.Message;
                }
                if (!string.IsNullOrEmpty(_errorMessage))
                {
                    Mvx.TaggedError("MvxAms", _errorMessage);
                }
            }
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
            _errorMessage = null;
            try
            {
                Places = await _azureMobileService.Data.LocalTable<Place>().ToCollectionAsync(query => query.Where(place => place.Name.Contains("Test")).Take(5));
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
            }
            if (!string.IsNullOrEmpty(_errorMessage))
            {
                Mvx.TaggedError("MvxAms", _errorMessage);
            }
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
            _errorMessage = null;
            try
            {
                User = await _azureMobileService.Identity.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
            }
            if (!string.IsNullOrEmpty(_errorMessage))
            {
                Mvx.TaggedError("MvxAms", _errorMessage);
            }
        }

        private MobileServiceUser _user;
        public MobileServiceUser User
        {
            get { return _user; }
            set { SetProperty(ref _user, value, () => User); }
        }
    }
}
