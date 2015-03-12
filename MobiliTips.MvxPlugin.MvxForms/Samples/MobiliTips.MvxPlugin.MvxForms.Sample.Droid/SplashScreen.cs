using Android.App;
using Android.Content.PM;
using Cirrious.MvvmCross.Droid.Views;
using MobiliTips.MvxPlugin.MvxForms.Droid;
using Xamarin.Forms;

namespace MobiliTips.MvxPlugin.MvxForms.Sample.Droid
{
    [Activity(
		Label = "MobiliTips.MvxPlugin.MvxForms.Sample.Droid"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }

        public override void InitializationComplete()
        {
            StartActivity(typeof(MvxFormsApplicationActivity));
        }

        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            Forms.Init(this, bundle);
            // Leverage controls' StyleId attrib. to Xamarin.UITest
            Forms.ViewInitialized += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.View.StyleId))
                {
                    e.NativeView.ContentDescription = e.View.StyleId;
                }
            };

            base.OnCreate(bundle);
        }

    }
}