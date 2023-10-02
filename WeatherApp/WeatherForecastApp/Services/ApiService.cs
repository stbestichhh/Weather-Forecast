using Newtonsoft.Json;

namespace WeatherForecastApp.Services
{
    public static class ApiService
    {
        public static async Task GetWeather(double latitude, double longitude)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format($"https://api.openweathermap.org/data/2.5/forecast?lat={latitude}&lon={longitude}&units=metric&appid=APIKEY"));
            return JsonConvert.DeserializeObject(response);
        }

        public static async Task GetWeatherByCity(string city)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format($"https://api.openweathermap.org/data/2.5/forecast?q={city}&units=metric&appid=APIKEY"));
            return JsonConvert.DeserializeObject(response);
        }
    }
}