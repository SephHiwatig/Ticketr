using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Ticketr.Configuration.Extensions
{
    public static class IHostBuilderExtension
    {
        public static IHostBuilder UseConfigurations(this IHostBuilder instance)
        {
            var baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(baseDirectory!, "Configs", "TicketrSettings.json");

            instance.ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
            {
                configurationBuilder.AddJsonFile(filePath, optional: false, reloadOnChange: true);
            });

            return instance;
        }
    }
}
