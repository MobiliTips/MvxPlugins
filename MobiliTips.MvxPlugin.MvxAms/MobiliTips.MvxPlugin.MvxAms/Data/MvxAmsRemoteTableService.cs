using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugin.MvxAms.Data
{
    public class MvxAmsRemoteTableService<T> : IMvxAmsRemoteTableService<T>
    {
        private readonly IMvxAmsPluginConfiguration _configuration;
        private readonly MobileServiceClient _client;
        private IMobileServiceTable<T> _remoteTable;
        private readonly IMvxMessenger _messenger;

        public MvxAmsRemoteTableService(IMvxAmsPluginConfiguration configuration, MobileServiceClient client)
        {
            _configuration = configuration;
            _client = client;
            _messenger = Mvx.Resolve<IMvxMessenger>();
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
                _remoteTable = _client.GetTable<T>();
            }
            else
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, 
                    new MobileServiceInvalidOperationException(string.Format("Initialization timed out after {0} sec", duration.TotalSeconds), null, null)));
            }
            return _client.SyncContext.IsInitialized;
        }

        public async Task<MobileServiceCollection<T, T>> ToCollectionAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null)
        {
            if (!await InitializeAsync()) return null;
            try
            {
                return query == null ? await _remoteTable.CreateQuery().ToCollectionAsync() : await query(_remoteTable.CreateQuery()).ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
                return null;
            }
        }

        public async Task<IList<T>> ToListAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query)
        {
            if (!await InitializeAsync()) return null;
            try
            {
                return query == null ? await _remoteTable.CreateQuery().ToListAsync() : await query(_remoteTable.CreateQuery()).ToListAsync();
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
                return null;
            }
        }

        public async Task<IEnumerable<T>> ToEnumerableAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query)
        {
            if (!await InitializeAsync()) return null;
            try
            {
                return query == null ? await _remoteTable.CreateQuery().ToEnumerableAsync() : await query(_remoteTable.CreateQuery()).ToEnumerableAsync();
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
                return null;
            }
        }

        public async Task<T> LookupAsync(string entityId)
        {
            if (!await InitializeAsync()) return default(T);
            try
            {
                return await _remoteTable.LookupAsync(entityId);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
                return default(T);
            }
        }

        public async Task RefreshAsync(T instance)
        {
            if (!await InitializeAsync()) return;
            try
            {
                await _remoteTable.RefreshAsync(instance);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
            }
        }

        public async Task InsertAsync(T instance)
        {
            if (!await InitializeAsync()) return;
            try
            {
                await _remoteTable.InsertAsync(instance);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
            }
        }

        public async Task UpdateAsync(T instance)
        {
            if (!await InitializeAsync()) return;
            try
            {
                await _remoteTable.UpdateAsync(instance);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
            }
        }

        public async Task DeleteAsync(T instance)
        {
            if (!await InitializeAsync()) return;
            try
            {
                await _remoteTable.DeleteAsync(instance);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
            }
        }

        public async Task UndeleteAsync(T instance)
        {
            if (!await InitializeAsync()) return;
            try
            {
                await _remoteTable.UndeleteAsync(instance);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
            }
        }
    }
}
