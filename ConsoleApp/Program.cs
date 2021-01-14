using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerHub.SubscriberCDP
{
    public class Program
    {
        private static IConfiguration _configuration;

        static async Task Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            {
                await serviceProvider
                    .GetService<KafkaHandler>()
                    .Start();
            }
        }

        /// <summary>
        /// Конфигурация сервиса
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            const string environmentVariableName = "ASPNETCORE_ENVIRONMENT";
            var environmentName =
                //Environment.GetEnvironmentVariable(environmentVariableName, EnvironmentVariableTarget.Machine) ??
                Environment.GetEnvironmentVariable(environmentVariableName);

            var services = new ServiceCollection();
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json")
                .AddEnvironmentVariables()
                .Build();
            services.AddSingleton(_configuration);
            services.AddSingleton<KafkaHandler>();

            return services.BuildServiceProvider();
        }
    }
}
