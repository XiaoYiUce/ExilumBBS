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

            OnBackPressedDispatcher.AddCallback(new OnBackPressedCallback(true));
        }

        class OnBackPressedCallback(bool enabled) : AndroidX.Activity.OnBackPressedCallback(enabled)
        {
            private readonly Lazy<INavigationService> _navigationService = new(() => IPlatformApplication.Current!.Services.GetRequiredService<INavigationService>());
            private INavigationService NavigationService => _navigationService.Value;

            public override void HandleOnBackPressed()
            {
                NavigationService.NavigateBack();
            }
        }

        public override bool DispatchKeyEvent(KeyEvent? e)
        {
            if (e!.KeyCode == Keycode.Back)
            {
                return true;
            }

            return base.DispatchKeyEvent(e);
        }

    }
}
