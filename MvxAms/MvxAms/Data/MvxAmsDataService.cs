using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugins.MvxAms.Data
{
    internal class MvxAmsDataService : IMvxAmsDataService
    {
        private readonly IMvxAmsPluginConfiguration _configuration;
        private readonly IMobileServiceClient _client;
        private readonly IMvxAmsLocalStoreService _localStoreService;
        private readonly IMvxAmsSynchronizationService _synchronization = new MvxAmsSynchronizationService();

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
            if (!IsInitialized)
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

                IsInitialized = _localStoreService == null || _client.SyncContext.IsInitialized;
            }
            return IsInitialized;
        }

        public IMvxAmsLocalTableService<T> LocalTable<T>()
        {
            if (_localStoreService == null)
                throw new TypeLoadException(string.Format("Unable to get {0} local table. ", typeof(T).Name) +
                    "MvvmCross - Azure Mobile Services plugin Local Store extension must be installed to process this request.");

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

        public IMvxAmsSynchronizationService Synchronization { get { return _synchronization; } }

        public bool IsInitialized { get; private set; }
    }
}