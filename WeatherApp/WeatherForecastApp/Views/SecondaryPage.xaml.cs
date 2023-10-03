using EasyLogPackage;

namespace WeatherForecastApp.Views;

public partial class SecondaryPage : ContentPage, ISecondaryPageService
{
    Logf<SecondaryPage> logf;
    private double latitude;
    private double longitude;
    private string city;

    public SecondaryPage()
    {
        InitializeComponent();
        logf = new Logf<SecondaryPage>();

        latitude = MainPage.latitude;
        longitude = MainPage.longitude;
        city = MainPage.cityName;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CheckConnection();
        await LoadWeatherData();
    }

    public async Task LoadWeatherData()
    {
        if (MainPage.useLocation) await Location_LoadWeatherData(latitude, longitude);
        else await City_LoadWeatherData(city);
    }

    public async Task Location_LoadWeatherData(double latitude, double longitude)
    {
        var getWeather = await ApiService.GetWeather(latitude, longitude);
        UpdateUI(getWeather);
    }

    public async Task City_LoadWeatherData(string city)
    {
        var getWeather = await ApiService.GetWeatherByCity(city);
        UpdateUI(getWeather);
    }

    public void UpdateUI(dynamic getWeather)
    {
        CollectionView.ItemsSource = getWeather.list;

        //column 1
        tempLabel.Text = getWeather.list[0].main.convertedTemp + "°C";
        minTempLabel.Text = getWeather.list[0].main.convertedMinTemp + "°C";
        sunriseLabel.Text = getWeather.city.sunriseTime;
        sunsetLabel.Text = getWeather.city.sunsetTime;
        humidityLabel.Text = getWeather.list[0].main.humidity + " %";
        seeLevelLabel.Text = getWeather.list[0].main.sea_level + "m";

        //column 2
        feelsLikeTempLabel.Text = getWeather.list[0].main.convertedFeels_like + "°C";
        maxTempLabel.Text = getWeather.list[0].main.convertedMaxTemp + "°C";
        pressureLabel.Text = getWeather.list[0].main.pressure + "hPa";
        cloudsLabel.Text = getWeather.list[0].clouds.all + " %";
        groundLevelLabel.Text = getWeather.list[0].main.grnd_level + "m";
        visibilityLabel.Text = getWeather.list[0].visibility + "m";
    }

    public async Task CheckConnection()
    {
        if(Connectivity.Current.NetworkAccess == NetworkAccess.None)
        {
            await logf.LogWarn("Internet connection not found.", 102);
            var result = await DisplayAlert(title: "⚠️", message: "Internet connection not found. Make sure you connected to the internet and try again",
                cancel: "Exit", accept: "Reconect");
            if (result)
            {
                await LoadWeatherData();
            }
        }        
    }

    private async void SwipeDownGesture_Swiped(System.Object sender, Microsoft.Maui.Controls.SwipedEventArgs e)
    {        
        await Shell.Current.GoToAsync(AppRoutes.mainPageRoute);
    }
}

//TODO
//Fix Frame: Time, Frame layout
//Fix visibility, min max temp