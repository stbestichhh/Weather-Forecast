using System;
namespace WeatherApp.Models
{
    public class Constants
    {
        public const string DatabaseFilename = "SearchHistoryDatabase.db3";

        public const SQLite.SQLiteOpenFlags flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}

