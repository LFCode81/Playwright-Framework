using Microsoft.Extensions.Configuration;
using Playwright_Framework.Models;

namespace Playwright_Framework.Utilities
{
    public static class ConfigReader
    {
        private static IConfiguration? _config;

        public static PlaywrightSettings Settings => Load();

        private static PlaywrightSettings Load()
        {
            _config ??= new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables()
                            .Build();

            return _config.GetSection("Playwright").Get<PlaywrightSettings>()!;
        }
    }
}
