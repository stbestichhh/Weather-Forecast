using System;

namespace WeatherApp
{
    public interface IUpdateApp
    {
        void UpdateUI(dynamic getWeather);
        Task ChekInterntetConnectivity();
    }
}

