using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Ticketr.Configuration.Extensions
{
    public static class IHostBuilderExtension
    {
        public static IHostBuilder UseConfigurations(this IHostBuilder instance)
        {
            instance.ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
            {
                var baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var filePath = Path.Combine(baseDirectory!, "Configs", "TicketrSettings.json");
                configurationBuilder.AddJsonFile(filePath, optional: false, reloadOnChange: true);
            });

            return instance;
        }
    }
}
