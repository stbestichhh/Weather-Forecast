using WeatherApp.Services;
using WeatherApp.Data;
using WeatherApp.Models;

namespace WeatherApp;

public partial class SearchPage : ContentPage
{
    private bool weatherDataGettingOption = WeatherPage.howtoGetDataWeather;
    public static string cityNameSearched;

    public SearchPage()
    {
        InitializeComponent();
    }

    private async void returnButton_Clicked(System.Object sender, System.EventArgs e)
    {
        cityNameSearched = searchBar.Text;

        var storyCityLabel = (DatabaseTable)BindingContext;
        SearchHistoryDatabase database = await SearchHistoryDatabase.Instance;
        await database.SaveItemAsync(storyCityLabel);

        await Navigation.PushModalAsync(new WeatherPage());
    }
}
