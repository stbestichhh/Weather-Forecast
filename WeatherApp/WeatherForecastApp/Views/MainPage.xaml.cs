﻿namespace WeatherForecastApp.Views;

public partial class MainPage : ContentPage, IMainPage
{
    public static double latitude { get; private set; }
    public static double longitude { get; private set; }
    public static string cityName { get; private set; }

    public static bool useLocation { get; private set; }
    private bool isAlreadyLaunched;

    Logf<MainPage> logf;    

    public MainPage()
    {
        InitializeComponent();
        logf = new Logf<MainPage>();
        logf.Cleanf();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await CheckConnection();
        await LoadWeatherData();
    }

    public async Task LoadWeatherData()
    {
        if (!isAlreadyLaunched) await GetUserLocation();
        if (useLocation) await Location_LoadWeatherData(latitude, longitude);
        else await City_LoadWeatherData(cityName);
    }

    public async Task GetUserLocation()
    {
        var currentLocation = await Geolocation.GetLocationAsync();
        latitude = currentLocation.Latitude;
        longitude = currentLocation.Longitude;        

        useLocation = true;
        isAlreadyLaunched = true;
    }

    public async Task Location_LoadWeatherData(double latitude, double longitude)
    {
        await CheckConnection();
        var getWeather = await ApiService.GetWeather(latitude, longitude);
        UpdateUI(getWeather);

        useLocation = true;
    }

    public async Task City_LoadWeatherData(string city)
    {
        await CheckConnection();
        var getWeather = await ApiService.GetWeatherByCity(city);
        UpdateUI(getWeather);
        
        useLocation = false;
    }

    public void UpdateUI(dynamic getWeather)
    {        
        LocationEntry.Text = getWeather.city.name;
        WeatherImage.Source = getWeather.list[0].weather[0].weatherImage;
        TempLabel.Text = getWeather.list[0].main.convertedTemp + "°";
        ConditionsLabel.Text = getWeather.list[0].weather[0].description;
        HumidityLabel.Text = getWeather.list[0].main.humidity + " %";
        WindSpeedLabel.Text = getWeather.list[0].wind.speedInMeters + " m/s";
    }

    public async Task CheckConnection()
    {
        if(Connectivity.Current.NetworkAccess == NetworkAccess.None)
        {
            await logf.LogWarn("Internet connection not found.", 102);
            var result = await DisplayAlert(title: "⚠️", message:"Internet connection not found. Make sure you connected to the internet and try again",
                cancel:"Exit", accept:"Reconect");
            if (result)
            {
                await LoadWeatherData();
            }
        }
    }

    async void SearchButton_Clicked(System.Object sender, System.EventArgs e)
    {
        string searchResponse = LocationEntry.Text;
        try
        {
            if (searchResponse != null)
            {
                await City_LoadWeatherData(searchResponse);
            }
        }
        catch (Exception exception)
        {
            await logf.LogError(exception, $"City: {searchResponse} not found.", 101);
            await DisplayAlert(title: "⚠️ City not found!", message:"Make sure the city name is correct and try again.", cancel:"Ok");
        }
        finally
        {
            cityName = searchResponse;
        }
    }

    async void LocationButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await GetUserLocation();
        await Location_LoadWeatherData(latitude, longitude);
    }

    private async void SwipeUpGesture_Swiped(System.Object sender, Microsoft.Maui.Controls.SwipedEventArgs e)
    {        
        await Shell.Current.GoToAsync(AppRoutes.secondaryPageRoute);
    }
}