using System;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public static class ApiService
    {
        public static async Task<Root> GetWeather(double latitude, double longitude)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&appid=98cf0673e88ccd55a86fda0cfe7e0a80", latitude, longitude));
            return JsonConvert.DeserializeObject<Root>(response);
        }

        public static async Task<Root> GetWeatherByCity(string city)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&appid=98cf0673e88ccd55a86fda0cfe7e0a80", city));
            return JsonConvert.DeserializeObject<Root>(response);
        }
    }
}

