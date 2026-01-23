using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Activity;
using ExilumBBS.Services;

namespace ExilumBBS
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            OnBackPressedDispatcher.AddCallback(new OnBackPressedCallback(this, true));
        }

        internal class OnBackPressedCallback : AndroidX.Activity.OnBackPressedCallback
        {
            private readonly Lazy<INavigationService> _navigationService = new(() => IPlatformApplication.Current!.Services.GetRequiredService<INavigationService>());
            private readonly MainActivity _activity;

            public OnBackPressedCallback(MainActivity activity, bool enabled) : base(enabled)
            {

                _activity = activity;
            }

            public override void HandleOnBackPressed()
            {
                //System.Diagnostics.Debug.WriteLine(_navigationService.Value.Uri);
                _navigationService.Value.NavigateBack();
            }
        }

    }
}
