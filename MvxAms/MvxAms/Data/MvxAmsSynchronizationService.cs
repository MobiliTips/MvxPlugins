using System.Threading;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace MobiliTips.MvxPlugins.MvxAms.Data
{
    internal class MvxAmsSynchronizationService : IMvxAmsSynchronizationService
    {
        private readonly IMobileServiceClient _client;

        public MvxAmsSynchronizationService()
        {
            _client = Mvx.Resolve<IMobileServiceClient>();
        }

        public async Task InitializeAsync(IMobileServiceLocalStore store, IMobileServiceSyncHandler handler)
        {
            await _client.SyncContext.InitializeAsync(store, handler);
        }

        public async Task PushAsync(CancellationToken cancellationToken)
        {
            await _client.SyncContext.PushAsync(cancellationToken);
        }

        public IMobileServiceLocalStore Store { get { return _client.SyncContext.Store; } }

        public IMobileServiceSyncHandler Handler { get { return _client.SyncContext.Handler; } }

        public bool IsInitialized { get { return _client.SyncContext.IsInitialized; } }

        public long PendingOperations { get { return _client.SyncContext.PendingOperations; } }
    }
}