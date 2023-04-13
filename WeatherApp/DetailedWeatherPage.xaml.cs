using System.Windows.Input;

namespace WeatherApp;

public partial class DetailedWeatherPage : ContentPage
{
    public DetailedWeatherPage()
    {
        InitializeComponent();
    }

    void goBackButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushModalAsync(new WeatherPage());
    }


    //Weather Data Code

}
