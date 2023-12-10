
using System.IO;
using Microsoft.Extensions.Configuration;

namespace UI;

public class ConfigurationManager
{
    public static IConfigurationRoot Configuration { get; set; }

    static ConfigurationManager() => Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

    public static string GetAdminEmail() => Configuration["adminAccount:email"];

    public static string GetAdminPassword() => Configuration["adminAccount:password"];
}
