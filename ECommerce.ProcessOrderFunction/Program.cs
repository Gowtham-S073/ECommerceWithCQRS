using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Azure.Messaging.ServiceBus;

namespace ECommerce.ProcessOrderFunction
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                           .AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<ServiceBusClient>(sp =>
                    {
                        var configuration = sp.GetRequiredService<IConfiguration>();
                        var serviceBusConnectionString = configuration.GetConnectionString("ServiceBusConnectionString");
                        return new ServiceBusClient(serviceBusConnectionString);
                    });
                })
                .Build();

            host.Run();
        }
    }
}
