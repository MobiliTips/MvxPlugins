using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugin.MvxAms
{
    public interface IMvxAmsLocalTableService<T> : IMvxAmsTableService<T>
    {
        Task Pull(Func<IMobileServiceTableQuery<T>, IMobileServiceTableQuery<T>> query = null);
        Task Purge(bool force = false);
    }
}
