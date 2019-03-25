using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;

namespace LoggingWebMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(
           string[] args) => WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>()
              .ConfigureLogging(logging =>
              {
                // clear default logging providers
                logging.ClearProviders();

                // add built-in providers manually, if desired 
                logging.AddConsole();
                logging.AddDebug();
                logging.AddEventLog();
                logging.AddEventSourceLogger();
                //logging.AddTraceSource(sourceSwitchName);
            });
    }
}
