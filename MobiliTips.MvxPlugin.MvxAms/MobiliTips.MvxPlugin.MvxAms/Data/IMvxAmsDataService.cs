using System.Threading.Tasks;

namespace MobiliTips.MvxPlugin.MvxAms.Data
{
    public interface IMvxAmsDataService
    {
        IMvxAmsLocalTableService<T> LocalTable<T>();
        IMvxAmsRemoteTableService<T> RemoteTable<T>();
        Task PushAsync();
        long PendingOperations { get; }
    }
}
