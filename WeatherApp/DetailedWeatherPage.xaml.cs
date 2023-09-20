using WeatherApp.Services;

namespace WeatherApp;

public partial class DetailedWeatherPage : ContentPage, IUpdateApp
{
    private WeatherPage weatherPage = new WeatherPage();

    public DetailedWeatherPage()
    {
        InitializeComponent();        
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await ChekInterntetConnectivity();
        if (weatherPage.GetDataWeatherGettingMethod()) {
            await GetWeatherByLocationButton(weatherPage.GetLatitude(), weatherPage.GetLongtitude());
        }                   
        else {
            await GetWeatherByCityButton(weatherPage.GetCityName());
        }            
    }

    private void OnGoBackButtonClicked(Object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
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
        detailedWeatherDataView.ItemsSource = getWeather.list;

        //column 1
        tempLabel.Text = getWeather.list[0].main.convertedTemp + "°C";
        minTempLabel.Text = getWeather.list[0].main.convertedMinTemp + "°C";
        maxTempLabel.Text = getWeather.list[0].main.convertedMaxTemp + "°C";
        preassureLabel.Text = getWeather.list[0].main.pressure + "hPa";

        //column 2
        humidityLabel.Text = getWeather.list[0].main.humidity + " %";
        windSpeedLabel.Text = getWeather.list[0].wind.speedInMeters + " m/s";
        sunriseLabel.Text = getWeather.city.sunriseTime;
        sunsetLabel.Text = getWeather.city.sunsetTime; 
    }

    public async Task ChekInterntetConnectivity()
    {
        if (Connectivity.Current.NetworkAccess == NetworkAccess.None)
        {
            await DisplayAlert(title: "Internet connection not found!",
                                message: "Make sure you connected to the internet and restart an app",
                                cancel: "Ok");
            System.Environment.Exit(0);
        }
    }
}
