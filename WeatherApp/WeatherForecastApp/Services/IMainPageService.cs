namespace WeatherForecastApp.Models
{
    public interface IMainPage
    {
        Task LoadWeatherData();
        Task GetUserLocation();
        Task Location_LoadWeatherData(double tatitude, double longitude);
        Task City_LoadWeatherData(string city);
        void UpdateUI(Task<Root> getWeatherTask);
        Task CheckConnection();
    }
}

