# Weather App

based on [openweathermap/api](https://openweathermap.org/api)

This is a [.NET 7 MAUI ](https://dotnet.microsoft.com/en-us/apps/maui)app which shows current weather and forecast for the next 5 days every 3 hours.

![](AppPresentation.jpeg)

How to install you can find [here.](https://github.com/dotnet/maui/wiki#getting-started)


# How to use

**This app requires internet connection**

![](internetException.png)


Only first time launching this app you will see a welcome page. Then you meets the main page with general weather data. 

There are two buttons. «Where am I?» button automatically takes your current geolocation, then shows weather in your location. «Search» button allow you to find other place and see the weather there.

![](collectionView.png)Here is a forecast for next 5 days in every 3 hours. By tapping it you will    navigated to the page with additional information of the current weather: min and max temperature, sunrise and sunset time, atmosphere pressure, longitude and latitude in the current location.
