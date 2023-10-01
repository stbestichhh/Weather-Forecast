namespace WeatherForecastApp.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    void SearchButton_Clicked(System.Object sender, System.EventArgs e)
    {

    }

    private async void SwipeUpGesture_Swiped(System.Object sender, Microsoft.Maui.Controls.SwipedEventArgs e)
    {
        await Shell.Current.GoToAsync(AppRoutes.secondaryPageRoute);
    }
}
