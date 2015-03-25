using System.Threading.Tasks;

namespace MobiliTips.MvxPlugin.MvxAms
{
    public interface IMvxAmsRemoteTableService<T> : IMvxAmsTableService<T>
    {
        Task UndeleteAsync(T instance);
    }
}
