using Android.App;
using Android.Content.PM;
using Android.OS;

namespace WeatherForecastApp;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        Window.SetStatusBarColor(Android.Graphics.Color.Gray);
        Window.SetNavigationBarColor(Android.Graphics.Color.Transparent);

        base.OnCreate(savedInstanceState);
    }
}

