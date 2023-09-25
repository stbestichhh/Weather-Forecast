using WeatherApp.Services;

namespace WeatherApp;

public partial class WeatherPage : ContentPage, IUpdateApp
{
    private static double latitude;
    public double GetLatitude()
    {
        return latitude;
    }

    private static double longitude;
    public double GetLongtitude()
    {
        return longitude;
    }

    private static string cityName;
    public string GetCityName()
    {
        return cityName;
    }

    private static bool howtoGetDataWeather;
    public bool GetDataWeatherGettingMethod()
    {
        return howtoGetDataWeather;
    }

    private static bool isAlreadyLaunched;

    public WeatherPage()
    {
        InitializeComponent();
    }    

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await LodaDataInRightWay();
    }

    private async Task LodaDataInRightWay()
    {
        if (isAlreadyLaunched == false)
        {
            await GetUsersLocation();
        }

        if (howtoGetDataWeather != false)
        {
            await GetWeatherByLocation(latitude, longitude);
        }
        else
        {
            await GetWeatherBySearchedCity(cityName);
        }
    }

    public async Task GetUsersLocation()
    {
        var userLocation = await Geolocation.GetLocationAsync();
        latitude = userLocation.Latitude;
        longitude = userLocation.Longitude;
        howtoGetDataWeather = true;
        isAlreadyLaunched = true;
    }

    private async void OnLocationButtonClicked(object sender, EventArgs e)
    {
        await GetUsersLocation();
        await GetWeatherByLocation(latitude, longitude);
    }

    private async void OnSearchButtonClicked(object sender, EventArgs e)
    {        
        var searchResponse = await DisplayPromptAsync(title: "", message: "", placeholder: "Enter city name", accept: "Search", cancel: "Cancel");
        try
        {
            if (searchResponse != null)            
                await GetWeatherBySearchedCity(searchResponse);            
        }
        catch (Exception)
        {
            await DisplayAlert(title: "City not found", message:"Make sure the city name is correct and try again.", cancel:"Ok");
        }
        finally
        {
            cityName = searchResponse;
        }
    }

    public async Task GetWeatherByLocation(double latitute, double longitude)
    {
        await ChekInterntetConnectivity();
        var getWeather = await ApiService.GetWeather(latitute, longitude);     
        UpdateUI(getWeather);
        howtoGetDataWeather = true;
    }

    public async Task GetWeatherBySearchedCity(string city)
    {
        await ChekInterntetConnectivity();
        var getWeather = await ApiService.GetWeatherByCity(city);
        UpdateUI(getWeather);
        howtoGetDataWeather = false;
    }

    public void UpdateUI(dynamic getWeather)
    {        
        cityLabel.Text = getWeather.city.name; 
        weatherConditionsLabel.Text = getWeather.list[0].weather[0].description; 
        temperatureValueLabel.Text = getWeather.list[0].main.convertedTemp + "°"; 
        hydrometerValueLabel.Text = getWeather.list[0].main.humidity + " %"; 
        windSpeedLabel.Text = getWeather.list[0].wind.speedInMeters + " m/s";
    }

    public async Task ChekInterntetConnectivity()
    {
        if (Connectivity.Current.NetworkAccess == NetworkAccess.None)
        {
            var result = await DisplayAlert(
                title: "Internet connection not found!",
                message: "Make sure you are connected to the internet and reconnect.",
                accept: "Reconnect",
                cancel: "Exit");

            if (result)
            {
                await LodaDataInRightWay();
            }
        }
    }


    private async void TapRecognizer_Swiped(System.Object sender, Microsoft.Maui.Controls.SwipedEventArgs e)
    {
        await Navigation.PushModalAsync(new DetailedWeatherPage());
    }
}
