using System;
using SQLite;
using WeatherApp.Models;

namespace WeatherApp.Data
{
    public class SearchHistoryDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<SearchHistoryDatabase> Instance = new AsyncLazy<SearchHistoryDatabase>(async () =>
        {
            var instance = new SearchHistoryDatabase();
            try
            {
                CreateTableResult result = await Database.CreateTableAsync<DatabaseTable>();
            }
            catch (Exception e)
            {
                throw;
            }
            return instance;
        });

        public SearchHistoryDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.flags);
        }

        public Task<List<DatabaseTable>> GetItemsAsync()
        {
            return Database.Table<DatabaseTable>().ToListAsync();
        }

        public Task<int> SaveItemAsync(DatabaseTable cityName)
        {
            return cityName.ID != 0 ? Database.UpdateAsync(cityName) : Database.InsertAsync(cityName);
        }

        public Task<int> DeleteItemAsync(DatabaseTable cityName)
        {
            return Database.DeleteAsync(cityName);
        }
    }
}

