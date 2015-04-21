using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobiliTips.MvxPlugins.MvxAms.Data
{
    public interface IMvxAmsLocalStoreService
    {
        Task<bool> InitializeAsync(List<Type> tableTypes = null);

        IMvxAmsLocalTableService<T> GetLocalTable<T>();
    }
}
