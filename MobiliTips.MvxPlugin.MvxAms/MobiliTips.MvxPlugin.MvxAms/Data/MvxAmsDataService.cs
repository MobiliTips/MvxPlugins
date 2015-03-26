using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace MobiliTips.MvxPlugin.MvxAms.Data
{
    public class MvxAmsDataService : IMvxAmsDataService
    {
        private readonly IMvxAmsPluginConfiguration _configuration;
        private readonly MobileServiceClient _client;
        private readonly IMvxMessenger _messenger;
        private MobileServiceSQLiteStore _localStore;

        public MvxAmsDataService(IMvxAmsPluginConfiguration configuration, MobileServiceClient client)
        {
            _configuration = configuration;
            _client = client;
            _messenger = Mvx.Resolve<IMvxMessenger>();

            // Init tables
            Task.Run(async () => await InitializeAsync());
        }

        private async Task InitializeAsync()
        {
            // Init local store
            var fullPath = Path.Combine(_configuration.DatabasePath, _configuration.DatabaseName);
            _localStore = new MobileServiceSQLiteStore(fullPath);

            // Get the list of tables
            List<Type> tableTypes;
            try
            {
                tableTypes = _configuration.CoreAssembly.GetTypes().Where(type => typeof(ITableData).IsAssignableFrom(type)).ToList();
            }
            catch (Exception)
            {
                Mvx.TaggedError("MvxAms", string.Format("Unable to find any table class into {0}. Please refer to online documentation.", _configuration.CoreAssembly.FullName));
                return;
            }

            // Define local tables
            foreach (var tableType in tableTypes)
            {
                var defineTable = GetType().GetMethod("DefineTable", BindingFlags.None).MakeGenericMethod(tableType);
                defineTable.Invoke(this, null);
            }

            var syncHandlerType = _configuration.CoreAssembly.GetTypes().FirstOrDefault(type => typeof(IMobileServiceSyncHandler).IsAssignableFrom(type));
            var syncHandler = syncHandlerType != null ? (IMobileServiceSyncHandler)Activator.CreateInstance(syncHandlerType) : new MobileServiceSyncHandler();

            // Init local store
            try
            {
                await _client.SyncContext.InitializeAsync(_localStore, syncHandler);
            }
            catch (Exception)
            {
                Mvx.TaggedError("MvxAms", "Unable to initialize local store. Please refer to online documentation.");
            }

            // Get tables
            foreach (var tableType in tableTypes)
            {
                // Get local table
                var localTable = GetType().GetMethod("LocalTable").MakeGenericMethod(tableType);
                localTable.Invoke(this, null);
                
                // Get remote table
                var remoteTable = GetType().GetMethod("RemoteTable").MakeGenericMethod(tableType);
                remoteTable.Invoke(this, null);
            }
        }

        private void DefineTable<T>()
        {
            _localStore.DefineTable<T>();
        }

        public IMvxAmsLocalTableService<T> LocalTable<T>()
        {
            IMvxAmsLocalTableService<T> localTable;
            Mvx.TryResolve(out localTable);
            if (localTable == null)
            {
                localTable = new MvxAmsLocalTableService<T>(_configuration, _client);
                Mvx.RegisterSingleton(localTable);
            }
            return localTable;
        }

        public IMvxAmsRemoteTableService<T> RemoteTable<T>()
        {
            IMvxAmsRemoteTableService<T> remoteTable;
            Mvx.TryResolve(out remoteTable);
            if(remoteTable == null)
            {
                remoteTable = new MvxAmsRemoteTableService<T>(_configuration, _client);
                Mvx.RegisterSingleton(remoteTable);
            }
            return remoteTable;
        }

        public async Task PushAsync()
        {
            if (!_client.SyncContext.IsInitialized)
            {
                Mvx.TaggedError("MvxAms", "Unable to process the request while initialization is not complete");
                return;
            }
            try
            {
                await _client.SyncContext.PushAsync();
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
            }
        }

        public long PendingOperations { get { return _client.SyncContext.PendingOperations; } }
    }
}