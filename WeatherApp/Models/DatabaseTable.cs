using System;
using SQLite;

namespace WeatherApp.Models
{
    public class DatabaseTable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}

