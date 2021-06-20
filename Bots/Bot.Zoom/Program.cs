using Bot.Zoom.Models;
using Bot.Zoom.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace Bot.Zoom
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var isService = !(Debugger.IsAttached || args.Contains("--console"));
            var config = LoadConfiguration();

            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   // services.AddSingleton<IJobConfiguration, JobConfiguration>();

               });
           
        }

        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(AppContext.BaseDirectory)
              .AddJsonFile("appsettings.json");

            return builder.Build();

        }

    }
}
