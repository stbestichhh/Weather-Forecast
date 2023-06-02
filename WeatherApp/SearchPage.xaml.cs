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

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        SearchHistoryDatabase database = await SearchHistoryDatabase.Instance;
        searchStory.ItemsSource = await database.GetItemsAsync();
    }

    private async void returnButton_Clicked(System.Object sender, System.EventArgs e)
    {
        cityNameSearched = searchBar.Text;

        var storyCityLabel = (DatabaseTable)BindingContext;
        SearchHistoryDatabase database = await SearchHistoryDatabase.Instance;
        await database.SaveItemAsync(storyCityLabel);

        await Navigation.PushModalAsync(new WeatherPage());
    }

    async void deleteButton_Clicked(System.Object sender, System.EventArgs e)
    {
        var storyCityLabel = (DatabaseTable)BindingContext;
        SearchHistoryDatabase database = await SearchHistoryDatabase.Instance;
        await database.DeleteItemAsync(storyCityLabel);
    }

    async void searchStory_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        if(e.CurrentSelection != null)
        {
            await Navigation.PushModalAsync(new WeatherPage
            {
                BindingContext = e.CurrentSelection as DatabaseTable
            });
        }
    }
}
