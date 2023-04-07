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
        cityLabel.Text = getWeather.city.name;
        weatherConditionsLabel.Text = getWeather.list[0].weather[0].description;
    }
}
