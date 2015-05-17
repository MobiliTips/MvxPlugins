using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugins.MvxAms.Data
{
    /// <summary>
    /// Local specific data request service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMvxAmsLocalTableService<T> : IMvxAmsTableService<T>
    {
        /// <summary>
        /// Pulls all items from remote Azure table matching the optional query
        /// </summary>
        /// <param name="query">Optional query to filter items to pull</param>
        /// <returns></returns>
        Task PullAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null);

        /// <summary>
        /// Deletes all items from local SQLite table
        /// </summary>
        /// <param name="force">Force deletion</param>
        /// <returns></returns>
        Task PurgeAsync(bool force = false);
    }
}
