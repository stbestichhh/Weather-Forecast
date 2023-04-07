using WeatherApp.Services;

namespace WeatherApp;

public partial class WeatherPage : ContentPage
{
    public WeatherPage()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var getWeather = await ApiService.GetWeather(44, 26); //latitude and longitude

        cityLabel.Text = getWeather.city.name; //city name
        weatherConditionsLabel.Text = getWeather.list[0].weather[0].description; //weather description
        temperatureValueLabel.Text = getWeather.list[0].main.convertedTemp + "°C"; //temperature
        hydrometerValueLabel.Text = getWeather.list[0].main.humidity + " %"; //humidity - (ru)влажность
        windSpeedLabel.Text = getWeather.list[0].wind.speedInMeters + " m/s"; //wind speed
    }
}
