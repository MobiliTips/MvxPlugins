using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugin.MvxAms
{
    public class MvxAmsRemoteTableService<T> : IMvxAmsRemoteTableService<T>
    {
        private readonly MobileServiceClient _client;
        private readonly IMobileServiceTable<T> _remoteTable;
        private readonly IMvxMessenger _messenger;

        public MvxAmsRemoteTableService(MobileServiceClient client)
        {
            _client = client;
            _remoteTable = _client.GetTable<T>();
            _messenger = Mvx.Resolve<IMvxMessenger>();
        }

        public async Task<MobileServiceCollection<T, T>> ToCollectionAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null)
        {
            if(!_client.SyncContext.IsInitialized) return null;
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
            if (!_client.SyncContext.IsInitialized) return null;
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
            if (!_client.SyncContext.IsInitialized) return null;
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
            if (!_client.SyncContext.IsInitialized) return default(T);
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
            if (!_client.SyncContext.IsInitialized) return;
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
            if (!_client.SyncContext.IsInitialized) return;
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
            if (!_client.SyncContext.IsInitialized) return;
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
            if (!_client.SyncContext.IsInitialized) return;
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
            if (!_client.SyncContext.IsInitialized) return;
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
