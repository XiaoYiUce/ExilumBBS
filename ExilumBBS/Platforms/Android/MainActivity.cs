using Android.App;
using Android.Content.PM;
using Android.OS;

namespace ExilumBBS
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public void GetMargin()
        {
            //var marginTop = Platform.CurrentActivity?.Window?.DecorView.RootWindowInsets?.SystemWindowInsetTop ?? 0;
        }
    }
}
