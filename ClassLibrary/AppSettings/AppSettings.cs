using Microsoft.Extensions.Configuration;
using System.IO;

namespace ClassLibrary.AppSettings
{
    /// <summary>
    /// Class that reads the app settings.json folder for values can add more keys to app settings and use the appsetting property to access them
    /// </summary>
        public class AppConfiguration
        {
        public readonly string hospitalString = string.Empty;
        public readonly string pharmacyString = string.Empty;
        public IConfigurationSection appSetting { get; set; }
        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path);

            var root = configurationBuilder.Build();
            hospitalString = root.GetSection("ConnectionStrings").GetSection("Hospital").Value;
            pharmacyString = root.GetSection("ConnectionStrings").GetSection("Pharmacy").Value;
            appSetting = root.GetSection("ApplicationSettings");
        }
        public  string HospitalString
        {
            get => hospitalString;
        }
        public string PharmacyString
        {
            get => pharmacyString;
        }

    }
}
