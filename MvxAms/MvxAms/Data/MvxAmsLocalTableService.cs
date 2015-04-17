using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace MobiliTips.MvxPlugins.MvxAms.Data
{
    public class MvxAmsLocalTableService<T> : IMvxAmsLocalTableService<T>
    {
        private readonly IMvxAmsPluginConfiguration _configuration;
        private readonly MobileServiceClient _client;
        private IMobileServiceSyncTable<T> _localTable;

        public MvxAmsLocalTableService(IMvxAmsPluginConfiguration configuration, MobileServiceClient client)
        {
            _configuration = configuration;
            _client = client;
        }

        private async Task<bool> InitializeAsync()
        {
            TimeSpan duration;
            var waitingtime = TimeSpan.FromSeconds(1);
            var timeout = _configuration.InitTimeout;
            while (!_client.SyncContext.IsInitialized && duration < timeout)
            {
                await Task.Delay(waitingtime);
                duration = duration.Add(waitingtime);
            }
            if (_client.SyncContext.IsInitialized)
            {
                _localTable = _client.GetSyncTable<T>();
            }

            return _client.SyncContext.IsInitialized;
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

        public async Task Pull(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null)
        {
            if (!await InitializeAsync()) 
                throw new MobileServiceInvalidOperationException("Unable to pull your data. Initialization failed.", null, null);
            
            await _localTable.PullAsync(typeof(T).Name, query == null ? _localTable.CreateQuery() : query(_localTable.CreateQuery()));
        }

        public async Task Purge(bool force = false)
        {
            if (!await InitializeAsync()) 
                throw new MobileServiceInvalidOperationException("Unable to purge your data. Initialization failed.", null, null);
            
            await _localTable.PurgeAsync(force);
        }
    }
}
