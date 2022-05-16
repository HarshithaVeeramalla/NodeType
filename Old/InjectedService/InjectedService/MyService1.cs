
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;


namespace InjectedService
{
    public class MyService1 
    {

        public MyService1()
        {
            //httpClient = httpClientN;
            //Logger = logger;


            httpClient = httpClient?? throw new ArgumentNullException(nameof(httpClient)); // no BaseAddress configured
            Logger = Logger ?? throw new ArgumentNullException(nameof(Logger));
        }
      



        public void LogMsg()
        {
            Console.WriteLine(httpClient.BaseAddress);
            //Logger.LogInformation(httpClient.BaseAddress);
            Telemetry.TrackTrace("BarLog" + httpClient.BaseAddress, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Information);
            Telemetry.TrackEvent("BarEvent" + httpClient.BaseAddress);
        }
        public ILogger<MyService1> Logger { get; }
        public TelemetryClient Telemetry { get; }
        public HttpClient httpClient { get; }
    }
}

