using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using ConfigureInstance;
using System.Net.Http;
using System.Threading;

[assembly: FunctionsStartup(typeof(Startup))]
namespace ConfigureInstance
{
    class Startup
    {


        public void Configure(IFunctionsHostBuilder builder)
        {

            //builder.Services.AddHttpClient();
            //var provider = builder.Services.BuildServiceProvider();
            //var clientFactory = provider.GetService<IHttpClientFactory>();
           
        }

      
    }
}
