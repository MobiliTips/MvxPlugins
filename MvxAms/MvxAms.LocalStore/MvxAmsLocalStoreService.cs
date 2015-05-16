using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MobiliTips.MvxPlugins.MvxAms.Data;

namespace MobiliTips.MvxPlugins.MvxAms.LocalStore
{
    internal class MvxAmsLocalStoreService : IMvxAmsLocalStoreService
    {
        private IMvxAmsPluginConfiguration _configuration;
        private IMvxAmsPluginLocalStoreExtensionConfiguration _localStoreConfiguration;
        private MobileServiceSQLiteStore _localStore;
        private IMobileServiceClient _client;

        public async Task<bool> InitializeAsync(List<Type> tableTypes = null)
        {
            _client = Mvx.Resolve<IMobileServiceClient>();
            if (!_client.SyncContext.IsInitialized)
            {
                _configuration = Mvx.Resolve<IMvxAmsPluginConfiguration>();
                _localStoreConfiguration = Mvx.Resolve<IMvxAmsPluginLocalStoreExtensionConfiguration>();

                // Init local store
                var fullPath = Path.Combine(_localStoreConfiguration.DatabaseFullPath, _localStoreConfiguration.DatabaseFileName);
                try
                {
                    _localStore = new MobileServiceSQLiteStore(fullPath);
                }
                catch (Exception ex)
                {
                    Mvx.TaggedError("MvxAms", string.Format("Unable to create database file {0}. Local store initialization terminated with error: {1}", fullPath, ex.Message));
                    return false;
                }

                // Get the list of tables
                if (tableTypes == null)
                {
                    try
                    {
                        tableTypes = _configuration.ModelAssembly.GetTypes().Where(type => typeof(ITableData).IsAssignableFrom(type)).ToList();
                    }
                    catch (Exception)
                    {
                        Mvx.TaggedError("MvxAms", string.Format("Unable to find any class inheriting ITableData or EntityData into {0}.", _configuration.ModelAssembly.FullName));
                        return false;
                    } 
                }

                // Define local tables
                foreach (var tableType in tableTypes)
                {
                    var defineTable = GetType().GetMethod("DefineTable", BindingFlags.None).MakeGenericMethod(tableType);
                    defineTable.Invoke(this, null);
                }

                var syncHandlerType = _configuration.ModelAssembly.GetTypes().FirstOrDefault(type => typeof(IMobileServiceSyncHandler).IsAssignableFrom(type));
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
            }
            return _client.SyncContext.IsInitialized;
        }

        private void DefineTable<T>()
        {
            _localStore.DefineTable<T>();
        }

        public IMvxAmsLocalTableService<T> GetLocalTable<T>()
        {
            IMvxAmsLocalTableService<T> localTable;
            Mvx.TryResolve(out localTable);
            if (localTable == null)
            {
                localTable = new MvxAmsLocalTableService<T>();
                Mvx.RegisterSingleton(localTable);
            }
            return localTable;
        }
    }
}