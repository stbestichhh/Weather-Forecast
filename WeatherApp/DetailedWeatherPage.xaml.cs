using WeatherApp.Services;

namespace WeatherApp;

public partial class DetailedWeatherPage : ContentPage
{
    public DetailedWeatherPage()
    {
        InitializeComponent();
    }

    private void OnGoBackButtonClicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushModalAsync(new WeatherPage());
    }


    //Weather Data Code

    private bool weatherDataGettingOption = WeatherPage.howtoGetDataWeather;
    private string cityName = WeatherPage.cityName;
    private double latitude = WeatherPage.latitude;
    private double longitude = WeatherPage.longitude;

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        if (weatherDataGettingOption != false)        
            await GetWeatherByLocationButton(latitude, longitude);        
        else
            await GetWeatherByCityButton(cityName);
    }

    public async Task GetWeatherByCityButton(string city)
    {
        var getWeather = await ApiService.GetWeatherByCity(city);
        UpdateUI(getWeather);
    }

    public async Task GetWeatherByLocationButton(double latitute, double longitude)
    {
        var getWeather = await ApiService.GetWeather(latitute, longitude);
        UpdateUI(getWeather);
    }

    public void UpdateUI(dynamic getWeather)
    {
        todaysDate.Text = DateTime.Now.Date.ToShortDateString();

        tempLabel.Text = getWeather.list[0].main.convertedTemp + "°C";

        minTempLabel.Text = getWeather.list[0].main.convertedMinTemp + "°C";
        maxTempLabel.Text = getWeather.list[0].main.convertedMaxTemp + "°C";

        preassureLabel.Text = getWeather.list[0].main.pressure + "hPa";

        humidityLabel.Text = getWeather.list[0].main.humidity + " %";

        windSpeedLabel.Text = getWeather.list[0].wind.speedInMeters + " m/s";

        sunriseLabel.Text = getWeather.city.sunriseTime;
        sunsetLabel.Text = getWeather.city.sunsetTime;

        cityLabel.Text = getWeather.city.name + ", ";
        countryLabel.Text = getWeather.city.country + "; ";
        latLabel.Text = getWeather.city.coord.lat + ", ";
        lonLabel.Text = getWeather.city.coord.lon + ";";
    }
}
