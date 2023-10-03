namespace WeatherForecastApp.Services
{
    public interface ISecondaryPageService
    {
        Task LoadWeatherData();
        Task Location_LoadWeatherData(double latitude, double longitude);   
        Task City_LoadWeatherData(string city);
        void UpdateUI(dynamic getWeather);
        Task CheckConnection();
    }
}

