namespace WeatherForecastApp.Services
{
    public interface IMainPage
    {
        Task LoadWeatherData();
        Task GetUserLocation();
        Task Location_LoadWeatherData(double tatitude, double longitude);
        Task City_LoadWeatherData(string city);
        void UpdateUI(dynamic getWeatherTask);
        Task CheckConnection();
    }
}

