using WeatherApp.Services;

namespace WeatherApp;

public partial class WeatherPage : ContentPage
{
    public List<Models.List> WeatherList;

    public WeatherPage()
    {
        InitializeComponent();
        WeatherList = new List<Models.List>();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var getWeather = await ApiService.GetWeather(44, 26); //latitude and longitude

        foreach(var weatherOption in getWeather.list)
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
