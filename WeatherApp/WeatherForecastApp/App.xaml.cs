#if __ANDROID__
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Android.Content.Res;
#endif

namespace WeatherForecastApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderLine", (handler, view) => {
#if __ANDROID__
            (handler.PlatformView as Android.Views.View).SetBackgroundColor(Microsoft.Maui.Graphics.Colors.Transparent.ToAndroid());
#endif
        });
    }
}

