using Microsoft.Extensions.Configuration;
using System.IO;

namespace UI {
    public class ConfigurationManager {
        static ConfigurationManager() {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static IConfigurationRoot Configuration { get; set; }

        public static string GetAdminEmail() {
            return Configuration["adminAccount:email"];
        }

        public static string GetAdminPassword() {
            return Configuration["adminAccount:password"];
        }
    }
}