using System.Threading.Tasks;

namespace MobiliTips.MvxPlugin.MvxAms.Data
{
    public interface IMvxAmsRemoteTableService<T> : IMvxAmsTableService<T>
    {
        Task UndeleteAsync(T instance);
    }
}
