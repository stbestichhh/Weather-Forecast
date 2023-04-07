namespace WeatherApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        VersionTracking.Track();
        if(VersionTracking.IsFirstLaunchEver)
        {
            MainPage = new FirstLaunchPage();
        }

        MainPage = new WeatherPage();
    }
}

