using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebJobsSDK
{
    class Program
    {
        static async Task Main()
        {
            var builder = new HostBuilder();
            builder.UseEnvironment(EnvironmentName.Development);
            builder.ConfigureLogging((context, b) =>
            {
                b.AddConsole();
            });
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorageQueues();
            });
            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}