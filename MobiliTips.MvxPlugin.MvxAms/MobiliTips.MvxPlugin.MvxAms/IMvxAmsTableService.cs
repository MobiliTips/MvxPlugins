using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugin.MvxAms
{
    public interface IMvxAmsTableService<T>
    {
        Task<MobileServiceCollection<T, T>> ToCollectionAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null);
        Task<IList<T>> ToListAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null);
        Task<IEnumerable<T>> ToEnumerableAsync(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null);
        Task<T> LookupAsync(string entityId);
        Task RefreshAsync(T instance);
        Task InsertAsync(T instance);
        Task UpdateAsync(T instance);
        Task DeleteAsync(T instance);
    }
}
