using Cirrious.MvvmCross.Plugins.Messenger;
using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugin.MvxAms
{
    public class MvxAmsErrorMessage : MvxMessage
    {
        public MvxAmsErrorMessage(object sender, MobileServiceInvalidOperationException exception) : base(sender)
        {
            Exception = exception;
        }

        public MobileServiceInvalidOperationException Exception { get; private set; }
    }
}
