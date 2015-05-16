using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace MobiliTips.MvxPlugins.MvxAms.Data
{
    /// <summary>
    /// Local specific data request service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMvxAmsLocalTableService<T> : IMobileServiceSyncTable<T>
    {
        Task PullAsync();

        Task PullAsync<U>(IMobileServiceTableQuery<U> query);

        Task PullAsync(string query);

        Task PullAsync<U>(IMobileServiceTableQuery<U> query, bool pushOtherTables, CancellationToken cancellationToken);

        Task PullAsync(string query, IDictionary<string, string> parameters, bool pushOtherTables, CancellationToken cancellationToken);

        Task PurgeAsync<U>(IMobileServiceTableQuery<U> query, CancellationToken cancellationToken);

        Task PurgeAsync();

        Task PurgeAsync<U>(IMobileServiceTableQuery<U> query);

        Task PurgeAsync(string query);

        Task PurgeAsync(string query, bool force, CancellationToken cancellationToken);
    }
}
