using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
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

        private MvxCommand _refreshCommand;

        public ICommand RefreshCommand
        {
            get
            {
                _refreshCommand = _refreshCommand ?? new MvxCommand(async () => await Refresh());
                return _refreshCommand;
            }
        }

        private async Task Refresh()
        {
            Places = await _azureMobileService.Data.LocalTable<Place>().ToCollectionAsync(query => query.Where(place => place.Name.Contains("Test")).Take(5));
        }
    }
}
