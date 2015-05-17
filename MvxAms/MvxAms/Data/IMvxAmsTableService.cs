using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugins.MvxAms.Data
{
    /// <summary>
    /// Common data request service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMvxAmsTableService<T>
    {
        /// <summary>
        /// Returns data in a new ICollection based on an optional query
        /// </summary>
        /// <param name="query">Optional query to filter collection</param>
        /// <returns>Query filtered ICollection</returns>
        Task<MobileServiceCollection<T, T>> ToCollectionAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null);

        /// <summary>
        /// Returns data in a new IList based on an optional query
        /// </summary>
        /// <param name="query">Optional query to filter collection</param>
        /// <returns>Query filtered IList</returns>
        Task<IList<T>> ToListAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null);

        /// <summary>
        /// Returns data in a new IEnumerable based on an optional query
        /// </summary>
        /// <param name="query">Optional query to filter collection</param>
        /// <returns>Query filtered collection</returns>
        Task<IEnumerable<T>> ToEnumerableAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null);

        /// <summary>
        /// Returns the table instance matching this id
        /// </summary>
        /// <param name="id">Id of the instance to look for</param>
        /// <returns>Table instance</returns>
        Task<T> LookupAsync(string id);

        /// <summary>
        /// Refresh an instance by its latest table values
        /// </summary>
        /// <param name="instance">Table instance to refresh</param>
        /// <returns></returns>
        Task RefreshAsync(T instance);

        /// <summary>
        /// Insert an instance into the table
        /// </summary>
        /// <param name="instance">Instance to insert into the table</param>
        /// <returns></returns>
        Task InsertAsync(T instance);

        /// <summary>
        /// Update a table instance
        /// </summary>
        /// <param name="instance">Instance to update into the table</param>
        /// <returns></returns>
        Task UpdateAsync(T instance);

        /// <summary>
        /// Delete a table instance
        /// </summary>
        /// <param name="instance">Instance to delete from the table</param>
        /// <returns></returns>
        Task DeleteAsync(T instance);
    }

}
