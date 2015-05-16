namespace MobiliTips.MvxPlugins.MvxAms.Identity
{
    public interface IMvxAmsCredentialsCacheService
    {
        bool TryLoadCredentials(out IMvxAmsCredentials credentials);

        void SaveCredentials(IMvxAmsCredentials credentials);

        void ClearCredentials();
    }
}
