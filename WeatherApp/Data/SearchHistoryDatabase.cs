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
                CreateTableResult result = await Database.CreateTableAsync<SearchHistoryDatabase>();
            }
            catch (Exception e)
            {
                throw;
            }
            return instance;
        });
    }
}

