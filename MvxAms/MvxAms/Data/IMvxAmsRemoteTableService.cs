using System.Threading.Tasks;

namespace MobiliTips.MvxPlugins.MvxAms.Data
{
    public interface IMvxAmsRemoteTableService<T> : IMvxAmsTableService<T>
    {
        /// <summary>
        /// Undelete an instance from the remote Azure table if soft delete is enabled
        /// </summary>
        /// <param name="instance">Instance to undelete from table</param>
        /// <returns></returns>
        Task UndeleteAsync(T instance);
    }
}
