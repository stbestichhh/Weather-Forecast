using WeatherApp.Services;

namespace WeatherApp;

public partial class SearchPage : ContentPage
{
    public SearchPage()
    {
        InitializeComponent();
    }

    private async void returnButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushModalAsync(new WeatherPage());
    }   
}
