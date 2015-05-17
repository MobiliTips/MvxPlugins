using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugins.MvxAms.Data
{
    internal class MvxAmsRemoteTableService<T> : IMvxAmsRemoteTableService<T>
    {
        private readonly IMvxAmsPluginConfiguration _configuration;
        private readonly IMobileServiceClient _client;
        private readonly IMvxAmsDataService _dataService;
        private IMobileServiceTable<T> _remoteTable;

        public MvxAmsRemoteTableService()
        {
            _configuration = Mvx.Resolve<IMvxAmsPluginConfiguration>();
            _client = Mvx.Resolve<IMobileServiceClient>();
            _dataService = Mvx.Resolve<IMvxAmsDataService>();
        }

        private async Task<bool> InitializeAsync()
        {
            TimeSpan duration;
            var waitingtime = TimeSpan.FromSeconds(1);
            var timeout = _configuration.InitTimeout;
            while (!_dataService.IsInitialized && duration < timeout)
            {
                await Task.Delay(waitingtime);
                duration = duration.Add(waitingtime);
            }
            if (_dataService.IsInitialized)
            {
                _remoteTable = _client.GetTable<T>();
            }

            return _dataService.IsInitialized;
        }

        public async Task<MobileServiceCollection<T, T>> ToCollectionAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            return query == null ? await _remoteTable.CreateQuery().ToCollectionAsync() : await query(_remoteTable.CreateQuery()).ToCollectionAsync();
        }

        public async Task<IList<T>> ToListAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            return query == null ? await _remoteTable.CreateQuery().ToListAsync() : await query(_remoteTable.CreateQuery()).ToListAsync();
        }

        public async Task<IEnumerable<T>> ToEnumerableAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            return query == null ? await _remoteTable.CreateQuery().ToEnumerableAsync() : await query(_remoteTable.CreateQuery()).ToEnumerableAsync();
        }

        public async Task<T> LookupAsync(string id)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            return await _remoteTable.LookupAsync(id);
        }

        public async Task RefreshAsync(T instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to refresh your data. Initialization failed.", null, null);

            await _remoteTable.RefreshAsync(instance);
        }

        public async Task InsertAsync(T instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to insert your data. Initialization failed.", null, null);

            await _remoteTable.InsertAsync(instance);
        }

        public async Task UpdateAsync(T instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to update your data. Initialization failed.", null, null);

            await _remoteTable.UpdateAsync(instance);
        }

        public async Task DeleteAsync(T instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to delete your data. Initialization failed.", null, null);

            await _remoteTable.DeleteAsync(instance);
        }

        public async Task UndeleteAsync(T instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to undelete your data. Initialization failed.", null, null);

            await _remoteTable.UndeleteAsync(instance);
        }
    }
}
