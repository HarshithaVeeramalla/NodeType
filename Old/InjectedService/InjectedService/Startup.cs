using System;
using InjectedService;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
[assembly: FunctionsStartup(typeof(Startup))]

namespace InjectedService
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<MyService>();
           // builder.Services.AddScoped<Customlog>();
            builder.Services.AddHttpClient<MyService1>(client =>
            {
                // this code never runs
                client.BaseAddress = new Uri("https://api.github.com/");
            });
        }
    }
}

