using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MobiliTips.MvxPlugins.MvxAms.Data;

namespace MobiliTips.MvxPlugins.MvxAms.LocalStore
{
    internal class MvxAmsLocalTableService<T> : IMvxAmsLocalTableService<T>
    {
        private readonly IMvxAmsPluginConfiguration _configuration;
        private readonly IMobileServiceClient _client;
        private readonly IMvxAmsDataService _dataService;
        private IMobileServiceSyncTable<T> _localTable;

        public MvxAmsLocalTableService()
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
                _localTable = _client.GetSyncTable<T>();
            }

            return _dataService.IsInitialized;
        }


        public async Task<MobileServiceCollection<T, T>> ToCollectionAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            return query == null ? await _localTable.CreateQuery().ToCollectionAsync() : await query(_localTable.CreateQuery()).ToCollectionAsync();
        }

        public async Task<IList<T>> ToListAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            return query == null ? await _localTable.CreateQuery().ToListAsync() : await query(_localTable.CreateQuery()).ToListAsync();
        }

        public async Task<IEnumerable<T>> ToEnumerableAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            return query == null ? await _localTable.CreateQuery().ToEnumerableAsync() : await query(_localTable.CreateQuery()).ToEnumerableAsync();
        }

        public async Task<T> LookupAsync(string id)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            return await _localTable.LookupAsync(id);
        }

        public async Task RefreshAsync(T instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to refresh your data. Initialization failed.", null, null);

            await _localTable.RefreshAsync(instance);
        }

        public async Task InsertAsync(T instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to insert your data. Initialization failed.", null, null);

            await _localTable.InsertAsync(instance);
        }

        public async Task UpdateAsync(T instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to update your data. Initialization failed.", null, null);

            await _localTable.UpdateAsync(instance);
        }

        public async Task DeleteAsync(T instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to delete your data. Initialization failed.", null, null);

            await _localTable.DeleteAsync(instance);
        }

        public async Task PullAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to pull your data. Initialization failed.", null, null);

            await _localTable.PullAsync(typeof(T).Name, query == null ? _localTable.CreateQuery() : query(_localTable.CreateQuery()));
        }

        public async Task PurgeAsync(bool force = false)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to purge your data. Initialization failed.", null, null);

            await _localTable.PurgeAsync(force);
        }
    }
}
