using Microsoft.Extensions.Configuration;
using System.IO;

namespace ClassLibrary.AppSettings
{
    /// <summary>
    /// Class that reads the app settings.json folder for values
    /// </summary>
        public class AppConfiguration
        {
        public readonly string _connectionString = string.Empty;
        public IConfigurationSection appSetting { get; set; }
        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path);

            var root = configurationBuilder.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("Context").Value;
            appSetting = root.GetSection("ApplicationSettings");
        }
        public  string ConnectionString
        {
            get => _connectionString;
        }


    }
}
