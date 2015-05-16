namespace MobiliTips.MvxPlugins.MvxAms.Data
{
    /// <summary>
    /// Manage data
    /// </summary>
    public interface IMvxAmsDataService
    {
        /// <summary>
        /// Manage local SQLite data
        /// </summary>
        /// <typeparam name="T">Data table to manage (model class)</typeparam>
        /// <returns></returns>
        IMvxAmsLocalTableService<T> LocalTable<T>();

        /// <summary>
        /// Manage remote Azure data
        /// </summary>
        /// <typeparam name="T">Data table to manage (model class)</typeparam>
        /// <returns></returns>
        IMvxAmsRemoteTableService<T> RemoteTable<T>();

        /// <summary>
        /// Manage data synchronization
        /// </summary>
        IMvxAmsSynchronizationService Synchronization { get; }

        /// <summary>
        /// Is data service initialized
        /// </summary>
        bool IsInitialized { get; }
    }
}
