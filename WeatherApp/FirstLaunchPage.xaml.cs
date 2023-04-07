namespace WeatherApp;

public partial class FirstLaunchPage : ContentPage
{
    public FirstLaunchPage()
    {
        InitializeComponent();
    }

    void StartButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushModalAsync(new WeatherPage());
    }
}
