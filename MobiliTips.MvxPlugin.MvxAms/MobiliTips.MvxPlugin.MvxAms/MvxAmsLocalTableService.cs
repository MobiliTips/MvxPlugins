﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace MobiliTips.MvxPlugin.MvxAms
{
    public class MvxAmsLocalTableService<T> : IMvxAmsLocalTableService<T>
    {
        private readonly MobileServiceClient _client;
        private readonly IMobileServiceSyncTable<T> _localTable;
        private readonly IMvxMessenger _messenger;

        public MvxAmsLocalTableService(MobileServiceClient client)
        {
            _client = client;
            _localTable = _client.GetSyncTable<T>();
            _messenger = Mvx.Resolve<IMvxMessenger>();
        }

        public async Task<MobileServiceCollection<T, T>> ToCollectionAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null)
        {
            if (!_client.SyncContext.IsInitialized) return null;
            try
            {
                return query == null ? await _localTable.CreateQuery().ToCollectionAsync() : await query(_localTable.CreateQuery()).ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
                return null;
            }
        }

        public async Task<IList<T>> ToListAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null)
        {
            if (!_client.SyncContext.IsInitialized) return null;
            try
            {
                return query == null ? await _localTable.CreateQuery().ToListAsync() : await query(_localTable.CreateQuery()).ToListAsync();
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
                return null;
            }
        }

        public async Task<IEnumerable<T>> ToEnumerableAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null)
        {
            if (!_client.SyncContext.IsInitialized) return null;
            try
            {
                return query == null ? await _localTable.CreateQuery().ToEnumerableAsync() : await query(_localTable.CreateQuery()).ToEnumerableAsync();
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
                return await _localTable.LookupAsync(entityId);
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
                await _localTable.RefreshAsync(instance);
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
                await _localTable.InsertAsync(instance);
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
                await _localTable.UpdateAsync(instance);
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
                await _localTable.DeleteAsync(instance);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
            }
        }

        public async Task Pull(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null)
        {
            if (!_client.SyncContext.IsInitialized) return;
            try
            {
                await _localTable.PullAsync(typeof(T).Name, query == null ? _localTable.CreateQuery() : query(_localTable.CreateQuery()));
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
            }
        }

        public async Task Purge(bool force = false)
        {
            if (!_client.SyncContext.IsInitialized) return;
            try
            {
                await _localTable.PurgeAsync(force);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
            }
        }
    }
}