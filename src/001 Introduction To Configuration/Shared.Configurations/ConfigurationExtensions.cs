using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace Shared.Configurations;

public static class ConfigurationExtensions
{
    public static IConfigurationManager AddAppConfiguration(this IConfigurationManager configurationManager)
    {
        var basePath = AppContext.BaseDirectory;

        configurationManager
            .SetBasePath(basePath)
            .AddJsonFile("CustomAppSettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("dbdetails.json", optional: false, reloadOnChange: true);

        return configurationManager;
    }
}
