using WeatherApp.Services;

namespace WeatherApp;

public partial class WeatherPage : ContentPage
{
    public List<Models.List> WeatherList;
    public double latitude;
    public double longitude;

    public WeatherPage()
    {
        InitializeComponent();
        WeatherList = new List<Models.List>();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await GetUsersLocation();
        await GetWeatherByLocationButton(latitude, longitude);
    }

    public async Task GetUsersLocation()
    {
        var userLocation = await Geolocation.GetLocationAsync();
        latitude = userLocation.Latitude;
        longitude = userLocation.Longitude;
    }

    private async void OnLocationButtonClicked(object sender, EventArgs e)
    {
        await GetUsersLocation();
        await GetWeatherByLocationButton(latitude, longitude);
    }

    private async void OnSearchButtonClicked(object sender, EventArgs e)
    {
        var searchResponse = await DisplayPromptAsync(title: "", message: "", placeholder: "Enter city name", accept: "Search", cancel: "Cancel");
        if(searchResponse != null)
        {
            await GetWeatherByCityButton(searchResponse);
        }
    }

    public async Task GetWeatherByLocationButton(double latitute, double longitude)
    {
        var getWeather = await ApiService.GetWeather(latitute, longitude);     
        UpdateUI(getWeather);
    }

    public async Task GetWeatherByCityButton(string city)
    {
        var getWeather = await ApiService.GetWeatherByCity(city);
        UpdateUI(getWeather);
    }

    public void UpdateUI(dynamic getWeather)
    {
        foreach (var weatherOption in getWeather.list)
        {
            WeatherList.Add(weatherOption);
        }
        detailedWeatherDataView.ItemsSource = WeatherList;

        cityLabel.Text = getWeather.city.name; //city name
        weatherConditionsLabel.Text = getWeather.list[0].weather[0].description; //weather description
        temperatureValueLabel.Text = getWeather.list[0].main.convertedTemp + "°C"; //temperature
        hydrometerValueLabel.Text = getWeather.list[0].main.humidity + " %"; //humidity - (ru)влажность
        windSpeedLabel.Text = getWeather.list[0].wind.speedInMeters + " m/s"; //wind speed
        weatherConditionsImage.Source = getWeather.list[0].weather[0].weatherImage; //weather image
    }
}
