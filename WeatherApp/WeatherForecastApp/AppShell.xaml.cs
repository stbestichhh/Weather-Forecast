﻿namespace WeatherForecastApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(AppRoutes.mainPageRoute, typeof(MainPage));
        Routing.RegisterRoute(AppRoutes.secondaryPageRoute, typeof(SecondaryPage));
    }
}