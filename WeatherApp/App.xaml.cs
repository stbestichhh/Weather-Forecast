namespace WeatherApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        VersionTracking.Track();
        if(VersionTracking.IsFirstLaunchEver == true)
        {
            MainPage = new FirstLaunchPage();
        }
        else
        {
            MainPage = new WeatherPage();
        }
    }
}

