using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MobiliTips.MvxPlugins.MvxAms.Data;
using Newtonsoft.Json.Linq;

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


        public async Task PullAsync()
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.PullAsync(_localTable.TableName, _localTable.CreateQuery());
        }

        public async Task PullAsync<U>(IMobileServiceTableQuery<U> query)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.PullAsync(_localTable.TableName, query);
        }

        public async Task PullAsync(string query)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.PullAsync(_localTable.TableName, query);
        }

        public async Task PullAsync<U>(IMobileServiceTableQuery<U> query, bool pushOtherTables, CancellationToken cancellationToken)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.PullAsync(_localTable.TableName, query, pushOtherTables, cancellationToken);
        }

        public async Task PullAsync(string query, IDictionary<string, string> parameters, bool pushOtherTables, CancellationToken cancellationToken)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.PullAsync(_localTable.TableName, query, parameters, pushOtherTables, cancellationToken);
        }

        public async Task PurgeAsync<U>(IMobileServiceTableQuery<U> query, CancellationToken cancellationToken)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.PurgeAsync(_localTable.TableName, query, cancellationToken);
        }

        public async Task PurgeAsync()
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.PurgeAsync(_localTable.TableName, _localTable.CreateQuery(), new CancellationToken());
        }

        public async Task PurgeAsync<U>(IMobileServiceTableQuery<U> query)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.PurgeAsync(_localTable.TableName, query, new CancellationToken());
        }

        public async Task PurgeAsync(string query)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.PurgeAsync(_localTable.TableName, query, false, new CancellationToken());
        }

        public async Task PurgeAsync(string query, bool force, CancellationToken cancellationToken)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.PurgeAsync(_localTable.TableName, query, force, cancellationToken);
        }

        public async Task<JToken> ReadAsync(string query)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            return await _localTable.ReadAsync(query);
        }

        public async Task<JObject> InsertAsync(JObject instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            return await _localTable.InsertAsync(instance);
        }

        public async Task UpdateAsync(JObject instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.UpdateAsync(instance);
        }

        public async Task DeleteAsync(JObject instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.DeleteAsync(instance);
        }

        async Task<T> IMobileServiceSyncTable<T>.LookupAsync(string id)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            return await _localTable.LookupAsync(id);
        }

        public IMobileServiceTableQuery<T> CreateQuery()
        {
            return _localTable.CreateQuery();
        }

        public IMobileServiceTableQuery<T> IncludeTotalCount()
        {
            return _localTable.IncludeTotalCount();
        }

        public IMobileServiceTableQuery<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _localTable.Where(predicate);
        }

        public IMobileServiceTableQuery<U> Select<U>(Expression<Func<T, U>> selector)
        {
            return _localTable.Select(selector);
        }

        public IMobileServiceTableQuery<T> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return _localTable.OrderBy(keySelector);
        }

        public IMobileServiceTableQuery<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return _localTable.OrderByDescending(keySelector);
        }

        public IMobileServiceTableQuery<T> ThenBy<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return _localTable.ThenBy(keySelector);
        }

        public IMobileServiceTableQuery<T> ThenByDescending<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return _localTable.ThenByDescending(keySelector);
        }

        public IMobileServiceTableQuery<T> Skip(int count)
        {
            return _localTable.Skip(count);
        }

        public IMobileServiceTableQuery<T> Take(int count)
        {
            return _localTable.Take(count);
        }

        public async Task<IEnumerable<T>> ToEnumerableAsync()
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            return await _localTable.ToEnumerableAsync();
        }

        public async Task<List<T>> ToListAsync()
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            return await _localTable.ToListAsync();
        }

        public async Task<IEnumerable<T>> ReadAsync()
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            return await _localTable.ReadAsync();
        }

        public async Task<IEnumerable<U>> ReadAsync<U>(IMobileServiceTableQuery<U> query)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            return await _localTable.ReadAsync(query);
        }

        public async Task RefreshAsync(T instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.RefreshAsync(instance);
        }

        public async Task InsertAsync(T instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.InsertAsync(instance);
        }

        public async Task UpdateAsync(T instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.UpdateAsync(instance);
        }

        public async Task DeleteAsync(T instance)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.DeleteAsync(instance);
        }

        public async Task PullAsync<U>(string queryId, IMobileServiceTableQuery<U> query, bool pushOtherTables,
            CancellationToken cancellationToken)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.PullAsync(queryId, query, pushOtherTables, cancellationToken);
        }

        public async Task PurgeAsync<U>(string queryId, IMobileServiceTableQuery<U> query, CancellationToken cancellationToken)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.PurgeAsync(queryId, query, cancellationToken);
        }

        async Task<JObject> IMobileServiceSyncTable.LookupAsync(string id)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            throw new NotImplementedException();
        }

        public async Task PullAsync(string queryId, string query, IDictionary<string, string> parameters, bool pushOtherTables,
            CancellationToken cancellationToken)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.PullAsync(queryId, query, parameters, pushOtherTables, cancellationToken);
        }

        public async Task PurgeAsync(string queryId, string query, bool force, CancellationToken cancellationToken)
        {
            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to retrieve your data. Initialization failed.", null, null);

            await _localTable.PurgeAsync(queryId, query, force, cancellationToken);
        }

        public MobileServiceClient MobileServiceClient { get { return _localTable.MobileServiceClient; } }

        public string TableName { get { return _localTable.TableName; } }

        public MobileServiceRemoteTableOptions SupportedOptions { 
            get { return _localTable.SupportedOptions; } 
            set { _localTable.SupportedOptions = value; } 
        }
    }
}
