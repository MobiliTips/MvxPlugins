using MobiliTips.MvxPlugin.MvxForms.Sample.WinPhone.Resources;

namespace MobiliTips.MvxPlugin.MvxForms.Sample.WinPhone
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}