using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugins.MvxAms.Data
{
    public class MvxAmsDataService : IMvxAmsDataService
    {
        private readonly IMvxAmsPluginConfiguration _configuration;
        private readonly IMobileServiceClient _client;
        private readonly IMvxAmsLocalStoreService _localStoreService;
        private bool _isInitilized;

        public MvxAmsDataService()
        {
            _configuration = Mvx.Resolve<IMvxAmsPluginConfiguration>();
            _client = Mvx.Resolve<IMobileServiceClient>();
            Mvx.TryResolve(out _localStoreService);

            // Init tables
            Task.Run(async () => await InitializeAsync());
        }

        private async Task<bool> InitializeAsync()
        {
            if (!_isInitilized)
            {
                // Get the list of tables
                List<Type> tableTypes;
                try
                {
                    tableTypes = _configuration.ModelAssembly.GetTypes().Where(type => typeof(ITableData).IsAssignableFrom(type)).ToList();
                }
                catch (Exception)
                {
                    Mvx.TaggedError("MvxAms", string.Format("Unable to find any class inheriting ITableData or EntityData into {0}.", _configuration.ModelAssembly.FullName));
                    return false;
                }

                // Init local store
                if (_localStoreService != null && !_client.SyncContext.IsInitialized)
                {
                    await _localStoreService.InitializeAsync(tableTypes);
                }

                // Get tables
                foreach (var tableType in tableTypes)
                {
                    // Get local table
                    if (_client.SyncContext.IsInitialized)
                    {
                        var localTable = GetType().GetMethod("LocalTable").MakeGenericMethod(tableType);
                        localTable.Invoke(this, null); 
                    }

                    // Get remote table
                    var remoteTable = GetType().GetMethod("RemoteTable").MakeGenericMethod(tableType);
                    remoteTable.Invoke(this, null);
                }

                _isInitilized = _localStoreService == null || _client.SyncContext.IsInitialized;
            }
            return _isInitilized;
        }

        public IMvxAmsLocalTableService<T> LocalTable<T>()
        {
            if (_localStoreService == null)
                throw new TypeLoadException(string.Format("Unable to get {0} local table. ", typeof(T).Name) + 
                    "MvvmCross - Azure Mobile Services Local Store plugin must be installed to process this request.");

            IMvxAmsLocalTableService<T> localTable;
            Mvx.TryResolve(out localTable);
            if (localTable == null)
            {
                localTable = _localStoreService.GetLocalTable<T>();
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
                remoteTable = new MvxAmsRemoteTableService<T>();
                Mvx.RegisterSingleton(remoteTable);
            }
            return remoteTable;
        }

        public async Task PushAsync()
        {
            if (_localStoreService == null)
                throw new TypeLoadException("Unable to push your data. " +
                                            "MvvmCross - Azure Mobile Services Local Store plugin must be installed to process this request.");

            if (!await InitializeAsync())
                throw new MobileServiceInvalidOperationException("Unable to push your data. Initialization failed.", null, null);
            
            await _client.SyncContext.PushAsync();
        }

        public long PendingOperations
        {
            get
            {

                if (_localStoreService == null)
                    throw new TypeLoadException("Unable to get pending operations. " +
                                                "MvvmCross - Azure Mobile Services Local Store plugin must be installed to process this request.");

                return _client.SyncContext.PendingOperations;
            }
        }
    }
}