using Bot.Zoom.Interfaces;
using Bot.Zoom.Models;
using Bot.Zoom.Repositories;
using Bot.Zoom.Services;
using Bot.Zoom.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bot.Zoom
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var isService = !(Debugger.IsAttached || args.Contains("--console"));
            var config = LoadConfiguration();

            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddHostedService<Service>();
                   services.AddSingleton(config);
                   services.AddSingleton<IBotZoomSettings, BotZoomSettings>();
                   services.AddSingleton<IProductRepository, ProductRepository>();

               });

            if (isService)
            {
                await builder.RunAsServiceAsync();
            }
            else
            {
                await builder.RunConsoleAsync();
            }

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
