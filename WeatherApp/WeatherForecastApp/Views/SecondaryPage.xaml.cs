namespace WeatherForecastApp.Views;

public partial class SecondaryPage : ContentPage
{
    public SecondaryPage()
    {
        InitializeComponent();
    }

    private async void SwipeDownGesture_Swiped(System.Object sender, Microsoft.Maui.Controls.SwipedEventArgs e)
    {
        await Shell.Current.GoToAsync(AppRoutes.mainPageRoute);
    }
}
